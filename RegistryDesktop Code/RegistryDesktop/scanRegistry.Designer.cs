namespace RegistryDesktop
{
    partial class scanRegistry
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
            this.components = new System.ComponentModel.Container();
            this.registryGird = new System.Windows.Forms.DataGridView();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.advise = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.route = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.value = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.time = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chose = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.clearAll = new System.Windows.Forms.Button();
            this.clearChose = new System.Windows.Forms.Button();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.reserveAll = new System.Windows.Forms.Button();
            this.choseAll = new System.Windows.Forms.Button();
            this.choseK = new System.Windows.Forms.Button();
            this.logRe = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.registryGird)).BeginInit();
            this.bottomPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // registryGird
            // 
            this.registryGird.AllowUserToAddRows = false;
            this.registryGird.AllowUserToDeleteRows = false;
            this.registryGird.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.registryGird.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.registryGird.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.registryGird.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.type,
            this.advise,
            this.route,
            this.value,
            this.time,
            this.chose});
            this.registryGird.Dock = System.Windows.Forms.DockStyle.Top;
            this.registryGird.GridColor = System.Drawing.SystemColors.ControlLight;
            this.registryGird.Location = new System.Drawing.Point(0, 0);
            this.registryGird.Name = "registryGird";
            this.registryGird.ReadOnly = true;
            this.registryGird.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.registryGird.RowHeadersWidth = 60;
            this.registryGird.RowTemplate.Height = 23;
            this.registryGird.Size = new System.Drawing.Size(1384, 484);
            this.registryGird.TabIndex = 0;
            this.registryGird.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // type
            // 
            this.type.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.type.Frozen = true;
            this.type.HeaderText = "类型";
            this.type.Name = "type";
            this.type.ReadOnly = true;
            // 
            // advise
            // 
            this.advise.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.advise.Frozen = true;
            this.advise.HeaderText = "建议";
            this.advise.Name = "advise";
            this.advise.ReadOnly = true;
            this.advise.Width = 150;
            // 
            // route
            // 
            this.route.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.route.Frozen = true;
            this.route.HeaderText = "路径";
            this.route.Name = "route";
            this.route.ReadOnly = true;
            this.route.Width = 500;
            // 
            // value
            // 
            this.value.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.value.Frozen = true;
            this.value.HeaderText = "值";
            this.value.Name = "value";
            this.value.ReadOnly = true;
            this.value.Width = 50;
            // 
            // time
            // 
            this.time.HeaderText = "时间";
            this.time.Name = "time";
            this.time.ReadOnly = true;
            // 
            // chose
            // 
            this.chose.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.chose.FalseValue = "false";
            this.chose.HeaderText = "选中";
            this.chose.Name = "chose";
            this.chose.ReadOnly = true;
            this.chose.TrueValue = "true";
            this.chose.Width = 150;
            // 
            // clearAll
            // 
            this.clearAll.Location = new System.Drawing.Point(1033, 30);
            this.clearAll.Name = "clearAll";
            this.clearAll.Size = new System.Drawing.Size(100, 30);
            this.clearAll.TabIndex = 1;
            this.clearAll.Text = "清除全部";
            this.clearAll.UseVisualStyleBackColor = true;
            this.clearAll.Click += new System.EventHandler(this.clearAll_Click);
            // 
            // clearChose
            // 
            this.clearChose.Location = new System.Drawing.Point(1139, 30);
            this.clearChose.Name = "clearChose";
            this.clearChose.Size = new System.Drawing.Size(100, 30);
            this.clearChose.TabIndex = 2;
            this.clearChose.Text = "清除选中";
            this.clearChose.UseVisualStyleBackColor = true;
            this.clearChose.Click += new System.EventHandler(this.clearChose_Click);
            // 
            // bottomPanel
            // 
            this.bottomPanel.BackColor = System.Drawing.SystemColors.ControlDark;
            this.bottomPanel.Controls.Add(this.logRe);
            this.bottomPanel.Controls.Add(this.reserveAll);
            this.bottomPanel.Controls.Add(this.choseAll);
            this.bottomPanel.Controls.Add(this.choseK);
            this.bottomPanel.Controls.Add(this.clearAll);
            this.bottomPanel.Controls.Add(this.clearChose);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bottomPanel.Location = new System.Drawing.Point(0, 490);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Size = new System.Drawing.Size(1384, 71);
            this.bottomPanel.TabIndex = 3;
            // 
            // reserveAll
            // 
            this.reserveAll.Location = new System.Drawing.Point(425, 30);
            this.reserveAll.Name = "reserveAll";
            this.reserveAll.Size = new System.Drawing.Size(100, 30);
            this.reserveAll.TabIndex = 5;
            this.reserveAll.Text = "反选";
            this.reserveAll.UseVisualStyleBackColor = true;
            this.reserveAll.Click += new System.EventHandler(this.reserveAll_Click);
            // 
            // choseAll
            // 
            this.choseAll.Location = new System.Drawing.Point(213, 30);
            this.choseAll.Name = "choseAll";
            this.choseAll.Size = new System.Drawing.Size(100, 30);
            this.choseAll.TabIndex = 4;
            this.choseAll.Text = "全选";
            this.choseAll.UseVisualStyleBackColor = true;
            this.choseAll.Click += new System.EventHandler(this.choseAll_Click);
            // 
            // choseK
            // 
            this.choseK.Location = new System.Drawing.Point(319, 30);
            this.choseK.Name = "choseK";
            this.choseK.Size = new System.Drawing.Size(100, 30);
            this.choseK.TabIndex = 3;
            this.choseK.Text = "勾选无疑问项";
            this.choseK.UseVisualStyleBackColor = true;
            this.choseK.Click += new System.EventHandler(this.choseK_Click);
            // 
            // logRe
            // 
            this.logRe.Location = new System.Drawing.Point(708, 29);
            this.logRe.Name = "logRe";
            this.logRe.Size = new System.Drawing.Size(100, 30);
            this.logRe.TabIndex = 6;
            this.logRe.Text = "还原日志记录";
            this.logRe.UseVisualStyleBackColor = true;
            this.logRe.Click += new System.EventHandler(this.logRe_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // scanRegistry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1384, 561);
            this.Controls.Add(this.bottomPanel);
            this.Controls.Add(this.registryGird);
            this.Name = "scanRegistry";
            this.Text = "scanRegistry";
            ((System.ComponentModel.ISupportInitialize)(this.registryGird)).EndInit();
            this.bottomPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView registryGird;
        private System.Windows.Forms.Button clearAll;
        private System.Windows.Forms.Button clearChose;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Button reserveAll;
        private System.Windows.Forms.Button choseAll;
        private System.Windows.Forms.Button choseK;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn advise;
        private System.Windows.Forms.DataGridViewTextBoxColumn route;
        private System.Windows.Forms.DataGridViewTextBoxColumn value;
        private System.Windows.Forms.DataGridViewTextBoxColumn time;
        private System.Windows.Forms.DataGridViewCheckBoxColumn chose;
        private System.Windows.Forms.Button logRe;
    }
}