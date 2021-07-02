using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegistryDesktop
{
    public partial class WelcomeWindow : Form
    {
        public WelcomeWindow()
        {
            InitializeComponent();
        }

        private void WelcomeWindow_Load(object sender, EventArgs e)
        {
            this.TopMost = true; //最前
            this.FormBorderStyle = FormBorderStyle.None; //去掉边框
            destroyTimer.Interval = 1000;
            destroyTimer.Start();
       
        }

        private void destroyTimer_Tick(object sender, EventArgs e)
        {
            //VS方便是方便，自动处理删不干净
            this.Close();
        }
    }
}
