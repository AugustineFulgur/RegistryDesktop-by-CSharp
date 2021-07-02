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
    public partial class Settings : Form
    {

        public Settings()
        {
            InitializeComponent();
            this.updateText();
        }

        public void updateText()
        {
            //更新两个参数，随时调用
            scanType.Text = INIConst.ScanType;
            registryRoad.Text = INIConst.RegistrySaveRoad;
            logRoad.Text = INIConst.LogSaveRoad; //同步两个参数
        }

        private void changeRegistrySaveRoad_Click(object sender, EventArgs e)
        {
            if (choseFileRoad.ShowDialog() == DialogResult.OK)
            {
                INIConst.RegistrySaveRoad = choseFileRoad.SelectedPath;
                this.updateText();
            }
        }

        private void changeLogSaveRoad_Click(object sender, EventArgs e)
        {
            if (choseFileRoad.ShowDialog() == DialogResult.OK)
            {
                INIConst.LogSaveRoad = choseFileRoad.SelectedPath;
                this.updateText();
            }
        }

        private void accept_Click(object sender, EventArgs e)
        {
            INIConst.ScanType = scanType.Text == "全盘模式" ? "全盘模式" : "快速模式";
            this.Close();
        }

        private void Settings_Load(object sender, EventArgs e)
        {

        }
    }
}
