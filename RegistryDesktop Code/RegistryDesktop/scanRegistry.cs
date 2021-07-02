using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Registrydll;

namespace RegistryDesktop
{
    public partial class scanRegistry : Form
    {
        public RegistrydllResult result;
        public RegistrydllResult log;
        public String logName;

        public scanRegistry()
        {
            InitializeComponent();
        }

        public void ReButton(bool r=true)
        {
            //快速显示隐藏按钮
            foreach(Control con in this.bottomPanel.Controls)
            {
                if(con is Button)
                {
                    con.Enabled = r;
                }
            }
            this.logRe.Enabled = !r;
        }

        public void AddRegistryResult() //扫描结果
        {
            SQLitedll.WriteDBLog("扫描注册表");
            registryGird.Visible = true;
            registryGird.Columns[1].HeaderCell.Value = "建议";
            this.ReButton();
            RegistrydllResult t = new RegistrydllResult();
            t = t + RegistrydllFunc.ScanPostfixInvalidNape();
            if (INIConst.ScanType == "全盘模式")
            {
                t = t + RegistrydllFunc.ScanSoftwareInvalidNapeX32();
                t = t + RegistrydllFunc.ScanSoftwareInvalidNapeX64();
            }
            this.result = t;
            foreach (RegistrydllResultUnit i in this.result.units) //遍历结果集合
            {
                int index = registryGird.Rows.Add();
                registryGird.Rows[index].Cells[0].Value = i.type;
                registryGird.Rows[index].Cells[1].Value = i.advice;
                registryGird.Rows[index].Cells[2].Value = i.route;
                registryGird.Rows[index].Cells[3].Value = i.value;
                registryGird.Rows[index].Cells[4].Value = "无";
                registryGird.Rows[index].Cells[5].Value = false;
            }
        }

        public void AddLogResult(RegistrydllResult log,String logName) //日志
        {
            SQLitedll.WriteDBLog("读取日志");
            logName=logName.Replace("Log", "Registry");
            logName=logName.Replace("rdlog", "rdreg"); //路径中不要出现Registry与rereg
            this.logName = logName;
            this.log = log;
            registryGird.Visible = true;
            registryGird.Columns[1].HeaderCell.Value = "操作";
            this.ReButton(false);
            foreach (RegistrydllResultUnit i in log.units) //遍历结果集合
            {
                int index = registryGird.Rows.Add();
                registryGird.Rows[index].Cells[0].Value = i.type;
                registryGird.Rows[index].Cells[1].Value = i.advice;
                registryGird.Rows[index].Cells[2].Value = i.route;
                registryGird.Rows[index].Cells[3].Value = i.value;
                registryGird.Rows[index].Cells[4].Value = i.time;
                registryGird.Rows[index].Cells[5].Value = false;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            registryGird.Rows[e.RowIndex].Cells[5].Value = (bool)registryGird.Rows[e.RowIndex].Cells[5].Value == true ? false : true;
        }

        private void choseAll_Click(object sender, EventArgs e)
        {
            int row = registryGird.RowCount;
            for(int i = 0; i < row; i++)
            {
                registryGird.Rows[i].Cells[5].Value = true;
            }
        }

        private void reserveAll_Click(object sender, EventArgs e)
        {
            int row = registryGird.RowCount;
            for (int i = 0; i < row; i++)
            {
                registryGird.Rows[i].Cells[5].Value = (bool)registryGird.Rows[i].Cells[5].Value==true?false:true;
            }
        }

        private void choseK_Click(object sender, EventArgs e)
        {
            int row = registryGird.RowCount;
            for (int i = 0; i < row; i++)
            {
                if ((String)registryGird.Rows[i].Cells[1].Value == RegistrydllResultUnit.f)
                {
                    registryGird.Rows[i].Cells[5].Value = true;
                }
            }
        }

        private void clearAll_Click(object sender, EventArgs e) //
        {
            SQLitedll.WriteDBLog("清理注册表");
            RegistrydllResult log = new RegistrydllResult();
            for(int i = 0; i < this.result.number; i++)
            {
                RegistrydllFunc.ExportRegistryNape(this.result.units[i]);
                RegistrydllFunc.DeleteInvalidNape(this.result.units[i].key, value:this.result.units[i].nape);
                this.result.units[i].advice = "删除";
                log.Add(this.result.units[i]);
            }
            LogFunc.SetLog(log);
        }

        private void clearChose_Click(object sender, EventArgs e)
        {
            SQLitedll.WriteDBLog("清理注册表");
            RegistrydllResult log = new RegistrydllResult();
            for (int i = 0; i < this.result.number; i++)
            {
                if ((bool)registryGird.Rows[i].Cells[5].Value == true)
                {
                    RegistrydllFunc.ExportRegistryNape(this.result.units[i]);
                    RegistrydllFunc.DeleteInvalidNape(this.result.units[i].key, value:this.result.units[i].nape);
                    this.result.units[i].advice = "删除";
                    log.Add(this.result.units[i]);
                }
            }
            this.gridRefresh("清理完毕！");
            LogFunc.SetLog(log);
        }

        private void gridRefresh(String s)
        {
            MessageBox.Show(s);
            registryGird.Visible = false;
        }

        private void logRe_Click(object sender, EventArgs e)
        {
            SQLitedll.WriteDBLog("导入注册表");
            RegistrydllFunc.ImportRegistryNape(this.logName);
            this.gridRefresh("导入成功！");
        }
    }

}
