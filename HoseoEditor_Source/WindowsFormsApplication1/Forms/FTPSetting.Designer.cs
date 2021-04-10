namespace MainFormRichTextBox.Forms
{
    partial class FTPSetting
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
            this.FTP_Txt_Pw = new System.Windows.Forms.TextBox();
            this.FTP_Txt_Id = new System.Windows.Forms.TextBox();
            this.FTP_Txt_Server = new System.Windows.Forms.TextBox();
            this.FTP_Txt_Inf = new System.Windows.Forms.TextBox();
            this.FTP_Lab_Pw = new System.Windows.Forms.Label();
            this.FTP_Lab_Id = new System.Windows.Forms.Label();
            this.FTP_Lab_Server = new System.Windows.Forms.Label();
            this.FTP_Lab_Inf = new System.Windows.Forms.Label();
            this.FTP_Lst_List = new System.Windows.Forms.ListBox();
            this.FTP_Btn_Remove = new System.Windows.Forms.Button();
            this.FTP_Btn_Add = new System.Windows.Forms.Button();
            this.FTP_Btn_No = new System.Windows.Forms.Button();
            this.FTP_Btn_Ok = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FTP_Txt_Pw
            // 
            this.FTP_Txt_Pw.Location = new System.Drawing.Point(12, 147);
            this.FTP_Txt_Pw.Name = "FTP_Txt_Pw";
            this.FTP_Txt_Pw.Size = new System.Drawing.Size(169, 21);
            this.FTP_Txt_Pw.TabIndex = 56;
            this.FTP_Txt_Pw.TextChanged += new System.EventHandler(this.FTP_Txt_Pw_TextChanged);
            // 
            // FTP_Txt_Id
            // 
            this.FTP_Txt_Id.Location = new System.Drawing.Point(12, 109);
            this.FTP_Txt_Id.Name = "FTP_Txt_Id";
            this.FTP_Txt_Id.Size = new System.Drawing.Size(169, 21);
            this.FTP_Txt_Id.TabIndex = 55;
            this.FTP_Txt_Id.TextChanged += new System.EventHandler(this.FTP_Txt_Id_TextChanged);
            // 
            // FTP_Txt_Server
            // 
            this.FTP_Txt_Server.Location = new System.Drawing.Point(12, 70);
            this.FTP_Txt_Server.Name = "FTP_Txt_Server";
            this.FTP_Txt_Server.Size = new System.Drawing.Size(169, 21);
            this.FTP_Txt_Server.TabIndex = 54;
            this.FTP_Txt_Server.TextChanged += new System.EventHandler(this.FTP_Txt_Server_TextChanged);
            // 
            // FTP_Txt_Inf
            // 
            this.FTP_Txt_Inf.Location = new System.Drawing.Point(14, 31);
            this.FTP_Txt_Inf.Name = "FTP_Txt_Inf";
            this.FTP_Txt_Inf.Size = new System.Drawing.Size(169, 21);
            this.FTP_Txt_Inf.TabIndex = 53;
            this.FTP_Txt_Inf.TextChanged += new System.EventHandler(this.FTP_Txt_Inf_TextChanged);
            // 
            // FTP_Lab_Pw
            // 
            this.FTP_Lab_Pw.AutoSize = true;
            this.FTP_Lab_Pw.Location = new System.Drawing.Point(12, 133);
            this.FTP_Lab_Pw.Name = "FTP_Lab_Pw";
            this.FTP_Lab_Pw.Size = new System.Drawing.Size(66, 12);
            this.FTP_Lab_Pw.TabIndex = 51;
            this.FTP_Lab_Pw.Text = "Password:";
            // 
            // FTP_Lab_Id
            // 
            this.FTP_Lab_Id.AutoSize = true;
            this.FTP_Lab_Id.Location = new System.Drawing.Point(12, 94);
            this.FTP_Lab_Id.Name = "FTP_Lab_Id";
            this.FTP_Lab_Id.Size = new System.Drawing.Size(67, 12);
            this.FTP_Lab_Id.TabIndex = 50;
            this.FTP_Lab_Id.Text = "Username:";
            // 
            // FTP_Lab_Server
            // 
            this.FTP_Lab_Server.AutoSize = true;
            this.FTP_Lab_Server.Location = new System.Drawing.Point(12, 55);
            this.FTP_Lab_Server.Name = "FTP_Lab_Server";
            this.FTP_Lab_Server.Size = new System.Drawing.Size(74, 12);
            this.FTP_Lab_Server.TabIndex = 49;
            this.FTP_Lab_Server.Text = "FTP서버(S):";
            // 
            // FTP_Lab_Inf
            // 
            this.FTP_Lab_Inf.AutoSize = true;
            this.FTP_Lab_Inf.Location = new System.Drawing.Point(12, 16);
            this.FTP_Lab_Inf.Name = "FTP_Lab_Inf";
            this.FTP_Lab_Inf.Size = new System.Drawing.Size(51, 12);
            this.FTP_Lab_Inf.TabIndex = 48;
            this.FTP_Lab_Inf.Text = "설명(D):";
            // 
            // FTP_Lst_List
            // 
            this.FTP_Lst_List.FormattingEnabled = true;
            this.FTP_Lst_List.ItemHeight = 12;
            this.FTP_Lst_List.Location = new System.Drawing.Point(517, 126);
            this.FTP_Lst_List.Name = "FTP_Lst_List";
            this.FTP_Lst_List.Size = new System.Drawing.Size(219, 208);
            this.FTP_Lst_List.TabIndex = 47;
            this.FTP_Lst_List.SelectedIndexChanged += new System.EventHandler(this.FTP_Lst_List_SelectedIndexChanged);
            // 
            // FTP_Btn_Remove
            // 
            this.FTP_Btn_Remove.Location = new System.Drawing.Point(615, 81);
            this.FTP_Btn_Remove.Name = "FTP_Btn_Remove";
            this.FTP_Btn_Remove.Size = new System.Drawing.Size(82, 27);
            this.FTP_Btn_Remove.TabIndex = 46;
            this.FTP_Btn_Remove.Text = "제거(R)";
            this.FTP_Btn_Remove.UseVisualStyleBackColor = true;
            this.FTP_Btn_Remove.Click += new System.EventHandler(this.FTP_Btn_Remove_Click);
            // 
            // FTP_Btn_Add
            // 
            this.FTP_Btn_Add.Location = new System.Drawing.Point(527, 81);
            this.FTP_Btn_Add.Name = "FTP_Btn_Add";
            this.FTP_Btn_Add.Size = new System.Drawing.Size(82, 27);
            this.FTP_Btn_Add.TabIndex = 45;
            this.FTP_Btn_Add.Text = "추가";
            this.FTP_Btn_Add.UseVisualStyleBackColor = true;
            this.FTP_Btn_Add.Click += new System.EventHandler(this.FTP_Btn_Add_Click);
            // 
            // FTP_Btn_No
            // 
            this.FTP_Btn_No.Location = new System.Drawing.Point(211, 49);
            this.FTP_Btn_No.Name = "FTP_Btn_No";
            this.FTP_Btn_No.Size = new System.Drawing.Size(82, 27);
            this.FTP_Btn_No.TabIndex = 44;
            this.FTP_Btn_No.Text = "취소";
            this.FTP_Btn_No.UseVisualStyleBackColor = true;
            this.FTP_Btn_No.Click += new System.EventHandler(this.FTP_Btn_No_Click);
            // 
            // FTP_Btn_Ok
            // 
            this.FTP_Btn_Ok.Location = new System.Drawing.Point(211, 16);
            this.FTP_Btn_Ok.Name = "FTP_Btn_Ok";
            this.FTP_Btn_Ok.Size = new System.Drawing.Size(82, 27);
            this.FTP_Btn_Ok.TabIndex = 43;
            this.FTP_Btn_Ok.Text = "확인";
            this.FTP_Btn_Ok.UseVisualStyleBackColor = true;
            this.FTP_Btn_Ok.Click += new System.EventHandler(this.FTP_Btn_Ok_Click);
            // 
            // FTPSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 176);
            this.Controls.Add(this.FTP_Txt_Pw);
            this.Controls.Add(this.FTP_Txt_Id);
            this.Controls.Add(this.FTP_Txt_Server);
            this.Controls.Add(this.FTP_Txt_Inf);
            this.Controls.Add(this.FTP_Lab_Pw);
            this.Controls.Add(this.FTP_Lab_Id);
            this.Controls.Add(this.FTP_Lab_Server);
            this.Controls.Add(this.FTP_Lab_Inf);
            this.Controls.Add(this.FTP_Lst_List);
            this.Controls.Add(this.FTP_Btn_Remove);
            this.Controls.Add(this.FTP_Btn_Add);
            this.Controls.Add(this.FTP_Btn_No);
            this.Controls.Add(this.FTP_Btn_Ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FTPSetting";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FTP 설정";
            this.Load += new System.EventHandler(this.FTPSetting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox FTP_Txt_Pw;
        private System.Windows.Forms.TextBox FTP_Txt_Id;
        private System.Windows.Forms.TextBox FTP_Txt_Server;
        private System.Windows.Forms.TextBox FTP_Txt_Inf;
        private System.Windows.Forms.Label FTP_Lab_Pw;
        private System.Windows.Forms.Label FTP_Lab_Id;
        private System.Windows.Forms.Label FTP_Lab_Server;
        private System.Windows.Forms.Label FTP_Lab_Inf;
        private System.Windows.Forms.ListBox FTP_Lst_List;
        private System.Windows.Forms.Button FTP_Btn_Remove;
        private System.Windows.Forms.Button FTP_Btn_Add;
        private System.Windows.Forms.Button FTP_Btn_No;
        private System.Windows.Forms.Button FTP_Btn_Ok;
    }
}