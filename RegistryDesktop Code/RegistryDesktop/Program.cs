using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Registrydll;

namespace RegistryDesktop
{
    static class Program
    {

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (!Tool.isAdministrator())
            {
                throw new UserNotAdministratorException("请使用管理员权限重新打开程序！");
            }
            INIOperate.SetINIRoot();
            LogFunc.SetUp();
            RegistrydllFunc.SetIERegistryNape();
            SQLitedll.SetSqlite();
            //静态类初始化
            SQLitedll.WriteDBLog("运行程序");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainWindow());
        }
    }
}
