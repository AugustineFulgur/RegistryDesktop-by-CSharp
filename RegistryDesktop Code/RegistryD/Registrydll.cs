using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.IO;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Data.SQLite;


namespace Registrydll
{
    public class FilesNotFoundException : Exception
    {
        //文件缺失报错
        public FilesNotFoundException(String e) : base(e)
        {
            MessageBox.Show(e); //展示信息
            System.Environment.Exit(0); //强制退出程序
        }
    }

    public class ComponentNotFoundException : Exception
    {
        public ComponentNotFoundException(String s) : base(s)
        {

        }
    }

    public class UserNotAdministratorException : Exception
    {
        public UserNotAdministratorException(String s) : base(s)
        {
            MessageBox.Show(s); //展示信息
            System.Environment.Exit(0); //强制退出程序
        }
    }

    public static class SQLitedll
    {
        public static String SQLITE_ROOT = "db.db3";
        public static SQLiteConnection SQLITE_DB;
        public static SQLiteCommand SQLITE_COMMAND;
        /*
        db.sqlite3:
        Id 主键 自增 integer
        Type 操作名 varchar
        Time 时间 int    
        */

        public static void SetSqlite()
        {
            SQLitedll.SQLITE_ROOT=RegistrydllFunc.GetRuntimeRoot(SQLitedll.SQLITE_ROOT);
            SQLitedll.SQLITE_DB = new SQLiteConnection("Data Source=" + SQLitedll.SQLITE_ROOT);
        }
        
        public static void WriteDBLog(String s)
        {
            SQLitedll.SQLITE_DB.Open();
            SQLitedll.SQLITE_COMMAND = SQLitedll.SQLITE_DB.CreateCommand();
            int sec = (int)(DateTime.Now - new DateTime(1970, 1, 1, 0, 0, 0, 0)).TotalSeconds;
            SQLITE_COMMAND.CommandText = String.Format("insert into RDdatabase (Type,Time) values('{0}',{1})", s, sec);
            SQLITE_COMMAND.ExecuteNonQuery();
            SQLitedll.SQLITE_DB.Close();
        }
    }

