namespace FinanceCryptoCHRJ
{
    partial class FrmEdit
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.chkPy = new System.Windows.Forms.CheckBox();
            this.cmbSelection = new System.Windows.Forms.ComboBox();
            this.tblList = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBatchAdd = new System.Windows.Forms.Button();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPYJY = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.tblList)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "名单标题";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(73, 38);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(191, 20);
            this.txtTitle.TabIndex = 1;
            // 
            // chkPy
            // 
            this.chkPy.AutoSize = true;
            this.chkPy.Location = new System.Drawing.Point(13, 584);
            this.chkPy.Name = "chkPy";
            this.chkPy.Size = new System.Drawing.Size(100, 17);
            this.chkPy.TabIndex = 2;
            this.chkPy.TabStop = false;
            this.chkPy.Text = "隐藏的PY交易";
            this.chkPy.UseVisualStyleBackColor = true;
            this.chkPy.CheckedChanged += new System.EventHandler(this.chkPy_CheckedChanged);
            // 
            // cmbSelection
            // 
            this.cmbSelection.FormattingEnabled = true;
            this.cmbSelection.Location = new System.Drawing.Point(15, 11);
            this.cmbSelection.Name = "cmbSelection";
            this.cmbSelection.Size = new System.Drawing.Size(249, 21);
            this.cmbSelection.TabIndex = 3;
            // 
            // tblList
            // 
            this.tblList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tblList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.ColumnPYJY});
            this.tblList.Location = new System.Drawing.Point(15, 67);
            this.tblList.Name = "tblList";
            this.tblList.Size = new System.Drawing.Size(249, 237);
            this.tblList.TabIndex = 4;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(87, 311);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(177, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnBatchAdd
            // 
            this.btnBatchAdd.Location = new System.Drawing.Point(15, 311);
            this.btnBatchAdd.Name = "btnBatchAdd";
            this.btnBatchAdd.Size = new System.Drawing.Size(66, 23);
            this.btnBatchAdd.TabIndex = 6;
            this.btnBatchAdd.Text = "批量添加";
            this.btnBatchAdd.UseVisualStyleBackColor = true;
            // 
            // ColumnName
            // 
            this.ColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnName.HeaderText = "名称";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnPYJY
            // 
            this.ColumnPYJY.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnPYJY.FillWeight = 40F;
            this.ColumnPYJY.HeaderText = "抽不到";
            this.ColumnPYJY.Name = "ColumnPYJY";
            this.ColumnPYJY.Visible = false;
            // 
            // FrmEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(277, 345);
            this.Controls.Add(this.btnBatchAdd);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tblList);
            this.Controls.Add(this.cmbSelection);
            this.Controls.Add(this.chkPy);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximumSize = new System.Drawing.Size(293, 652);
            this.MinimumSize = new System.Drawing.Size(293, 384);
            this.Name = "FrmEdit";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "编辑名单";
            this.Load += new System.EventHandler(this.FrmEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tblList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.CheckBox chkPy;
        private System.Windows.Forms.ComboBox cmbSelection;
        private System.Windows.Forms.DataGridView tblList;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnBatchAdd;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnPYJY;
    }
}