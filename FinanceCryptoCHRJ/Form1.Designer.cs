namespace FinanceCryptoCHRJ
{
    partial class Form1
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
            this.btnMainRoll = new System.Windows.Forms.Label();
            this.btnFastRoll = new System.Windows.Forms.Label();
            this.btnStickyRoll = new System.Windows.Forms.Label();
            this.btnSetting = new System.Windows.Forms.Label();
            this.btnSlot0 = new System.Windows.Forms.Button();
            this.btnSlot1 = new System.Windows.Forms.Button();
            this.btnSlot2 = new System.Windows.Forms.Button();
            this.btnSlot3 = new System.Windows.Forms.Button();
            this.btnSlot4 = new System.Windows.Forms.Button();
            this.btnSlot5 = new System.Windows.Forms.Button();
            this.btnSlot6 = new System.Windows.Forms.Button();
            this.renderTimer = new System.Windows.Forms.Timer(this.components);
            this.displayArea = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnRemoveCurrent = new System.Windows.Forms.ToolStripMenuItem();
            this.btnReload = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnSecurityCheck = new System.Windows.Forms.ToolStripMenuItem();
            this.chkHasBgm = new System.Windows.Forms.ToolStripMenuItem();
            this.areaTopBar = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.areaFPS = new System.Windows.Forms.Label();
            this.borderDockTimer = new System.Windows.Forms.Timer(this.components);
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMainRoll
            // 
            this.btnMainRoll.BackColor = System.Drawing.Color.Transparent;
            this.btnMainRoll.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.btnMainRoll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMainRoll.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMainRoll.ForeColor = System.Drawing.Color.White;
            this.btnMainRoll.Location = new System.Drawing.Point(22, 210);
            this.btnMainRoll.Name = "btnMainRoll";
            this.btnMainRoll.Size = new System.Drawing.Size(260, 26);
            this.btnMainRoll.TabIndex = 1;
            this.btnMainRoll.Text = "按住开始摇号";
            this.btnMainRoll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMainRoll.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMainRoll_MouseDown);
            this.btnMainRoll.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMainRoll_MouseUp);
            // 
            // btnFastRoll
            // 
            this.btnFastRoll.BackColor = System.Drawing.Color.Transparent;
            this.btnFastRoll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFastRoll.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFastRoll.ForeColor = System.Drawing.Color.White;
            this.btnFastRoll.Location = new System.Drawing.Point(292, 211);
            this.btnFastRoll.Name = "btnFastRoll";
            this.btnFastRoll.Size = new System.Drawing.Size(85, 23);
            this.btnFastRoll.TabIndex = 1;
            this.btnFastRoll.Text = "快速摇号";
            this.btnFastRoll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnFastRoll.Click += new System.EventHandler(this.label2_Click);
            // 
            // btnStickyRoll
            // 
            this.btnStickyRoll.BackColor = System.Drawing.Color.Transparent;
            this.btnStickyRoll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStickyRoll.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnStickyRoll.ForeColor = System.Drawing.Color.White;
            this.btnStickyRoll.Location = new System.Drawing.Point(391, 211);
            this.btnStickyRoll.Name = "btnStickyRoll";
            this.btnStickyRoll.Size = new System.Drawing.Size(85, 23);
            this.btnStickyRoll.TabIndex = 1;
            this.btnStickyRoll.Text = "炫迈摇号";
            this.btnStickyRoll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnStickyRoll.Click += new System.EventHandler(this.btnStickyRoll_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.BackColor = System.Drawing.Color.Transparent;
            this.btnSetting.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSetting.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetting.ForeColor = System.Drawing.Color.White;
            this.btnSetting.Location = new System.Drawing.Point(492, 211);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(85, 23);
            this.btnSetting.TabIndex = 1;
            this.btnSetting.Text = "名单设置";
            this.btnSetting.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnSlot0
            // 
            this.btnSlot0.BackColor = System.Drawing.Color.Transparent;
            this.btnSlot0.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSlot0.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSlot0.Location = new System.Drawing.Point(22, 40);
            this.btnSlot0.Name = "btnSlot0";
            this.btnSlot0.Size = new System.Drawing.Size(75, 22);
            this.btnSlot0.TabIndex = 2;
            this.btnSlot0.TabStop = false;
            this.btnSlot0.Text = "未命名摇号";
            this.btnSlot0.UseVisualStyleBackColor = false;
            this.btnSlot0.Click += new System.EventHandler(this.btnSlot0_Click);
            // 
            // btnSlot1
            // 
            this.btnSlot1.BackColor = System.Drawing.Color.Transparent;
            this.btnSlot1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSlot1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSlot1.Location = new System.Drawing.Point(103, 40);
            this.btnSlot1.Name = "btnSlot1";
            this.btnSlot1.Size = new System.Drawing.Size(75, 22);
            this.btnSlot1.TabIndex = 2;
            this.btnSlot1.TabStop = false;
            this.btnSlot1.Text = "未命名摇号";
            this.btnSlot1.UseVisualStyleBackColor = false;
            this.btnSlot1.Click += new System.EventHandler(this.btnSlot0_Click);
            // 
            // btnSlot2
            // 
            this.btnSlot2.BackColor = System.Drawing.Color.Transparent;
            this.btnSlot2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSlot2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSlot2.Location = new System.Drawing.Point(183, 40);
            this.btnSlot2.Name = "btnSlot2";
            this.btnSlot2.Size = new System.Drawing.Size(75, 22);
            this.btnSlot2.TabIndex = 2;
            this.btnSlot2.TabStop = false;
            this.btnSlot2.Text = "未命名摇号";
            this.btnSlot2.UseVisualStyleBackColor = false;
            this.btnSlot2.Click += new System.EventHandler(this.btnSlot0_Click);
            // 
            // btnSlot3
            // 
            this.btnSlot3.BackColor = System.Drawing.Color.Transparent;
            this.btnSlot3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSlot3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSlot3.Location = new System.Drawing.Point(263, 40);
            this.btnSlot3.Name = "btnSlot3";
            this.btnSlot3.Size = new System.Drawing.Size(75, 22);
            this.btnSlot3.TabIndex = 2;
            this.btnSlot3.TabStop = false;
            this.btnSlot3.Text = "未命名摇号";
            this.btnSlot3.UseVisualStyleBackColor = false;
            this.btnSlot3.Click += new System.EventHandler(this.btnSlot0_Click);
            // 
            // btnSlot4
            // 
            this.btnSlot4.BackColor = System.Drawing.Color.Transparent;
            this.btnSlot4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSlot4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSlot4.Location = new System.Drawing.Point(344, 40);
            this.btnSlot4.Name = "btnSlot4";
            this.btnSlot4.Size = new System.Drawing.Size(75, 22);
            this.btnSlot4.TabIndex = 2;
            this.btnSlot4.TabStop = false;
            this.btnSlot4.Text = "未命名摇号";
            this.btnSlot4.UseVisualStyleBackColor = false;
            this.btnSlot4.Click += new System.EventHandler(this.btnSlot0_Click);
            // 
            // btnSlot5
            // 
            this.btnSlot5.BackColor = System.Drawing.Color.Transparent;
            this.btnSlot5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSlot5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSlot5.Location = new System.Drawing.Point(424, 40);
            this.btnSlot5.Name = "btnSlot5";
            this.btnSlot5.Size = new System.Drawing.Size(75, 22);
            this.btnSlot5.TabIndex = 2;
            this.btnSlot5.TabStop = false;
            this.btnSlot5.Text = "未命名摇号";
            this.btnSlot5.UseVisualStyleBackColor = false;
            this.btnSlot5.Click += new System.EventHandler(this.btnSlot0_Click);
            // 
            // btnSlot6
            // 
            this.btnSlot6.BackColor = System.Drawing.Color.Transparent;
            this.btnSlot6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSlot6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSlot6.Location = new System.Drawing.Point(506, 40);
            this.btnSlot6.Name = "btnSlot6";
            this.btnSlot6.Size = new System.Drawing.Size(75, 22);
            this.btnSlot6.TabIndex = 2;
            this.btnSlot6.TabStop = false;
            this.btnSlot6.Text = "未命名摇号";
            this.btnSlot6.UseVisualStyleBackColor = false;
            this.btnSlot6.Click += new System.EventHandler(this.btnSlot0_Click);
            // 
            // renderTimer
            // 
            this.renderTimer.Enabled = true;
            this.renderTimer.Interval = 1;
            this.renderTimer.Tick += new System.EventHandler(this.renderTimer_Tick);
            // 
            // displayArea
            // 
            this.displayArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.displayArea.ContextMenuStrip = this.contextMenuStrip1;
            this.displayArea.Location = new System.Drawing.Point(22, 65);
            this.displayArea.Name = "displayArea";
            this.displayArea.Size = new System.Drawing.Size(559, 139);
            this.displayArea.TabIndex = 3;
            this.displayArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.displayArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            this.displayArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRemoveCurrent,
            this.btnReload,
            this.toolStripSeparator1,
            this.btnSecurityCheck,
            this.chkHasBgm});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(166, 98);
            // 
            // btnRemoveCurrent
            // 
            this.btnRemoveCurrent.Name = "btnRemoveCurrent";
            this.btnRemoveCurrent.Size = new System.Drawing.Size(165, 22);
            this.btnRemoveCurrent.Text = "移除当前";
            this.btnRemoveCurrent.Click += new System.EventHandler(this.btnRemoveCurrent_Click);
            // 
            // btnReload
            // 
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(165, 22);
            this.btnReload.Text = "重置摇号";
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(162, 6);
            // 
            // btnSecurityCheck
            // 
            this.btnSecurityCheck.Name = "btnSecurityCheck";
            this.btnSecurityCheck.Size = new System.Drawing.Size(165, 22);
            this.btnSecurityCheck.Text = "安全校验";
            this.btnSecurityCheck.Click += new System.EventHandler(this.btnSecurityCheck_Click);
            // 
            // chkHasBgm
            // 
            this.chkHasBgm.CheckOnClick = true;
            this.chkHasBgm.Name = "chkHasBgm";
            this.chkHasBgm.Size = new System.Drawing.Size(165, 22);
            this.chkHasBgm.Text = "开启欢乐的BGM";
            // 
            // areaTopBar
            // 
            this.areaTopBar.BackColor = System.Drawing.Color.Transparent;
            this.areaTopBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.areaTopBar.Location = new System.Drawing.Point(10, 6);
            this.areaTopBar.Name = "areaTopBar";
            this.areaTopBar.Size = new System.Drawing.Size(588, 32);
            this.areaTopBar.TabIndex = 4;
            this.areaTopBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.areaTopBar_MouseDown);
            this.areaTopBar.MouseMove += new System.Windows.Forms.MouseEventHandler(this.areaTopBar_MouseMove);
            this.areaTopBar.MouseUp += new System.Windows.Forms.MouseEventHandler(this.areaTopBar_MouseUp);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Location = new System.Drawing.Point(561, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(34, 34);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // areaFPS
            // 
            this.areaFPS.AutoSize = true;
            this.areaFPS.Location = new System.Drawing.Point(559, 270);
            this.areaFPS.Name = "areaFPS";
            this.areaFPS.Size = new System.Drawing.Size(41, 12);
            this.areaFPS.TabIndex = 6;
            this.areaFPS.Text = "label1";
            // 
            // borderDockTimer
            // 
            this.borderDockTimer.Enabled = true;
            this.borderDockTimer.Interval = 10;
            this.borderDockTimer.Tick += new System.EventHandler(this.borderDockTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::FinanceCryptoCHRJ.Properties.Resources.chrj_bg1;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(604, 262);
            this.Controls.Add(this.areaFPS);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.areaTopBar);
            this.Controls.Add(this.displayArea);
            this.Controls.Add(this.btnSlot6);
            this.Controls.Add(this.btnSlot5);
            this.Controls.Add(this.btnSlot4);
            this.Controls.Add(this.btnSlot3);
            this.Controls.Add(this.btnSlot2);
            this.Controls.Add(this.btnSlot1);
            this.Controls.Add(this.btnSlot0);
            this.Controls.Add(this.btnSetting);
            this.Controls.Add(this.btnStickyRoll);
            this.Controls.Add(this.btnFastRoll);
            this.Controls.Add(this.btnMainRoll);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "金融级安全的抽号软件";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label btnMainRoll;
        private System.Windows.Forms.Label btnFastRoll;
        private System.Windows.Forms.Label btnStickyRoll;
        private System.Windows.Forms.Label btnSetting;
        private System.Windows.Forms.Button btnSlot0;
        private System.Windows.Forms.Button btnSlot1;
        private System.Windows.Forms.Button btnSlot2;
        private System.Windows.Forms.Button btnSlot3;
        private System.Windows.Forms.Button btnSlot4;
        private System.Windows.Forms.Button btnSlot5;
        private System.Windows.Forms.Button btnSlot6;
        private System.Windows.Forms.Timer renderTimer;
        private System.Windows.Forms.Label displayArea;
        private System.Windows.Forms.Label areaTopBar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label areaFPS;
        private System.Windows.Forms.Timer borderDockTimer;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem btnSecurityCheck;
        private System.Windows.Forms.ToolStripMenuItem chkHasBgm;
        private System.Windows.Forms.ToolStripMenuItem btnRemoveCurrent;
        private System.Windows.Forms.ToolStripMenuItem btnReload;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
    }
}

