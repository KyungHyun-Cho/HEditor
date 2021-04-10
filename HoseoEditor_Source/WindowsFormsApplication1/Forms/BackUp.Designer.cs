namespace MainFormRichTextBox.Forms
{
    partial class BackUp
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
            this.BackUp_Chk_DateTime = new System.Windows.Forms.CheckBox();
            this.BackUp_Chk_DirName = new System.Windows.Forms.CheckBox();
            this.BackUp_Chk_FarFile = new System.Windows.Forms.CheckBox();
            this.BackUp_Btn_No = new System.Windows.Forms.Button();
            this.BackUp_Btn_Ok = new System.Windows.Forms.Button();
            this.BackUp_Btn_Load = new System.Windows.Forms.Button();
            this.BackUp_Txt_FileEx = new System.Windows.Forms.TextBox();
            this.BackUp_Txt_Directory = new System.Windows.Forms.TextBox();
            this.BackUp_Lab_FileEx = new System.Windows.Forms.Label();
            this.BackUp_Lab_Directory = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BackUp_Chk_DateTime
            // 
            this.BackUp_Chk_DateTime.AutoSize = true;
            this.BackUp_Chk_DateTime.Location = new System.Drawing.Point(156, 97);
            this.BackUp_Chk_DateTime.Name = "BackUp_Chk_DateTime";
            this.BackUp_Chk_DateTime.Size = new System.Drawing.Size(116, 16);
            this.BackUp_Chk_DateTime.TabIndex = 27;
            this.BackUp_Chk_DateTime.Text = "날짜와 시간 포함";
            this.BackUp_Chk_DateTime.UseVisualStyleBackColor = true;
            // 
            // BackUp_Chk_DirName
            // 
            this.BackUp_Chk_DirName.AutoSize = true;
            this.BackUp_Chk_DirName.Location = new System.Drawing.Point(12, 97);
            this.BackUp_Chk_DirName.Name = "BackUp_Chk_DirName";
            this.BackUp_Chk_DirName.Size = new System.Drawing.Size(128, 16);
            this.BackUp_Chk_DirName.TabIndex = 26;
            this.BackUp_Chk_DirName.Text = "디렉토리 이름 포함";
            this.BackUp_Chk_DirName.UseVisualStyleBackColor = true;
            // 
            // BackUp_Chk_FarFile
            // 
            this.BackUp_Chk_FarFile.AutoSize = true;
            this.BackUp_Chk_FarFile.Location = new System.Drawing.Point(12, 75);
            this.BackUp_Chk_FarFile.Name = "BackUp_Chk_FarFile";
            this.BackUp_Chk_FarFile.Size = new System.Drawing.Size(260, 16);
            this.BackUp_Chk_FarFile.TabIndex = 25;
            this.BackUp_Chk_FarFile.Text = "백업 디렉토리에 원격파일의 백업 파일 생성";
            this.BackUp_Chk_FarFile.UseVisualStyleBackColor = true;
            // 
            // BackUp_Btn_No
            // 
            this.BackUp_Btn_No.Location = new System.Drawing.Point(419, 38);
            this.BackUp_Btn_No.Name = "BackUp_Btn_No";
            this.BackUp_Btn_No.Size = new System.Drawing.Size(87, 22);
            this.BackUp_Btn_No.TabIndex = 24;
            this.BackUp_Btn_No.Text = "취소";
            this.BackUp_Btn_No.UseVisualStyleBackColor = true;
            this.BackUp_Btn_No.Click += new System.EventHandler(this.BackUp_Btn_No_Click);
            // 
            // BackUp_Btn_Ok
            // 
            this.BackUp_Btn_Ok.Location = new System.Drawing.Point(419, 10);
            this.BackUp_Btn_Ok.Name = "BackUp_Btn_Ok";
            this.BackUp_Btn_Ok.Size = new System.Drawing.Size(87, 22);
            this.BackUp_Btn_Ok.TabIndex = 23;
            this.BackUp_Btn_Ok.Text = "확인";
            this.BackUp_Btn_Ok.UseVisualStyleBackColor = true;
            this.BackUp_Btn_Ok.Click += new System.EventHandler(this.BackUp_Btn_Ok_Click);
            // 
            // BackUp_Btn_Load
            // 
            this.BackUp_Btn_Load.Location = new System.Drawing.Point(388, 8);
            this.BackUp_Btn_Load.Name = "BackUp_Btn_Load";
            this.BackUp_Btn_Load.Size = new System.Drawing.Size(25, 25);
            this.BackUp_Btn_Load.TabIndex = 19;
            this.BackUp_Btn_Load.Text = "...";
            this.BackUp_Btn_Load.UseVisualStyleBackColor = true;
            // 
            // BackUp_Txt_FileEx
            // 
            this.BackUp_Txt_FileEx.Location = new System.Drawing.Point(149, 38);
            this.BackUp_Txt_FileEx.Name = "BackUp_Txt_FileEx";
            this.BackUp_Txt_FileEx.Size = new System.Drawing.Size(233, 21);
            this.BackUp_Txt_FileEx.TabIndex = 21;
            // 
            // BackUp_Txt_Directory
            // 
            this.BackUp_Txt_Directory.Location = new System.Drawing.Point(149, 12);
            this.BackUp_Txt_Directory.Name = "BackUp_Txt_Directory";
            this.BackUp_Txt_Directory.Size = new System.Drawing.Size(233, 21);
            this.BackUp_Txt_Directory.TabIndex = 22;
            // 
            // BackUp_Lab_FileEx
            // 
            this.BackUp_Lab_FileEx.AutoSize = true;
            this.BackUp_Lab_FileEx.Location = new System.Drawing.Point(23, 43);
            this.BackUp_Lab_FileEx.Name = "BackUp_Lab_FileEx";
            this.BackUp_Lab_FileEx.Size = new System.Drawing.Size(101, 12);
            this.BackUp_Lab_FileEx.TabIndex = 20;
            this.BackUp_Lab_FileEx.Text = "백업 파일 확장자:";
            // 
            // BackUp_Lab_Directory
            // 
            this.BackUp_Lab_Directory.AutoSize = true;
            this.BackUp_Lab_Directory.Location = new System.Drawing.Point(39, 15);
            this.BackUp_Lab_Directory.Name = "BackUp_Lab_Directory";
            this.BackUp_Lab_Directory.Size = new System.Drawing.Size(85, 12);
            this.BackUp_Lab_Directory.TabIndex = 18;
            this.BackUp_Lab_Directory.Text = "백업 디렉토리:";
            // 
            // BackUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(515, 119);
            this.Controls.Add(this.BackUp_Chk_DateTime);
            this.Controls.Add(this.BackUp_Chk_DirName);
            this.Controls.Add(this.BackUp_Chk_FarFile);
            this.Controls.Add(this.BackUp_Btn_No);
            this.Controls.Add(this.BackUp_Btn_Ok);
            this.Controls.Add(this.BackUp_Btn_Load);
            this.Controls.Add(this.BackUp_Txt_FileEx);
            this.Controls.Add(this.BackUp_Txt_Directory);
            this.Controls.Add(this.BackUp_Lab_FileEx);
            this.Controls.Add(this.BackUp_Lab_Directory);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BackUp";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "백업 설정";
            this.Load += new System.EventHandler(this.BackUp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox BackUp_Chk_DateTime;
        private System.Windows.Forms.CheckBox BackUp_Chk_DirName;
        private System.Windows.Forms.CheckBox BackUp_Chk_FarFile;
        private System.Windows.Forms.Button BackUp_Btn_No;
        private System.Windows.Forms.Button BackUp_Btn_Ok;
        private System.Windows.Forms.Button BackUp_Btn_Load;
        private System.Windows.Forms.TextBox BackUp_Txt_FileEx;
        private System.Windows.Forms.TextBox BackUp_Txt_Directory;
        private System.Windows.Forms.Label BackUp_Lab_FileEx;
        private System.Windows.Forms.Label BackUp_Lab_Directory;
    }
}