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
            this.buttonOK.Location = new System.Drawing.Point(99, 180);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(87, 23);
            this.buttonOK.TabIndex = 5;
            this.buttonOK.Text = "确定";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(195, 180);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(87, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "取消";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "표 크기";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(83, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(198, 1);
            this.label2.TabIndex = 3;
            this.label2.Text = " ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "행(&C):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(39, 12);
            this.label4.TabIndex = 5;
            this.label4.Text = "열(&R):";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Location = new System.Drawing.Point(83, 101);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(198, 1);
            this.label5.TabIndex = 7;
            this.label5.Text = " ";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "행 넓이 선택";
            // 
            // radioButtonAutoSzie
            // 
            this.radioButtonAutoSzie.AutoSize = true;
            this.radioButtonAutoSzie.Checked = true;
            this.radioButtonAutoSzie.Location = new System.Drawing.Point(33, 120);
            this.radioButtonAutoSzie.Name = "radioButtonAutoSzie";
            this.radioButtonAutoSzie.Size = new System.Drawing.Size(108, 16);
            this.radioButtonAutoSzie.TabIndex = 2;
            this.radioButtonAutoSzie.TabStop = true;
            this.radioButtonAutoSzie.Text = "자동 행 넓이(&F)";
            this.radioButtonAutoSzie.UseVisualStyleBackColor = true;
            this.radioButtonAutoSzie.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButtonCustomSize
            // 
            this.radioButtonCustomSize.AutoSize = true;
            this.radioButtonCustomSize.Location = new System.Drawing.Point(33, 144);
            this.radioButtonCustomSize.Name = "radioButtonCustomSize";
            this.radioButtonCustomSize.Size = new System.Drawing.Size(107, 16);
            this.radioButtonCustomSize.TabIndex = 3;
            this.radioButtonCustomSize.Text = "사용자 지정(&W)";
            this.radioButtonCustomSize.UseVisualStyleBackColor = true;
            this.radioButtonCustomSize.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // numericUpDownRow
            // 
            this.numericUpDownRow.Location = new System.Drawing.Point(141, 31);
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
            this.numericUpDownRow.Size = new System.Drawing.Size(140, 21);
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
            this.numericUpDownColumn.Location = new System.Drawing.Point(141, 58);
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
            this.numericUpDownColumn.Size = new System.Drawing.Size(140, 21);
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
            this.numericUpDownCellWidth.Location = new System.Drawing.Point(141, 142);
            this.numericUpDownCellWidth.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownCellWidth.Name = "numericUpDownCellWidth";
            this.numericUpDownCellWidth.Size = new System.Drawing.Size(99, 21);
            this.numericUpDownCellWidth.TabIndex = 4;
            this.numericUpDownCellWidth.Enter += new System.EventHandler(this.numericUpDownCellWidth_Enter);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(248, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 12);
            this.label7.TabIndex = 13;
            this.label7.Text = "mm";
            // 
            // richTextBoxTableDlg
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(296, 208);
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
            this.Text = "표 삽입";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.richTextBoxTableDlg_FormClosed);
            this.Load += new System.EventHandler(this.richTextBoxTableDlg_Load);
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