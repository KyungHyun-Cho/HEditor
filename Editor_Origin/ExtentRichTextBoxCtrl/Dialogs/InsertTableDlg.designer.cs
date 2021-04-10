namespace System.Windows.Forms
{
    partial class richTextBoxTableDlg
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.radioButtonAutoSzie = new System.Windows.Forms.RadioButton();
            this.radioButtonCustomSize = new System.Windows.Forms.RadioButton();
            this.numericUpDownRow = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownColumn = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCellWidth = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColumn)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCellWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(85, 180);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
 
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(167, 180);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "表格尺寸";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(71, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 1);
            this.label2.TabIndex = 3;
            this.label2.Text = " ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "列数(&C):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "行数(&R):";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(71, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(170, 1);
            this.label5.TabIndex = 7;
            this.label5.Text = " ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "列宽选择";
            // 
            // radioButtonAutoSzie
            // 
            this.radioButtonAutoSzie.AutoSize = true;
            this.radioButtonAutoSzie.Checked = true;
            this.radioButtonAutoSzie.Location = new System.Drawing.Point(28, 120);
            this.radioButtonAutoSzie.Name = "radioButtonAutoSzie";
            this.radioButtonAutoSzie.Size = new System.Drawing.Size(89, 16);
            this.radioButtonAutoSzie.TabIndex = 2;
            this.radioButtonAutoSzie.TabStop = true;
            this.radioButtonAutoSzie.Text = "自动列宽(&F)";
            this.radioButtonAutoSzie.UseVisualStyleBackColor = true;
            this.radioButtonAutoSzie.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButtonCustomSize
            // 
            this.radioButtonCustomSize.AutoSize = true;
            this.radioButtonCustomSize.Location = new System.Drawing.Point(28, 144);
            this.radioButtonCustomSize.Name = "radioButtonCustomSize";
            this.radioButtonCustomSize.Size = new System.Drawing.Size(89, 16);
            this.radioButtonCustomSize.TabIndex = 3;
            this.radioButtonCustomSize.Text = "固定列宽(&W)";
            this.radioButtonCustomSize.UseVisualStyleBackColor = true;
            this.radioButtonCustomSize.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // numericUpDownRow
            // 
            this.numericUpDownRow.Location = new System.Drawing.Point(121, 31);
            this.numericUpDownRow.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownRow.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownRow.Name = "numericUpDownRow";
            this.numericUpDownRow.Size = new System.Drawing.Size(120, 21);
            this.numericUpDownRow.TabIndex = 0;
            this.numericUpDownRow.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownRow.Enter += new System.EventHandler(this.numericUpDownRow_Enter);
            // 
            // numericUpDownColumn
            // 
            this.numericUpDownColumn.Location = new System.Drawing.Point(121, 58);
            this.numericUpDownColumn.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownColumn.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownColumn.Name = "numericUpDownColumn";
            this.numericUpDownColumn.Size = new System.Drawing.Size(120, 21);
            this.numericUpDownColumn.TabIndex = 1;
            this.numericUpDownColumn.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownColumn.Enter += new System.EventHandler(this.numericUpDownColumn_Enter);
            // 
            // numericUpDownCellWidth
            // 
            this.numericUpDownCellWidth.Enabled = false;
            this.numericUpDownCellWidth.Location = new System.Drawing.Point(121, 142);
            this.numericUpDownCellWidth.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownCellWidth.Name = "numericUpDownCellWidth";
            this.numericUpDownCellWidth.Size = new System.Drawing.Size(85, 21);
            this.numericUpDownCellWidth.TabIndex = 4;
            this.numericUpDownCellWidth.Enter += new System.EventHandler(this.numericUpDownCellWidth_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(213, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "毫米";
            // 
            // richTextBoxTableDlg
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(254, 208);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.numericUpDownCellWidth);
            this.Controls.Add(this.numericUpDownColumn);
            this.Controls.Add(this.numericUpDownRow);
            this.Controls.Add(this.radioButtonCustomSize);
            this.Controls.Add(this.radioButtonAutoSzie);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "richTextBoxTableDlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "插入表格";
            this.Load += new System.EventHandler(this.richTextBoxTableDlg_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.richTextBoxTableDlg_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownColumn)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCellWidth)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton radioButtonCustomSize;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.RadioButton radioButtonAutoSzie;
        public System.Windows.Forms.NumericUpDown numericUpDownRow;
        public System.Windows.Forms.NumericUpDown numericUpDownColumn;
        public System.Windows.Forms.NumericUpDown numericUpDownCellWidth;
    }
}