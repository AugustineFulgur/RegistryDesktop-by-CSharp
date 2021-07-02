namespace RegistryDesktop
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            this.accept = new System.Windows.Forms.Button();
            this.scanType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.registryRoad = new System.Windows.Forms.TextBox();
            this.logRoad = new System.Windows.Forms.TextBox();
            this.changeRegistrySaveRoad = new System.Windows.Forms.Button();
            this.changeLogSaveRoad = new System.Windows.Forms.Button();
            this.choseFileRoad = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // accept
            // 
            this.accept.Location = new System.Drawing.Point(194, 230);
            this.accept.Name = "accept";
            this.accept.Size = new System.Drawing.Size(75, 23);
            this.accept.TabIndex = 0;
            this.accept.Text = "确定";
            this.accept.UseVisualStyleBackColor = true;
            this.accept.Click += new System.EventHandler(this.accept_Click);
            // 
            // scanType
            // 
            this.scanType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.scanType.FormattingEnabled = true;
            this.scanType.Items.AddRange(new object[] {
            "快速模式（只扫描文件后缀）",
            "全盘模式"});
            this.scanType.Location = new System.Drawing.Point(162, 38);
            this.scanType.Name = "scanType";
            this.scanType.Size = new System.Drawing.Size(185, 22);
            this.scanType.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(75, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 2;
            this.label1.Text = "扫描模式：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(33, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "注册表备份路径：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(75, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "日志路径：";
            // 
            // registryRoad
            // 
            this.registryRoad.Location = new System.Drawing.Point(162, 94);
            this.registryRoad.Name = "registryRoad";
            this.registryRoad.ReadOnly = true;
            this.registryRoad.Size = new System.Drawing.Size(185, 21);
            this.registryRoad.TabIndex = 5;
            // 
            // logRoad
            // 
            this.logRoad.Location = new System.Drawing.Point(162, 153);
            this.logRoad.Name = "logRoad";
            this.logRoad.ReadOnly = true;
            this.logRoad.Size = new System.Drawing.Size(185, 21);
            this.logRoad.TabIndex = 6;
            // 
            // changeRegistrySaveRoad
            // 
            this.changeRegistrySaveRoad.Location = new System.Drawing.Point(353, 92);
            this.changeRegistrySaveRoad.Name = "changeRegistrySaveRoad";
            this.changeRegistrySaveRoad.Size = new System.Drawing.Size(75, 23);
            this.changeRegistrySaveRoad.TabIndex = 7;
            this.changeRegistrySaveRoad.Text = "修改";
            this.changeRegistrySaveRoad.UseVisualStyleBackColor = true;
            this.changeRegistrySaveRoad.Click += new System.EventHandler(this.changeRegistrySaveRoad_Click);
            // 
            // changeLogSaveRoad
            // 
            this.changeLogSaveRoad.Location = new System.Drawing.Point(353, 150);
            this.changeLogSaveRoad.Name = "changeLogSaveRoad";
            this.changeLogSaveRoad.Size = new System.Drawing.Size(75, 23);
            this.changeLogSaveRoad.TabIndex = 8;
            this.changeLogSaveRoad.Text = "修改";
            this.changeLogSaveRoad.UseVisualStyleBackColor = true;
            this.changeLogSaveRoad.Click += new System.EventHandler(this.changeLogSaveRoad_Click);
            // 
            // Settings
            // 
            this.AcceptButton = this.accept;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ClientSize = new System.Drawing.Size(479, 275);
            this.Controls.Add(this.changeLogSaveRoad);
            this.Controls.Add(this.changeRegistrySaveRoad);
            this.Controls.Add(this.logRoad);
            this.Controls.Add(this.registryRoad);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.scanType);
            this.Controls.Add(this.accept);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Settings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置";
            this.TransparencyKey = System.Drawing.Color.SkyBlue;
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button accept;
        private System.Windows.Forms.ComboBox scanType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox registryRoad;
        private System.Windows.Forms.TextBox logRoad;
        private System.Windows.Forms.Button changeRegistrySaveRoad;
        private System.Windows.Forms.Button changeLogSaveRoad;
        private System.Windows.Forms.FolderBrowserDialog choseFileRoad;
    }
}