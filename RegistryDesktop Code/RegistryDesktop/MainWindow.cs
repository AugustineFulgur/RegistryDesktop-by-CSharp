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
using System.Diagnostics;

namespace RegistryDesktop
{
    public partial class MainWindow : Form
    {
        private WelcomeWindow m;
        private Tool tool;

        public MainWindow()
        {
            InitializeComponent();
            this.tool = new Tool(mainPanel);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            this.Opacity = 0;
            welTimer.Interval = 500; //设置计时器时间间隔
            this.m = new WelcomeWindow();
            this.m.Show();
            welTimer.Start();
        }

        private void welTimer_Tick(object sender,EventArgs e)
        {
            this.Opacity = 1;
            welTimer.Stop();
        }

        private void scanL_Click(object sender, EventArgs e)
        {
            scanRegistry scan = new scanRegistry();
            this.tool.changePanelForm(scan);
            scan.AddRegistryResult();
        }

        private void settingsL_Click(object sender, EventArgs e)
        {
            Form x = new Settings();
            x.Show();
        }

        private void openLogFolder_Click(object sender,EventArgs e)
        {
            Process.Start("Explorer.exe", INIConst.LogSaveRoad); 
        }

        private void openLogFile_Click(object sender, EventArgs e)
        {
            scanRegistry scan = new scanRegistry();
            this.tool.changePanelForm(scan);
            if (openLogFileDialog.ShowDialog() == DialogResult.OK)
            {
                RegistrydllResult log = LogFunc.GetLog(openLogFileDialog.FileName);
                scan.AddLogResult(log,openLogFileDialog.FileName);
            }
        }

        private void aboutL_Click(object sender, EventArgs e)
        {
            Form ab = new about();
            ab.Show();
        }
    }
}
