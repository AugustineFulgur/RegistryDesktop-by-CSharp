using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;
using Microsoft.Win32;
using Registrydll;

namespace RegistryDesktop
{

    class Tool
    {
        public Panel panel; //mainWindow里的panel
        
        public Tool(Panel p)
        {
            this.panel = p;
        }

        public void changePanelForm(Form f) //更改panel中的窗口
        {
            if (this.panel == null)
            {
                throw new ComponentNotFoundException("主Panel值为空！");
            }
            this.panel.Controls.Clear(); //清除其中原本的内容
            f.TopLevel = false; //取消顶级控件
            f.FormBorderStyle = FormBorderStyle.None;
            f.Dock = DockStyle.Fill; //充满
            f.Parent = this.panel; //设置父组件
            f.Show();
        }

        public static bool isAdministrator() //判断是否使用管理员权限打开程序
        {
            WindowsPrincipal p = new WindowsPrincipal(WindowsIdentity.GetCurrent());
                return p.IsInRole(WindowsBuiltInRole.Administrator);
        }
    }
}