    public static class RegistrydllConst
    {
        public static bool WOW64 = Environment.Is64BitOperatingSystem; //系统位数
        public static RegistryKey HKEY_CLASSES_ROOT = RegistryKey.OpenBaseKey(RegistryHive.ClassesRoot, WOW64 ? RegistryView.Registry64 : RegistryView.Registry32);
        public static RegistryKey HKEY_CURRENT_USER = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, WOW64 ? RegistryView.Registry64 : RegistryView.Registry32);
        public static RegistryKey HKEY_LOCAL_MACHINE = RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, WOW64 ? RegistryView.Registry64 : RegistryView.Registry32);
        public static String Hkey_ProgID = @"OpenWithProgids";
        public static String Hkey_Shell = @"shell\Open\command";
        public static String Hkey_Software = @"SOFTWARE";
        public static String Hkey_WOW32 = @"SOFTWARE\Wow6432Node"; //64系统下32位反射
        public static String pattern = @"(\w:\\)(\w*\\)*\w+\.\w{2,6}"; //一个简单粗暴的表达式 专治各种不服
    }

    [Serializable]
    public class RegistrydllResult //结果集合，返回用 这样看来是否有些画蛇添足？
    {
        public int number; //总项目数
        public List<RegistrydllResultUnit> units; //项目的集合
        
        public RegistrydllResult()
        {
            this.number = 0;
            this.units = new List<RegistrydllResultUnit>();
        }

        public void Add(RegistrydllResultUnit u)
        {
            this.units.Add(u);
            this.number += 1;
        }

        public static RegistrydllResult operator+(RegistrydllResult a,RegistrydllResult b)
        {
            //重载运算符+，拼接两个RegistrydllResult
            RegistrydllResult c = new RegistrydllResult();
            c.units = a.units.Concat(b.units).ToList();
            c.number += a.number;
            c.number += b.number;
            Console.Write(c.units);
            return c;
        }

    }


    [Serializable]
    public class RegistrydllResultUnit //结果集合中的单元
    {
        public readonly String type;
        public String advice; //写入日志的时候会更改这个部分，所以不需要只读
        public readonly String route;
        public readonly String value;
        [NonSerialized]
        public readonly RegistryKey key;
        [NonSerialized]
        public readonly String nape; //处理的是项值时，项值
        public static readonly String f = "删除"; //可以直接选中
        public readonly DateTime time;

        public RegistrydllResultUnit(String type,String advice,String route,String value,RegistryKey key,String nape=null)
        {
            this.type = type; //类型
            this.advice = advice; //建议
            this.route = route; //注册表路径
            this.value = value; //值
            this.key = key; //键
            this.nape = nape;
            this.time = DateTime.Now;
        }
    }

    public static class RegistrydllFunc
    {
        public static String RegistryLog; //今日日志注册表文件

        public static void SetIERegistryNape() //导入导出注册表时调用
        {
            DateTime d = DateTime.Now;
            RegistrydllFunc.RegistryLog = INIConst.RegistrySaveRoad + @"\" + string.Format("Registry{0}-{1}-{2}.rdreg", d.Year, d.Month, d.Day);
            FileStream st = new FileStream(RegistrydllFunc.RegistryLog, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            st.Close();
        }

        public static String GetRuntimeRoot(String filename)
        {
            String mn = Process.GetCurrentProcess().MainModule.ModuleName;
            String fn = Process.GetCurrentProcess().MainModule.FileName;
            return fn.Replace(mn, filename);
        }

        public static String GetValidRegistryRoute(String originalstring) //返回[截取的字符串，分割的部分数] //截取程序路径
        {
            if (originalstring == null)
            {
                return null;
            }
            originalstring = originalstring.Replace('/', '\\');
            originalstring = originalstring.Replace(@"\\", "\\");
            //MessageBox.Show(originalstring);
            Match a = Regex.Match(originalstring, RegistrydllConst.pattern);
            if (a.Success)
            {
                //匹配成功
                return a.ToString();
            }
            return null; //截取路径
        }

        public static void ExportRegistryNape(RegistrydllResultUnit unit) //导出注册表
        {
            Process.Start("regedit", String.Format(@"-e {0} {1}", RegistrydllFunc.RegistryLog,unit.key.ToString()));
        }

        public static void ImportRegistryNape(String FileRoad) //导入注册表
        {
            //目前所知 导入注册表好像不支持路径
            Process.Start("regedit", String.Format(@"-c {0}", FileRoad==null?RegistrydllFunc.RegistryLog:FileRoad));
        }

        public static List<String> ReturnDotFuncs(String[] arg)
        {
            //返回列表里.**的内容，其实可以写的更简单 但是我想用foreach
            List<String> re = new List<String>();
            foreach (String i in arg)
            {
                if (i[0] == '.' )
                {
                    re.Add(i);
                }
            }
            return re;
        }

        public static RegistrydllResult ScanPostfixInvalidNape() 
        {
            //HKEY_CLASSES_ROOT\后缀名\OpenWithProgids\
            //本来还有HKEY_CURRENT_USER里的一部分，但是不敢乱删还是算了，没全搞懂
            RegistrydllResult re = new RegistrydllResult(); //返回项，为<RegistrydllResult>
            //查找后缀打开程序中的无效项
            foreach(String posfix in RegistrydllFunc.ReturnDotFuncs(RegistrydllConst.HKEY_CLASSES_ROOT.GetSubKeyNames())) //遍历所有待扫描的后缀
            {
                RegistryKey k = RegistrydllConst.HKEY_CLASSES_ROOT.OpenSubKey(posfix).OpenSubKey(RegistrydllConst.Hkey_ProgID,true); //获取用于打开此后缀的程序标识符列表
                if (k == null)
                {
                    continue;
                }
                foreach(String name in k.GetValueNames()) //遍历所有打开程序
                {
                    //在HKEY_CLASSES_ROOT中查找这些标识符，然后定位到路径
                    //只能\不能/，这是我没想到的
                    if (RegistrydllConst.HKEY_CLASSES_ROOT.OpenSubKey(name) == null)
                    {
                        continue;
                    }
                    object shell = RegistrydllConst.HKEY_CLASSES_ROOT.OpenSubKey(name).OpenSubKey(RegistrydllConst.Hkey_Shell);
                    if (shell == null)
                    {
                        //应该是已删除程序，或者系统应用
                        continue;
                    }
                    if ((shell as RegistryKey).GetValue("") == null)
                    {
                        //有些项目没有默认值
                        continue;
                    }
                    String a = (shell as RegistryKey).GetValue("").ToString();
                    String al = RegistrydllFunc.GetValidRegistryRoute(a);
                    if (!File.Exists(al) && al != null)
                    {
                        //路径不存在，应该被清理 
                        try
                        {
                            RegistrydllResultUnit unit1 = new RegistrydllResultUnit("无效程序信息", "待确认", @"HKEY_CLASSES_ROOT\" + name, al, RegistrydllConst.HKEY_CLASSES_ROOT.OpenSubKey(name, true));
                            RegistrydllResultUnit unit2 = new RegistrydllResultUnit("无效后缀程序信息","待确认", @"HKEY_CLASS_ROOT\" + posfix + @"\OpenWithProgids\" + name, "null", k, name);
                            re.Add(unit1);
                            re.Add(unit2);
                        }
                        catch
                        {

                        }
                    }
                }
            }
            return re;
        }

        public static RegistrydllResult ScanSoftwareInvalidNapeX32() //无效的软件遗留注册信息
        {
            //包括1.无效的程序路径2.空文件夹 //空文件夹慎删，可不敢乱搞
            RegistrydllResult re = new RegistrydllResult(); //返回项，为<RegistrydllResult>
            RegistryKey k1 = RegistrydllConst.HKEY_CURRENT_USER.OpenSubKey(RegistrydllConst.Hkey_Software,true);
            re=re+RegistrydllFunc.ScanSoftwareInvalidNapeFunc(k1, @"HKEY_CURRENT_USER\", RegistrydllConst.Hkey_Software);
            RegistryKey k2=RegistrydllConst.HKEY_LOCAL_MACHINE.OpenSubKey(RegistrydllConst.Hkey_Software,true);
            re = re + RegistrydllFunc.ScanSoftwareInvalidNapeFunc(k2, @"HKEY_LOCAL_MACHINE\", RegistrydllConst.Hkey_Software);
            return re;
        }

        public static RegistrydllResult ScanSoftwareInvalidNapeX64() //64位扩充
        {
            if (RegistrydllConst.WOW64 == false){ return new RegistrydllResult(); } //32位系统也想有高贵的反射吗
            //其实跟X32差不多，变了下路径，无聊
            RegistrydllResult re = new RegistrydllResult(); //返回项，为<RegistrydllResult>
            RegistryKey k1 = RegistrydllConst.HKEY_CURRENT_USER.OpenSubKey(RegistrydllConst.Hkey_WOW32,true);
            re = re + RegistrydllFunc.ScanSoftwareInvalidNapeFunc(k1, @"HKEY_CURRENT_USER\", RegistrydllConst.Hkey_WOW32);
            RegistryKey k2 = RegistrydllConst.HKEY_LOCAL_MACHINE.OpenSubKey(RegistrydllConst.Hkey_WOW32,true);
            re = re + RegistrydllFunc.ScanSoftwareInvalidNapeFunc(k2, @"HKEY_LOCAL_MACHINE\", RegistrydllConst.Hkey_WOW32);
            return re;
        }

        public static void DeleteInvalidNape(RegistryKey k,String value=null)
        {
            //删除此键下的所有内容
            if (value!=null)
            {
                k.DeleteValue(value);
            }
            else
            {
                k.DeleteSubKey(""); //不用DeleteSubKeyTree的原因是 如果不止删除空项的话我应该已经上了微软的暗杀名单
            }
        }

        public static RegistrydllResult ScanSoftwareInvalidNapeFunc(RegistryKey k,String reS,String Hkey) //封装了一下 键，父键名，子路径名
        {
            RegistrydllResult re = new RegistrydllResult(); //返回项，为<RegistrydllResult>
            foreach (String softname in k.GetSubKeyNames()) //遍历其下所有软件
            {
                RegistryKey software = k.OpenSubKey(softname,true);
                if (software.GetValue("") == null && software.GetSubKeyNames().Length == 0 && software.ValueCount==0)
                    //默认项为空 无其他项 无子键
                {
                    //子键为空 
                    RegistrydllResultUnit unit = new RegistrydllResultUnit("空软件项", "请确认此软件已经被卸载", software.ToString(), "null",software);
                    re.Add(unit);
                }
            }
            return re;
        }

    }

    public class INIOperate //读写INI文件
    {

        public static String ROOT_SETTING = "SETTINGS";
        public static String KEY_LOG_SAVE = "Logsave";
        public static String KEY_REGISTRY_SAVE = "Registrysave";
        public static String KEY_SCAN_TYPE = "Scantype";
        public static String INIRoot = "Settings.ini"; //文件路径，程序运行的时候会设置为完整路径

        [DllImport("kernel32.dll")] //加载非托管库
        private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault, StringBuilder lpReturnedString, int nSize, string lpFileName);
        //节点名 项名 查找失败返回的值 缓冲区大小 一次进入缓冲区的字符数量 INI文件路径 复制到缓冲区的字节数量

        [DllImport("kernel32.dll")]
        private static extern int WritePrivateProfileString(string lpApplicationName, string lpKeyName, string lpString, string lpFileName);
        //节点名 项名 写入的字符串 INI文件路径

        public static void SetINIRoot() //设置dll路径
        {
            INIOperate.INIRoot = RegistrydllFunc.GetRuntimeRoot(INIOperate.INIRoot);
            if (!File.Exists(INIOperate.INIRoot))
            {
                throw new FilesNotFoundException("Settings.ini文件缺失！");
            }
        }

        public static String INIDefault = ""; //默认值

        public static String GetINI(String section,String key) //读取
        {
            StringBuilder buffer = new StringBuilder(1024);
            INIOperate.GetPrivateProfileString(section, key, INIOperate.INIDefault, buffer, 1024, INIOperate.INIRoot);
            return buffer.ToString();
        }

        public static void SetINI(String section,String key,String value)
        {
            INIOperate.WritePrivateProfileString(section, key, value, INIOperate.INIRoot);
        }
    }

    public class INIConst //INI常用键值属性
    {
        public static String LogSaveRoad
        {
            get
            {
                return INIOperate.GetINI(INIOperate.ROOT_SETTING, INIOperate.KEY_LOG_SAVE);
            }
            set
            {
                INIOperate.SetINI(INIOperate.ROOT_SETTING, INIOperate.KEY_LOG_SAVE, value);
            }
        }

        public static String RegistrySaveRoad
        {
            get
            {
                return INIOperate.GetINI(INIOperate.ROOT_SETTING, INIOperate.KEY_REGISTRY_SAVE);
            }
            set
            {
                INIOperate.SetINI(INIOperate.ROOT_SETTING, INIOperate.KEY_REGISTRY_SAVE, value);
            }
        }

        public static String ScanType
        {
            get
            {
                return INIOperate.GetINI(INIOperate.ROOT_SETTING, INIOperate.KEY_SCAN_TYPE);
            }
            set
            {
                INIOperate.SetINI(INIOperate.ROOT_SETTING, INIOperate.KEY_SCAN_TYPE, value);
            }
        }
    }

    public static class LogFunc //写Log的类
    {
        public static String TodayLogName; //今日的Log文件名，设置每日一个Log文件
        public static Stream stream;
        public static IFormatter formatter;

        public static void SetStream(String file)
        {
            //由于TodayLogName不是编译时常量，所以只能用这个下下策了
            if (file == null)
            {
                LogFunc.stream = new FileStream(LogFunc.TodayLogName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            }
            else
            {
                LogFunc.stream = new FileStream(file, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            }
        }

        public static void DestroyStream()
        {
            LogFunc.stream.Close();
        }

        public static void SetUp()
        {
            DateTime d = DateTime.Now;
            String f= string.Format("Log{0}-{1}-{2}.rdlog", d.Year, d.Month, d.Day);
            LogFunc.TodayLogName = INIConst.LogSaveRoad + "/" + f;
            LogFunc.formatter = new BinaryFormatter();
            //静态属性初始化
            if (!File.Exists(LogFunc.TodayLogName))
            {
                //不存在今日的日志，序列化一个空对象存入
                LogFunc.SetStream(null);
                LogFunc.formatter.Serialize(LogFunc.stream, new RegistrydllResult());
                LogFunc.DestroyStream();
            }
        }

        //关于Log文件：
        //我们设定一个Log文件内只能有一个RegistrydllResult对象
        public static void SetLog(RegistrydllResult log,String s=null)
        {
            RegistrydllResult l = LogFunc.GetLog();
            log = log + l;
            Stream f=new FileStream(LogFunc.TodayLogName, FileMode.Truncate, FileAccess.ReadWrite, FileShare.None); //清除日志内容
            f.Close();
            LogFunc.SetStream(s);
            LogFunc.formatter.Serialize(LogFunc.stream, log);
            LogFunc.DestroyStream();
        }

        public static RegistrydllResult GetLog(String s=null)
        {
            LogFunc.SetStream(s);
            try
            {
                RegistrydllResult l = (RegistrydllResult)LogFunc.formatter.Deserialize(LogFunc.stream);
                LogFunc.DestroyStream();
                return l;
            }
            catch
            {
                MessageBox.Show("打开文件的格式错误！");
                return new RegistrydllResult();
            }
        }

    }

}
