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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnSlot0 = new System.Windows.Forms.Button();
            this.btnSlot1 = new System.Windows.Forms.Button();
            this.btnSlot2 = new System.Windows.Forms.Button();
            this.btnSlot3 = new System.Windows.Forms.Button();
            this.btnSlot4 = new System.Windows.Forms.Button();
            this.btnSlot5 = new System.Windows.Forms.Button();
            this.btnSlot6 = new System.Windows.Forms.Button();
            this.renderTimer = new System.Windows.Forms.Timer(this.components);
            this.canvas = new System.Windows.Forms.Label();
            this.areaTopBar = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.areaFPS = new System.Windows.Forms.Label();
            this.borderDockTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnMainRoll
            // 
            this.btnMainRoll.BackColor = System.Drawing.Color.Transparent;
            this.btnMainRoll.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMainRoll.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMainRoll.ForeColor = System.Drawing.Color.White;
            this.btnMainRoll.Location = new System.Drawing.Point(15, 210);
            this.btnMainRoll.Name = "btnMainRoll";
            this.btnMainRoll.Size = new System.Drawing.Size(253, 23);
            this.btnMainRoll.TabIndex = 1;
            this.btnMainRoll.Text = "按住开始摇号";
            this.btnMainRoll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnMainRoll.Click += new System.EventHandler(this.btnMainRoll_Click);
            this.btnMainRoll.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnMainRoll_MouseDown);
            this.btnMainRoll.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnMainRoll_MouseUp);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(285, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 23);
            this.label2.TabIndex = 1;
            this.label2.Text = "快速摇号";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(386, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 23);
            this.label3.TabIndex = 1;
            this.label3.Text = "炫迈摇号";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(486, 210);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 23);
            this.label4.TabIndex = 1;
            this.label4.Text = "名单设置";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSlot0
            // 
            this.btnSlot0.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSlot0.Location = new System.Drawing.Point(12, 33);
            this.btnSlot0.Name = "btnSlot0";
            this.btnSlot0.Size = new System.Drawing.Size(75, 23);
            this.btnSlot0.TabIndex = 2;
            this.btnSlot0.TabStop = false;
            this.btnSlot0.Text = "未命名摇号";
            this.btnSlot0.UseVisualStyleBackColor = true;
            // 
            // btnSlot1
            // 
            this.btnSlot1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSlot1.Location = new System.Drawing.Point(93, 33);
            this.btnSlot1.Name = "btnSlot1";
            this.btnSlot1.Size = new System.Drawing.Size(75, 23);
            this.btnSlot1.TabIndex = 2;
            this.btnSlot1.TabStop = false;
            this.btnSlot1.Text = "未命名摇号";
            this.btnSlot1.UseVisualStyleBackColor = true;
            // 
            // btnSlot2
            // 
            this.btnSlot2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSlot2.Location = new System.Drawing.Point(174, 33);
            this.btnSlot2.Name = "btnSlot2";
            this.btnSlot2.Size = new System.Drawing.Size(75, 23);
            this.btnSlot2.TabIndex = 2;
            this.btnSlot2.TabStop = false;
            this.btnSlot2.Text = "未命名摇号";
            this.btnSlot2.UseVisualStyleBackColor = true;
            // 
            // btnSlot3
            // 
            this.btnSlot3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSlot3.Location = new System.Drawing.Point(255, 33);
            this.btnSlot3.Name = "btnSlot3";
            this.btnSlot3.Size = new System.Drawing.Size(75, 23);
            this.btnSlot3.TabIndex = 2;
            this.btnSlot3.TabStop = false;
            this.btnSlot3.Text = "未命名摇号";
            this.btnSlot3.UseVisualStyleBackColor = true;
            // 
            // btnSlot4
            // 
            this.btnSlot4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSlot4.Location = new System.Drawing.Point(336, 33);
            this.btnSlot4.Name = "btnSlot4";
            this.btnSlot4.Size = new System.Drawing.Size(75, 23);
            this.btnSlot4.TabIndex = 2;
            this.btnSlot4.TabStop = false;
            this.btnSlot4.Text = "未命名摇号";
            this.btnSlot4.UseVisualStyleBackColor = true;
            // 
            // btnSlot5
            // 
            this.btnSlot5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSlot5.Location = new System.Drawing.Point(417, 33);
            this.btnSlot5.Name = "btnSlot5";
            this.btnSlot5.Size = new System.Drawing.Size(75, 23);
            this.btnSlot5.TabIndex = 2;
            this.btnSlot5.TabStop = false;
            this.btnSlot5.Text = "未命名摇号";
            this.btnSlot5.UseVisualStyleBackColor = true;
            // 
            // btnSlot6
            // 
            this.btnSlot6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSlot6.Location = new System.Drawing.Point(498, 33);
            this.btnSlot6.Name = "btnSlot6";
            this.btnSlot6.Size = new System.Drawing.Size(75, 23);
            this.btnSlot6.TabIndex = 2;
            this.btnSlot6.TabStop = false;
            this.btnSlot6.Text = "未命名摇号";
            this.btnSlot6.UseVisualStyleBackColor = true;
            // 
            // renderTimer
            // 
            this.renderTimer.Enabled = true;
            this.renderTimer.Interval = 1;
            this.renderTimer.Tick += new System.EventHandler(this.renderTimer_Tick);
            // 
            // canvas
            // 
            this.canvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.canvas.Location = new System.Drawing.Point(12, 66);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(561, 130);
            this.canvas.TabIndex = 3;
            this.canvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseDown);
            this.canvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseMove);
            this.canvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseUp);
            // 
            // areaTopBar
            // 
            this.areaTopBar.BackColor = System.Drawing.Color.Transparent;
            this.areaTopBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.areaTopBar.Location = new System.Drawing.Point(0, -2);
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
            this.button1.Location = new System.Drawing.Point(560, -2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(27, 34);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // areaFPS
            // 
            this.areaFPS.AutoSize = true;
            this.areaFPS.Location = new System.Drawing.Point(495, 9);
            this.areaFPS.Name = "areaFPS";
            this.areaFPS.Size = new System.Drawing.Size(35, 13);
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
            this.ClientSize = new System.Drawing.Size(587, 250);
            this.Controls.Add(this.areaFPS);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.areaTopBar);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.btnSlot6);
            this.Controls.Add(this.btnSlot5);
            this.Controls.Add(this.btnSlot4);
            this.Controls.Add(this.btnSlot3);
            this.Controls.Add(this.btnSlot2);
            this.Controls.Add(this.btnSlot1);
            this.Controls.Add(this.btnSlot0);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
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
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label btnMainRoll;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnSlot0;
        private System.Windows.Forms.Button btnSlot1;
        private System.Windows.Forms.Button btnSlot2;
        private System.Windows.Forms.Button btnSlot3;
        private System.Windows.Forms.Button btnSlot4;
        private System.Windows.Forms.Button btnSlot5;
        private System.Windows.Forms.Button btnSlot6;
        private System.Windows.Forms.Timer renderTimer;
        private System.Windows.Forms.Label canvas;
        private System.Windows.Forms.Label areaTopBar;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label areaFPS;
        private System.Windows.Forms.Timer borderDockTimer;
    }
}

