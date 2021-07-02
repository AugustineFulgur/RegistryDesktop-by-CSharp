namespace RegistryDesktop
{
    partial class MainWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.welTimer = new System.Windows.Forms.Timer(this.components);
            this.mainPanel = new System.Windows.Forms.Panel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.scanL = new System.Windows.Forms.ToolStripMenuItem();
            this.recordL = new System.Windows.Forms.ToolStripMenuItem();
            this.查看日志文件夹ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openLogFile = new System.Windows.Forms.ToolStripMenuItem();
            this.清空日志ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsL = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutL = new System.Windows.Forms.ToolStripMenuItem();
            this.openLogFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // welTimer
            // 
            this.welTimer.Tick += new System.EventHandler(this.welTimer_Tick);
            // 
            // mainPanel
            // 
            this.mainPanel.AutoScroll = true;
            this.mainPanel.AutoSize = true;
            this.mainPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.mainPanel.Location = new System.Drawing.Point(0, 28);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1400, 600);
            this.mainPanel.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scanL,
            this.recordL,
            this.settingsL,
            this.aboutL});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1352, 25);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // scanL
            // 
            this.scanL.Name = "scanL";
            this.scanL.Size = new System.Drawing.Size(80, 21);
            this.scanL.Text = "扫描注册表";
            this.scanL.Click += new System.EventHandler(this.scanL_Click);
            // 
            // recordL
            // 
            this.recordL.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查看日志文件夹ToolStripMenuItem1,
            this.openLogFile,
            this.清空日志ToolStripMenuItem1});
            this.recordL.Name = "recordL";
            this.recordL.Size = new System.Drawing.Size(44, 21);
            this.recordL.Text = "日志";
            // 
            // 查看日志文件夹ToolStripMenuItem1
            // 
            this.查看日志文件夹ToolStripMenuItem1.Name = "查看日志文件夹ToolStripMenuItem1";
            this.查看日志文件夹ToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.查看日志文件夹ToolStripMenuItem1.Text = "查看日志文件夹";
            this.查看日志文件夹ToolStripMenuItem1.Click += new System.EventHandler(this.openLogFolder_Click);
            // 
            // openLogFile
            // 
            this.openLogFile.Name = "openLogFile";
            this.openLogFile.Size = new System.Drawing.Size(160, 22);
            this.openLogFile.Text = "打开日志文件";
            this.openLogFile.Click += new System.EventHandler(this.openLogFile_Click);
            // 
            // 清空日志ToolStripMenuItem1
            // 
            this.清空日志ToolStripMenuItem1.Name = "清空日志ToolStripMenuItem1";
            this.清空日志ToolStripMenuItem1.Size = new System.Drawing.Size(160, 22);
            this.清空日志ToolStripMenuItem1.Text = "清空日志";
            // 
            // settingsL
            // 
            this.settingsL.Name = "settingsL";
            this.settingsL.Size = new System.Drawing.Size(44, 21);
            this.settingsL.Text = "设置";
            this.settingsL.Click += new System.EventHandler(this.settingsL_Click);
            // 
            // aboutL
            // 
            this.aboutL.Name = "aboutL";
            this.aboutL.Size = new System.Drawing.Size(44, 21);
            this.aboutL.Text = "关于";
            this.aboutL.Click += new System.EventHandler(this.aboutL_Click);
            // 
            // openLogFileDialog
            // 
            this.openLogFileDialog.FileName = "openFileDialog1";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1352, 628);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.mainPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "注册表清理工具 by August";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer welTimer;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem scanL;
        private System.Windows.Forms.ToolStripMenuItem recordL;
        private System.Windows.Forms.ToolStripMenuItem 查看日志文件夹ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem openLogFile;
        private System.Windows.Forms.ToolStripMenuItem 清空日志ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem settingsL;
        private System.Windows.Forms.ToolStripMenuItem aboutL;
        private System.Windows.Forms.OpenFileDialog openLogFileDialog;
    }
}

