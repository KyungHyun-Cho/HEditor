namespace MainFormRichTextBox.Forms
{
    partial class GeneralSetting
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
            this.Btn_No = new System.Windows.Forms.Button();
            this.Set_Lab_FileExp = new System.Windows.Forms.Label();
            this.Set_Btn_Remove = new System.Windows.Forms.Button();
            this.Set_Btn_Add = new System.Windows.Forms.Button();
            this.Set_Lst_FileSort = new System.Windows.Forms.ListBox();
            this.Set_Lab_FileSort = new System.Windows.Forms.Label();
            this.Gbx_File = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BackUp_Txt_Time = new System.Windows.Forms.TextBox();
            this.BackUp_Chk_FormClose = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.BackUp_Chk_Open = new System.Windows.Forms.CheckBox();
            this.BackUp_Chk_DateTime = new System.Windows.Forms.CheckBox();
            this.BackUp_Chk_DirName = new System.Windows.Forms.CheckBox();
            this.BackUp_Chk_FTPFile = new System.Windows.Forms.CheckBox();
            this.BackUp_Btn_Load = new System.Windows.Forms.Button();
            this.BackUp_Txt_FileEx = new System.Windows.Forms.TextBox();
            this.BackUp_Txt_Directory = new System.Windows.Forms.TextBox();
            this.BackUp_Lab_FileEx = new System.Windows.Forms.Label();
            this.BackUp_Lab_Directory = new System.Windows.Forms.Label();
            this.BackUp_Chk_Save = new System.Windows.Forms.CheckBox();
            this.File_Cbx_BasicEncode = new System.Windows.Forms.ComboBox();
            this.File_Lab_BasicEncode = new System.Windows.Forms.Label();
            this.File_Txt_Time = new System.Windows.Forms.TextBox();
            this.File_Lab_AutoSave = new System.Windows.Forms.Label();
            this.Set_Txt_FileExp = new System.Windows.Forms.TextBox();
            this.Btn_OK = new System.Windows.Forms.Button();
            this.Lab_Sort = new System.Windows.Forms.Label();
            this.Lst_Sort = new System.Windows.Forms.ListBox();
            this.Btn_Adjust = new System.Windows.Forms.Button();
            this.Color_Chk_List = new System.Windows.Forms.ListBox();
            this.Gbx_Template = new System.Windows.Forms.GroupBox();
            this.Template_Lab_Temp = new System.Windows.Forms.Label();
            this.Template_Btn_Open = new System.Windows.Forms.Button();
            this.Template_Btn_Load = new System.Windows.Forms.Button();
            this.Template_Txt_File = new System.Windows.Forms.TextBox();
            this.Template_Txt_Menu = new System.Windows.Forms.TextBox();
            this.Template_Lab_File = new System.Windows.Forms.Label();
            this.Template_Lab_Menu = new System.Windows.Forms.Label();
            this.Template_Btn_Return = new System.Windows.Forms.Button();
            this.Template_Btn_Down = new System.Windows.Forms.Button();
            this.Template_Btn_Up = new System.Windows.Forms.Button();
            this.Template_Btn_Remove = new System.Windows.Forms.Button();
            this.Template_Btn_Add = new System.Windows.Forms.Button();
            this.Template_Lst_Temp = new System.Windows.Forms.ListBox();
            this.SettingTab2 = new System.Windows.Forms.TabPage();
            this.btn_Color_Apply = new System.Windows.Forms.Button();
            this.PreviewColor = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ColorPicker = new OfficePickers.ColorPicker.ComboBoxColorPicker();
            this.Gbx_Set = new System.Windows.Forms.GroupBox();
            this.Set_Tab_SetHigh = new System.Windows.Forms.TabControl();
            this.SettingTab1 = new System.Windows.Forms.TabPage();
            this.GenHighlight_Chk_NoGap = new System.Windows.Forms.CheckBox();
            this.GenHighlight_Cbx_Encoding = new System.Windows.Forms.ComboBox();
            this.GenHighlight_Lab_Syntax = new System.Windows.Forms.Label();
            this.GenHighlight_Txt_Syntax = new System.Windows.Forms.TextBox();
            this.GenHighlight_Btn_Load = new System.Windows.Forms.Button();
            this.GenHighlight_Lab_Encoding = new System.Windows.Forms.Label();
            this.GenHighlight_Btn_Open1 = new System.Windows.Forms.Button();
            this.CD = new System.Windows.Forms.OpenFileDialog();
            this.Gbx_File.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Gbx_Template.SuspendLayout();
            this.SettingTab2.SuspendLayout();
            this.Gbx_Set.SuspendLayout();
            this.Set_Tab_SetHigh.SuspendLayout();
            this.SettingTab1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Btn_No
            // 
            this.Btn_No.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Btn_No.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Btn_No.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Btn_No.Location = new System.Drawing.Point(457, 336);
            this.Btn_No.Name = "Btn_No";
            this.Btn_No.Size = new System.Drawing.Size(82, 33);
            this.Btn_No.TabIndex = 25;
            this.Btn_No.Text = "취소";
            this.Btn_No.UseVisualStyleBackColor = false;
            this.Btn_No.Click += new System.EventHandler(this.Btn_No_Click);
            // 
            // Set_Lab_FileExp
            // 
            this.Set_Lab_FileExp.AutoSize = true;
            this.Set_Lab_FileExp.Location = new System.Drawing.Point(8, 105);
            this.Set_Lab_FileExp.Name = "Set_Lab_FileExp";
            this.Set_Lab_FileExp.Size = new System.Drawing.Size(69, 12);
            this.Set_Lab_FileExp.TabIndex = 6;
            this.Set_Lab_FileExp.Text = "파일확장자:";
            // 
            // Set_Btn_Remove
            // 
            this.Set_Btn_Remove.Location = new System.Drawing.Point(318, 62);
            this.Set_Btn_Remove.Name = "Set_Btn_Remove";
            this.Set_Btn_Remove.Size = new System.Drawing.Size(90, 23);
            this.Set_Btn_Remove.TabIndex = 3;
            this.Set_Btn_Remove.Text = "제거(R)";
            this.Set_Btn_Remove.UseVisualStyleBackColor = true;
            this.Set_Btn_Remove.Click += new System.EventHandler(this.Set_Btn_Remove_Click);
            // 
            // Set_Btn_Add
            // 
            this.Set_Btn_Add.Location = new System.Drawing.Point(318, 33);
            this.Set_Btn_Add.Name = "Set_Btn_Add";
            this.Set_Btn_Add.Size = new System.Drawing.Size(90, 24);
            this.Set_Btn_Add.TabIndex = 2;
            this.Set_Btn_Add.Text = "추가(D)...";
            this.Set_Btn_Add.UseVisualStyleBackColor = true;
            this.Set_Btn_Add.Click += new System.EventHandler(this.Set_Btn_Add_Click);
            // 
            // Set_Lst_FileSort
            // 
            this.Set_Lst_FileSort.FormattingEnabled = true;
            this.Set_Lst_FileSort.ItemHeight = 12;
            this.Set_Lst_FileSort.Location = new System.Drawing.Point(10, 33);
            this.Set_Lst_FileSort.Name = "Set_Lst_FileSort";
            this.Set_Lst_FileSort.Size = new System.Drawing.Size(302, 64);
            this.Set_Lst_FileSort.TabIndex = 1;
            this.Set_Lst_FileSort.SelectedIndexChanged += new System.EventHandler(this.Set_Lst_FileSort_SelectedIndexChanged);
            // 
            // Set_Lab_FileSort
            // 
            this.Set_Lab_FileSort.AutoSize = true;
            this.Set_Lab_FileSort.Location = new System.Drawing.Point(8, 17);
            this.Set_Lab_FileSort.Name = "Set_Lab_FileSort";
            this.Set_Lab_FileSort.Size = new System.Drawing.Size(75, 12);
            this.Set_Lab_FileSort.TabIndex = 0;
            this.Set_Lab_FileSort.Text = "파일 종류(E)";
            // 
            // Gbx_File
            // 
            this.Gbx_File.Controls.Add(this.groupBox1);
            this.Gbx_File.Controls.Add(this.File_Cbx_BasicEncode);
            this.Gbx_File.Controls.Add(this.File_Lab_BasicEncode);
            this.Gbx_File.Controls.Add(this.File_Txt_Time);
            this.Gbx_File.Controls.Add(this.File_Lab_AutoSave);
            this.Gbx_File.Location = new System.Drawing.Point(636, 10);
            this.Gbx_File.Name = "Gbx_File";
            this.Gbx_File.Size = new System.Drawing.Size(423, 320);
            this.Gbx_File.TabIndex = 20;
            this.Gbx_File.TabStop = false;
            this.Gbx_File.Text = "File";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BackUp_Txt_Time);
            this.groupBox1.Controls.Add(this.BackUp_Chk_FormClose);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.BackUp_Chk_Open);
            this.groupBox1.Controls.Add(this.BackUp_Chk_DateTime);
            this.groupBox1.Controls.Add(this.BackUp_Chk_DirName);
            this.groupBox1.Controls.Add(this.BackUp_Chk_FTPFile);
            this.groupBox1.Controls.Add(this.BackUp_Btn_Load);
            this.groupBox1.Controls.Add(this.BackUp_Txt_FileEx);
            this.groupBox1.Controls.Add(this.BackUp_Txt_Directory);
            this.groupBox1.Controls.Add(this.BackUp_Lab_FileEx);
            this.groupBox1.Controls.Add(this.BackUp_Lab_Directory);
            this.groupBox1.Controls.Add(this.BackUp_Chk_Save);
            this.groupBox1.Location = new System.Drawing.Point(8, 87);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(397, 207);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "백업 옵션";
            // 
            // BackUp_Txt_Time
            // 
            this.BackUp_Txt_Time.Location = new System.Drawing.Point(126, 20);
            this.BackUp_Txt_Time.Name = "BackUp_Txt_Time";
            this.BackUp_Txt_Time.Size = new System.Drawing.Size(72, 21);
            this.BackUp_Txt_Time.TabIndex = 15;
            // 
            // BackUp_Chk_FormClose
            // 
            this.BackUp_Chk_FormClose.AutoSize = true;
            this.BackUp_Chk_FormClose.Location = new System.Drawing.Point(18, 185);
            this.BackUp_Chk_FormClose.Name = "BackUp_Chk_FormClose";
            this.BackUp_Chk_FormClose.Size = new System.Drawing.Size(332, 16);
            this.BackUp_Chk_FormClose.TabIndex = 38;
            this.BackUp_Chk_FormClose.Text = "폼이 닫힐 때 저장되지 않은 파일에 대해서 백업파일 생성";
            this.BackUp_Chk_FormClose.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 12);
            this.label2.TabIndex = 14;
            this.label2.Text = "자동 백업 간격 (초):";
            // 
            // BackUp_Chk_Open
            // 
            this.BackUp_Chk_Open.AutoSize = true;
            this.BackUp_Chk_Open.Location = new System.Drawing.Point(18, 144);
            this.BackUp_Chk_Open.Name = "BackUp_Chk_Open";
            this.BackUp_Chk_Open.Size = new System.Drawing.Size(144, 16);
            this.BackUp_Chk_Open.TabIndex = 36;
            this.BackUp_Chk_Open.Text = "오픈시 백업 파일 생성";
            this.BackUp_Chk_Open.UseVisualStyleBackColor = true;
            // 
            // BackUp_Chk_DateTime
            // 
            this.BackUp_Chk_DateTime.AutoSize = true;
            this.BackUp_Chk_DateTime.Location = new System.Drawing.Point(158, 99);
            this.BackUp_Chk_DateTime.Name = "BackUp_Chk_DateTime";
            this.BackUp_Chk_DateTime.Size = new System.Drawing.Size(116, 16);
            this.BackUp_Chk_DateTime.TabIndex = 35;
            this.BackUp_Chk_DateTime.Text = "날짜와 시간 포함";
            this.BackUp_Chk_DateTime.UseVisualStyleBackColor = true;
            // 
            // BackUp_Chk_DirName
            // 
            this.BackUp_Chk_DirName.AutoSize = true;
            this.BackUp_Chk_DirName.Location = new System.Drawing.Point(18, 100);
            this.BackUp_Chk_DirName.Name = "BackUp_Chk_DirName";
            this.BackUp_Chk_DirName.Size = new System.Drawing.Size(128, 16);
            this.BackUp_Chk_DirName.TabIndex = 34;
            this.BackUp_Chk_DirName.Text = "디렉토리 이름 포함";
            this.BackUp_Chk_DirName.UseVisualStyleBackColor = true;
            // 
            // BackUp_Chk_FTPFile
            // 
            this.BackUp_Chk_FTPFile.AutoSize = true;
            this.BackUp_Chk_FTPFile.Location = new System.Drawing.Point(18, 122);
            this.BackUp_Chk_FTPFile.Name = "BackUp_Chk_FTPFile";
            this.BackUp_Chk_FTPFile.Size = new System.Drawing.Size(260, 16);
            this.BackUp_Chk_FTPFile.TabIndex = 33;
            this.BackUp_Chk_FTPFile.Text = "백업 디렉토리에 원격파일의 백업 파일 생성";
            this.BackUp_Chk_FTPFile.UseVisualStyleBackColor = true;
            // 
            // BackUp_Btn_Load
            // 
            this.BackUp_Btn_Load.Location = new System.Drawing.Point(365, 47);
            this.BackUp_Btn_Load.Name = "BackUp_Btn_Load";
            this.BackUp_Btn_Load.Size = new System.Drawing.Size(25, 21);
            this.BackUp_Btn_Load.TabIndex = 29;
            this.BackUp_Btn_Load.Text = "...";
            this.BackUp_Btn_Load.UseVisualStyleBackColor = true;
            this.BackUp_Btn_Load.Click += new System.EventHandler(this.BackUp_Btn_Load_Click);
            // 
            // BackUp_Txt_FileEx
            // 
            this.BackUp_Txt_FileEx.Location = new System.Drawing.Point(126, 73);
            this.BackUp_Txt_FileEx.Name = "BackUp_Txt_FileEx";
            this.BackUp_Txt_FileEx.Size = new System.Drawing.Size(233, 21);
            this.BackUp_Txt_FileEx.TabIndex = 31;
            // 
            // BackUp_Txt_Directory
            // 
            this.BackUp_Txt_Directory.Location = new System.Drawing.Point(126, 47);
            this.BackUp_Txt_Directory.Name = "BackUp_Txt_Directory";
            this.BackUp_Txt_Directory.Size = new System.Drawing.Size(233, 21);
            this.BackUp_Txt_Directory.TabIndex = 32;
            // 
            // BackUp_Lab_FileEx
            // 
            this.BackUp_Lab_FileEx.AutoSize = true;
            this.BackUp_Lab_FileEx.Location = new System.Drawing.Point(16, 78);
            this.BackUp_Lab_FileEx.Name = "BackUp_Lab_FileEx";
            this.BackUp_Lab_FileEx.Size = new System.Drawing.Size(101, 12);
            this.BackUp_Lab_FileEx.TabIndex = 30;
            this.BackUp_Lab_FileEx.Text = "백업 파일 확장자:";
            // 
            // BackUp_Lab_Directory
            // 
            this.BackUp_Lab_Directory.AutoSize = true;
            this.BackUp_Lab_Directory.Location = new System.Drawing.Point(32, 50);
            this.BackUp_Lab_Directory.Name = "BackUp_Lab_Directory";
            this.BackUp_Lab_Directory.Size = new System.Drawing.Size(85, 12);
            this.BackUp_Lab_Directory.TabIndex = 28;
            this.BackUp_Lab_Directory.Text = "백업 디렉토리:";
            // 
            // BackUp_Chk_Save
            // 
            this.BackUp_Chk_Save.AutoSize = true;
            this.BackUp_Chk_Save.Location = new System.Drawing.Point(18, 165);
            this.BackUp_Chk_Save.Name = "BackUp_Chk_Save";
            this.BackUp_Chk_Save.Size = new System.Drawing.Size(144, 16);
            this.BackUp_Chk_Save.TabIndex = 11;
            this.BackUp_Chk_Save.Text = "저장시 백업 파일 생성";
            this.BackUp_Chk_Save.UseVisualStyleBackColor = true;
            // 
            // File_Cbx_BasicEncode
            // 
            this.File_Cbx_BasicEncode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.File_Cbx_BasicEncode.FormattingEnabled = true;
            this.File_Cbx_BasicEncode.Items.AddRange(new object[] {
            "ANSI",
            "UTF-8",
            "UNICODE"});
            this.File_Cbx_BasicEncode.Location = new System.Drawing.Point(131, 47);
            this.File_Cbx_BasicEncode.Name = "File_Cbx_BasicEncode";
            this.File_Cbx_BasicEncode.Size = new System.Drawing.Size(220, 20);
            this.File_Cbx_BasicEncode.TabIndex = 9;
            // 
            // File_Lab_BasicEncode
            // 
            this.File_Lab_BasicEncode.AutoSize = true;
            this.File_Lab_BasicEncode.Location = new System.Drawing.Point(51, 50);
            this.File_Lab_BasicEncode.Name = "File_Lab_BasicEncode";
            this.File_Lab_BasicEncode.Size = new System.Drawing.Size(73, 12);
            this.File_Lab_BasicEncode.TabIndex = 6;
            this.File_Lab_BasicEncode.Text = "기본 인코딩:";
            // 
            // File_Txt_Time
            // 
            this.File_Txt_Time.Location = new System.Drawing.Point(131, 20);
            this.File_Txt_Time.Name = "File_Txt_Time";
            this.File_Txt_Time.Size = new System.Drawing.Size(72, 21);
            this.File_Txt_Time.TabIndex = 4;
            // 
            // File_Lab_AutoSave
            // 
            this.File_Lab_AutoSave.AutoSize = true;
            this.File_Lab_AutoSave.Location = new System.Drawing.Point(6, 24);
            this.File_Lab_AutoSave.Name = "File_Lab_AutoSave";
            this.File_Lab_AutoSave.Size = new System.Drawing.Size(119, 12);
            this.File_Lab_AutoSave.TabIndex = 3;
            this.File_Lab_AutoSave.Text = "자동 저장 간격 (초) :";
            // 
            // Set_Txt_FileExp
            // 
            this.Set_Txt_FileExp.Location = new System.Drawing.Point(83, 102);
            this.Set_Txt_FileExp.Name = "Set_Txt_FileExp";
            this.Set_Txt_FileExp.Size = new System.Drawing.Size(325, 21);
            this.Set_Txt_FileExp.TabIndex = 7;
            this.Set_Txt_FileExp.TextChanged += new System.EventHandler(this.Set_Txt_FileExp_TextChanged);
            // 
            // Btn_OK
            // 
            this.Btn_OK.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Btn_OK.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Btn_OK.Location = new System.Drawing.Point(367, 336);
            this.Btn_OK.Name = "Btn_OK";
            this.Btn_OK.Size = new System.Drawing.Size(84, 33);
            this.Btn_OK.TabIndex = 21;
            this.Btn_OK.Text = "확인";
            this.Btn_OK.UseVisualStyleBackColor = false;
            this.Btn_OK.Click += new System.EventHandler(this.Btn_OK_Click);
            // 
            // Lab_Sort
            // 
            this.Lab_Sort.AutoSize = true;
            this.Lab_Sort.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Lab_Sort.Location = new System.Drawing.Point(12, 10);
            this.Lab_Sort.Name = "Lab_Sort";
            this.Lab_Sort.Size = new System.Drawing.Size(52, 13);
            this.Lab_Sort.TabIndex = 24;
            this.Lab_Sort.Text = "항목(C)";
            // 
            // Lst_Sort
            // 
            this.Lst_Sort.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Lst_Sort.FormattingEnabled = true;
            this.Lst_Sort.Items.AddRange(new object[] {
            "파일 설정",
            "설정 및 구문강조"});
            this.Lst_Sort.Location = new System.Drawing.Point(12, 27);
            this.Lst_Sort.Name = "Lst_Sort";
            this.Lst_Sort.Size = new System.Drawing.Size(171, 342);
            this.Lst_Sort.TabIndex = 23;
            this.Lst_Sort.SelectedIndexChanged += new System.EventHandler(this.Lst_Sort_SelectedIndexChanged);
            // 
            // Btn_Adjust
            // 
            this.Btn_Adjust.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Btn_Adjust.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Btn_Adjust.Location = new System.Drawing.Point(545, 336);
            this.Btn_Adjust.Name = "Btn_Adjust";
            this.Btn_Adjust.Size = new System.Drawing.Size(82, 33);
            this.Btn_Adjust.TabIndex = 26;
            this.Btn_Adjust.Text = "적용";
            this.Btn_Adjust.UseVisualStyleBackColor = false;
            this.Btn_Adjust.Click += new System.EventHandler(this.Btn_Adjust_Click);
            // 
            // Color_Chk_List
            // 
            this.Color_Chk_List.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Color_Chk_List.FormattingEnabled = true;
            this.Color_Chk_List.ItemHeight = 12;
            this.Color_Chk_List.Items.AddRange(new object[] {
            "KeyWords",
            "Contextual Keywords",
            "UserDefine1",
            "UserDefine2",
            "UserDefine3",
            "Comment",
            "String",
            "Number"});
            this.Color_Chk_List.Location = new System.Drawing.Point(9, 8);
            this.Color_Chk_List.Name = "Color_Chk_List";
            this.Color_Chk_List.Size = new System.Drawing.Size(203, 136);
            this.Color_Chk_List.TabIndex = 0;
            this.Color_Chk_List.SelectedIndexChanged += new System.EventHandler(this.Color_Chk_List_SelectedIndexChanged);
            // 
            // Gbx_Template
            // 
            this.Gbx_Template.Controls.Add(this.Template_Lab_Temp);
            this.Gbx_Template.Controls.Add(this.Template_Btn_Open);
            this.Gbx_Template.Controls.Add(this.Template_Btn_Load);
            this.Gbx_Template.Controls.Add(this.Template_Txt_File);
            this.Gbx_Template.Controls.Add(this.Template_Txt_Menu);
            this.Gbx_Template.Controls.Add(this.Template_Lab_File);
            this.Gbx_Template.Controls.Add(this.Template_Lab_Menu);
            this.Gbx_Template.Controls.Add(this.Template_Btn_Return);
            this.Gbx_Template.Controls.Add(this.Template_Btn_Down);
            this.Gbx_Template.Controls.Add(this.Template_Btn_Up);
            this.Gbx_Template.Controls.Add(this.Template_Btn_Remove);
            this.Gbx_Template.Controls.Add(this.Template_Btn_Add);
            this.Gbx_Template.Controls.Add(this.Template_Lst_Temp);
            this.Gbx_Template.Location = new System.Drawing.Point(977, 545);
            this.Gbx_Template.Name = "Gbx_Template";
            this.Gbx_Template.Size = new System.Drawing.Size(423, 320);
            this.Gbx_Template.TabIndex = 19;
            this.Gbx_Template.TabStop = false;
            this.Gbx_Template.Text = "문서 템플릿";
            // 
            // Template_Lab_Temp
            // 
            this.Template_Lab_Temp.AutoSize = true;
            this.Template_Lab_Temp.Location = new System.Drawing.Point(12, 17);
            this.Template_Lab_Temp.Name = "Template_Lab_Temp";
            this.Template_Lab_Temp.Size = new System.Drawing.Size(87, 12);
            this.Template_Lab_Temp.TabIndex = 13;
            this.Template_Lab_Temp.Text = "문서 템플릿(T)";
            // 
            // Template_Btn_Open
            // 
            this.Template_Btn_Open.Location = new System.Drawing.Point(348, 205);
            this.Template_Btn_Open.Name = "Template_Btn_Open";
            this.Template_Btn_Open.Size = new System.Drawing.Size(63, 22);
            this.Template_Btn_Open.TabIndex = 12;
            this.Template_Btn_Open.Text = "열기";
            this.Template_Btn_Open.UseVisualStyleBackColor = true;
            // 
            // Template_Btn_Load
            // 
            this.Template_Btn_Load.Location = new System.Drawing.Point(313, 206);
            this.Template_Btn_Load.Name = "Template_Btn_Load";
            this.Template_Btn_Load.Size = new System.Drawing.Size(29, 22);
            this.Template_Btn_Load.TabIndex = 11;
            this.Template_Btn_Load.Text = "...";
            this.Template_Btn_Load.UseVisualStyleBackColor = true;
            // 
            // Template_Txt_File
            // 
            this.Template_Txt_File.Location = new System.Drawing.Point(105, 206);
            this.Template_Txt_File.Name = "Template_Txt_File";
            this.Template_Txt_File.Size = new System.Drawing.Size(202, 21);
            this.Template_Txt_File.TabIndex = 10;
            // 
            // Template_Txt_Menu
            // 
            this.Template_Txt_Menu.Location = new System.Drawing.Point(105, 176);
            this.Template_Txt_Menu.Name = "Template_Txt_Menu";
            this.Template_Txt_Menu.Size = new System.Drawing.Size(202, 21);
            this.Template_Txt_Menu.TabIndex = 9;
            // 
            // Template_Lab_File
            // 
            this.Template_Lab_File.AutoSize = true;
            this.Template_Lab_File.Location = new System.Drawing.Point(11, 211);
            this.Template_Lab_File.Name = "Template_Lab_File";
            this.Template_Lab_File.Size = new System.Drawing.Size(78, 12);
            this.Template_Lab_File.TabIndex = 8;
            this.Template_Lab_File.Text = "파일 이름(F):";
            // 
            // Template_Lab_Menu
            // 
            this.Template_Lab_Menu.AutoSize = true;
            this.Template_Lab_Menu.Location = new System.Drawing.Point(11, 182);
            this.Template_Lab_Menu.Name = "Template_Lab_Menu";
            this.Template_Lab_Menu.Size = new System.Drawing.Size(82, 12);
            this.Template_Lab_Menu.TabIndex = 3;
            this.Template_Lab_Menu.Text = "메뉴 제목(M):";
            // 
            // Template_Btn_Return
            // 
            this.Template_Btn_Return.Location = new System.Drawing.Point(272, 129);
            this.Template_Btn_Return.Name = "Template_Btn_Return";
            this.Template_Btn_Return.Size = new System.Drawing.Size(113, 25);
            this.Template_Btn_Return.TabIndex = 7;
            this.Template_Btn_Return.Text = "기본값 복귀(D)";
            this.Template_Btn_Return.UseVisualStyleBackColor = true;
            // 
            // Template_Btn_Down
            // 
            this.Template_Btn_Down.Location = new System.Drawing.Point(329, 98);
            this.Template_Btn_Down.Name = "Template_Btn_Down";
            this.Template_Btn_Down.Size = new System.Drawing.Size(56, 25);
            this.Template_Btn_Down.TabIndex = 6;
            this.Template_Btn_Down.Text = "아래";
            this.Template_Btn_Down.UseVisualStyleBackColor = true;
            // 
            // Template_Btn_Up
            // 
            this.Template_Btn_Up.Location = new System.Drawing.Point(272, 99);
            this.Template_Btn_Up.Name = "Template_Btn_Up";
            this.Template_Btn_Up.Size = new System.Drawing.Size(51, 24);
            this.Template_Btn_Up.TabIndex = 5;
            this.Template_Btn_Up.Text = "위";
            this.Template_Btn_Up.UseVisualStyleBackColor = true;
            // 
            // Template_Btn_Remove
            // 
            this.Template_Btn_Remove.Location = new System.Drawing.Point(272, 70);
            this.Template_Btn_Remove.Name = "Template_Btn_Remove";
            this.Template_Btn_Remove.Size = new System.Drawing.Size(113, 24);
            this.Template_Btn_Remove.TabIndex = 4;
            this.Template_Btn_Remove.Text = "제거(R)";
            this.Template_Btn_Remove.UseVisualStyleBackColor = true;
            // 
            // Template_Btn_Add
            // 
            this.Template_Btn_Add.Location = new System.Drawing.Point(272, 39);
            this.Template_Btn_Add.Name = "Template_Btn_Add";
            this.Template_Btn_Add.Size = new System.Drawing.Size(113, 26);
            this.Template_Btn_Add.TabIndex = 3;
            this.Template_Btn_Add.Text = "추가(D)";
            this.Template_Btn_Add.UseVisualStyleBackColor = true;
            // 
            // Template_Lst_Temp
            // 
            this.Template_Lst_Temp.FormattingEnabled = true;
            this.Template_Lst_Temp.ItemHeight = 12;
            this.Template_Lst_Temp.Items.AddRange(new object[] {
            "HTML",
            "XHTML",
            "C/C++",
            "Perl",
            "Java"});
            this.Template_Lst_Temp.Location = new System.Drawing.Point(12, 36);
            this.Template_Lst_Temp.Margin = new System.Windows.Forms.Padding(15);
            this.Template_Lst_Temp.Name = "Template_Lst_Temp";
            this.Template_Lst_Temp.Size = new System.Drawing.Size(239, 124);
            this.Template_Lst_Temp.TabIndex = 0;
            // 
            // SettingTab2
            // 
            this.SettingTab2.Controls.Add(this.btn_Color_Apply);
            this.SettingTab2.Controls.Add(this.PreviewColor);
            this.SettingTab2.Controls.Add(this.label1);
            this.SettingTab2.Controls.Add(this.ColorPicker);
            this.SettingTab2.Controls.Add(this.Color_Chk_List);
            this.SettingTab2.Location = new System.Drawing.Point(4, 22);
            this.SettingTab2.Name = "SettingTab2";
            this.SettingTab2.Padding = new System.Windows.Forms.Padding(3);
            this.SettingTab2.Size = new System.Drawing.Size(394, 156);
            this.SettingTab2.TabIndex = 1;
            this.SettingTab2.Text = "구문강조 색상";
            this.SettingTab2.UseVisualStyleBackColor = true;
            this.SettingTab2.Click += new System.EventHandler(this.SettingTab2_Click);
            this.SettingTab2.Enter += new System.EventHandler(this.SettingTab2_Enter);
            // 
            // btn_Color_Apply
            // 
            this.btn_Color_Apply.Location = new System.Drawing.Point(225, 101);
            this.btn_Color_Apply.Name = "btn_Color_Apply";
            this.btn_Color_Apply.Size = new System.Drawing.Size(162, 42);
            this.btn_Color_Apply.TabIndex = 5;
            this.btn_Color_Apply.Text = "적용";
            this.btn_Color_Apply.UseVisualStyleBackColor = true;
            this.btn_Color_Apply.Click += new System.EventHandler(this.btn_Color_Apply_Click);
            // 
            // PreviewColor
            // 
            this.PreviewColor.AutoSize = true;
            this.PreviewColor.Location = new System.Drawing.Point(223, 59);
            this.PreviewColor.Name = "PreviewColor";
            this.PreviewColor.Size = new System.Drawing.Size(81, 12);
            this.PreviewColor.TabIndex = 4;
            this.PreviewColor.Text = "색상 미리보기";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(223, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "색상 설정 :";
            // 
            // ColorPicker
            // 
            this.ColorPicker.Color = System.Drawing.Color.Black;
            this.ColorPicker.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.ColorPicker.DropDownHeight = 1;
            this.ColorPicker.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ColorPicker.DropDownWidth = 1;
            this.ColorPicker.FormattingEnabled = true;
            this.ColorPicker.IntegralHeight = false;
            this.ColorPicker.ItemHeight = 16;
            this.ColorPicker.Items.AddRange(new object[] {
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color",
            "Color"});
            this.ColorPicker.Location = new System.Drawing.Point(225, 24);
            this.ColorPicker.Name = "ColorPicker";
            this.ColorPicker.Size = new System.Drawing.Size(163, 22);
            this.ColorPicker.TabIndex = 2;
            this.ColorPicker.SelectedColorChanged += new System.EventHandler(this.ColorPicker_SelectedColorChanged);
            // 
            // Gbx_Set
            // 
            this.Gbx_Set.Controls.Add(this.Set_Tab_SetHigh);
            this.Gbx_Set.Controls.Add(this.Set_Txt_FileExp);
            this.Gbx_Set.Controls.Add(this.Set_Lab_FileExp);
            this.Gbx_Set.Controls.Add(this.Set_Btn_Remove);
            this.Gbx_Set.Controls.Add(this.Set_Btn_Add);
            this.Gbx_Set.Controls.Add(this.Set_Lst_FileSort);
            this.Gbx_Set.Controls.Add(this.Set_Lab_FileSort);
            this.Gbx_Set.Location = new System.Drawing.Point(204, 10);
            this.Gbx_Set.Name = "Gbx_Set";
            this.Gbx_Set.Size = new System.Drawing.Size(423, 320);
            this.Gbx_Set.TabIndex = 22;
            this.Gbx_Set.TabStop = false;
            this.Gbx_Set.Text = "설정 & 구문강조";
            this.Gbx_Set.Enter += new System.EventHandler(this.Gbx_Set_Enter);
            // 
            // Set_Tab_SetHigh
            // 
            this.Set_Tab_SetHigh.Controls.Add(this.SettingTab1);
            this.Set_Tab_SetHigh.Controls.Add(this.SettingTab2);
            this.Set_Tab_SetHigh.Location = new System.Drawing.Point(10, 129);
            this.Set_Tab_SetHigh.Name = "Set_Tab_SetHigh";
            this.Set_Tab_SetHigh.SelectedIndex = 0;
            this.Set_Tab_SetHigh.Size = new System.Drawing.Size(402, 182);
            this.Set_Tab_SetHigh.TabIndex = 26;
            // 
            // SettingTab1
            // 
            this.SettingTab1.Controls.Add(this.GenHighlight_Chk_NoGap);
            this.SettingTab1.Controls.Add(this.GenHighlight_Cbx_Encoding);
            this.SettingTab1.Controls.Add(this.GenHighlight_Lab_Syntax);
            this.SettingTab1.Controls.Add(this.GenHighlight_Txt_Syntax);
            this.SettingTab1.Controls.Add(this.GenHighlight_Btn_Load);
            this.SettingTab1.Controls.Add(this.GenHighlight_Lab_Encoding);
            this.SettingTab1.Controls.Add(this.GenHighlight_Btn_Open1);
            this.SettingTab1.Location = new System.Drawing.Point(4, 22);
            this.SettingTab1.Name = "SettingTab1";
            this.SettingTab1.Padding = new System.Windows.Forms.Padding(3);
            this.SettingTab1.Size = new System.Drawing.Size(394, 156);
            this.SettingTab1.TabIndex = 0;
            this.SettingTab1.Text = "설정 및 구문강조";
            this.SettingTab1.UseVisualStyleBackColor = true;
            // 
            // GenHighlight_Chk_NoGap
            // 
            this.GenHighlight_Chk_NoGap.AutoSize = true;
            this.GenHighlight_Chk_NoGap.Location = new System.Drawing.Point(32, 68);
            this.GenHighlight_Chk_NoGap.Name = "GenHighlight_Chk_NoGap";
            this.GenHighlight_Chk_NoGap.Size = new System.Drawing.Size(148, 16);
            this.GenHighlight_Chk_NoGap.TabIndex = 24;
            this.GenHighlight_Chk_NoGap.Text = "저장시 줄 끝 공백 제거";
            this.GenHighlight_Chk_NoGap.UseVisualStyleBackColor = true;
            this.GenHighlight_Chk_NoGap.CheckedChanged += new System.EventHandler(this.GenHighlight_Chk_NoGap_CheckedChanged);
            // 
            // GenHighlight_Cbx_Encoding
            // 
            this.GenHighlight_Cbx_Encoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GenHighlight_Cbx_Encoding.FormattingEnabled = true;
            this.GenHighlight_Cbx_Encoding.Items.AddRange(new object[] {
            "ANSI",
            "UTF-8",
            "UNICODE"});
            this.GenHighlight_Cbx_Encoding.Location = new System.Drawing.Point(112, 38);
            this.GenHighlight_Cbx_Encoding.Name = "GenHighlight_Cbx_Encoding";
            this.GenHighlight_Cbx_Encoding.Size = new System.Drawing.Size(105, 20);
            this.GenHighlight_Cbx_Encoding.TabIndex = 19;
            this.GenHighlight_Cbx_Encoding.SelectedIndexChanged += new System.EventHandler(this.GenHighlight_Cbx_Encoding_SelectedIndexChanged);
            // 
            // GenHighlight_Lab_Syntax
            // 
            this.GenHighlight_Lab_Syntax.AutoSize = true;
            this.GenHighlight_Lab_Syntax.Location = new System.Drawing.Point(30, 10);
            this.GenHighlight_Lab_Syntax.Name = "GenHighlight_Lab_Syntax";
            this.GenHighlight_Lab_Syntax.Size = new System.Drawing.Size(76, 12);
            this.GenHighlight_Lab_Syntax.TabIndex = 4;
            this.GenHighlight_Lab_Syntax.Text = "구문파일(N):";
            // 
            // GenHighlight_Txt_Syntax
            // 
            this.GenHighlight_Txt_Syntax.Location = new System.Drawing.Point(112, 6);
            this.GenHighlight_Txt_Syntax.Name = "GenHighlight_Txt_Syntax";
            this.GenHighlight_Txt_Syntax.Size = new System.Drawing.Size(167, 21);
            this.GenHighlight_Txt_Syntax.TabIndex = 5;
            this.GenHighlight_Txt_Syntax.TextChanged += new System.EventHandler(this.GenHighlight_Txt_Syntax_TextChanged);
            // 
            // GenHighlight_Btn_Load
            // 
            this.GenHighlight_Btn_Load.Location = new System.Drawing.Point(285, 6);
            this.GenHighlight_Btn_Load.Name = "GenHighlight_Btn_Load";
            this.GenHighlight_Btn_Load.Size = new System.Drawing.Size(27, 21);
            this.GenHighlight_Btn_Load.TabIndex = 6;
            this.GenHighlight_Btn_Load.Text = "...";
            this.GenHighlight_Btn_Load.UseVisualStyleBackColor = true;
            this.GenHighlight_Btn_Load.Click += new System.EventHandler(this.GenHighlight_Btn_Click);
            // 
            // GenHighlight_Lab_Encoding
            // 
            this.GenHighlight_Lab_Encoding.AutoSize = true;
            this.GenHighlight_Lab_Encoding.Location = new System.Drawing.Point(61, 41);
            this.GenHighlight_Lab_Encoding.Name = "GenHighlight_Lab_Encoding";
            this.GenHighlight_Lab_Encoding.Size = new System.Drawing.Size(45, 12);
            this.GenHighlight_Lab_Encoding.TabIndex = 14;
            this.GenHighlight_Lab_Encoding.Text = "인코딩:";
            // 
            // GenHighlight_Btn_Open1
            // 
            this.GenHighlight_Btn_Open1.Location = new System.Drawing.Point(318, 6);
            this.GenHighlight_Btn_Open1.Name = "GenHighlight_Btn_Open1";
            this.GenHighlight_Btn_Open1.Size = new System.Drawing.Size(59, 23);
            this.GenHighlight_Btn_Open1.TabIndex = 7;
            this.GenHighlight_Btn_Open1.Text = "열기";
            this.GenHighlight_Btn_Open1.UseVisualStyleBackColor = true;
            // 
            // CD
            // 
            this.CD.FileName = "cd";
            // 
            // GeneralSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 379);
            this.Controls.Add(this.Btn_No);
            this.Controls.Add(this.Gbx_File);
            this.Controls.Add(this.Btn_OK);
            this.Controls.Add(this.Lab_Sort);
            this.Controls.Add(this.Lst_Sort);
            this.Controls.Add(this.Btn_Adjust);
            this.Controls.Add(this.Gbx_Template);
            this.Controls.Add(this.Gbx_Set);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GeneralSetting";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "일반 설정";
            this.Load += new System.EventHandler(this.GeneralSetting_Load);
            this.Gbx_File.ResumeLayout(false);
            this.Gbx_File.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Gbx_Template.ResumeLayout(false);
            this.Gbx_Template.PerformLayout();
            this.SettingTab2.ResumeLayout(false);
            this.SettingTab2.PerformLayout();
            this.Gbx_Set.ResumeLayout(false);
            this.Gbx_Set.PerformLayout();
            this.Set_Tab_SetHigh.ResumeLayout(false);
            this.SettingTab1.ResumeLayout(false);
            this.SettingTab1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Btn_No;
        private System.Windows.Forms.Label Set_Lab_FileExp;
        private System.Windows.Forms.Button Set_Btn_Remove;
        private System.Windows.Forms.Button Set_Btn_Add;
        public System.Windows.Forms.ListBox Set_Lst_FileSort;
        private System.Windows.Forms.Label Set_Lab_FileSort;
        private System.Windows.Forms.GroupBox Gbx_File;
        private System.Windows.Forms.CheckBox BackUp_Chk_Save;
        private System.Windows.Forms.ComboBox File_Cbx_BasicEncode;
        private System.Windows.Forms.Label File_Lab_BasicEncode;
        private System.Windows.Forms.TextBox File_Txt_Time;
        private System.Windows.Forms.Label File_Lab_AutoSave;
        private System.Windows.Forms.TextBox Set_Txt_FileExp;
        private System.Windows.Forms.Button Btn_OK;
        private System.Windows.Forms.Label Lab_Sort;
        private System.Windows.Forms.ListBox Lst_Sort;
        private System.Windows.Forms.Button Btn_Adjust;
        private System.Windows.Forms.GroupBox Gbx_Template;
        private System.Windows.Forms.Label Template_Lab_Temp;
        private System.Windows.Forms.Button Template_Btn_Open;
        private System.Windows.Forms.Button Template_Btn_Load;
        private System.Windows.Forms.TextBox Template_Txt_File;
        private System.Windows.Forms.TextBox Template_Txt_Menu;
        private System.Windows.Forms.Label Template_Lab_File;
        private System.Windows.Forms.Label Template_Lab_Menu;
        private System.Windows.Forms.Button Template_Btn_Return;
        private System.Windows.Forms.Button Template_Btn_Down;
        private System.Windows.Forms.Button Template_Btn_Up;
        private System.Windows.Forms.Button Template_Btn_Remove;
        private System.Windows.Forms.Button Template_Btn_Add;
        private System.Windows.Forms.ListBox Template_Lst_Temp;
        private System.Windows.Forms.TabPage SettingTab2;
        private System.Windows.Forms.GroupBox Gbx_Set;
        private System.Windows.Forms.TabControl Set_Tab_SetHigh;
        private System.Windows.Forms.TabPage SettingTab1;
        private System.Windows.Forms.CheckBox GenHighlight_Chk_NoGap;
        private System.Windows.Forms.ComboBox GenHighlight_Cbx_Encoding;
        private System.Windows.Forms.Label GenHighlight_Lab_Syntax;
        private System.Windows.Forms.TextBox GenHighlight_Txt_Syntax;
        private System.Windows.Forms.Button GenHighlight_Btn_Load;
        private System.Windows.Forms.Label GenHighlight_Lab_Encoding;
        private System.Windows.Forms.Button GenHighlight_Btn_Open1;
        private System.Windows.Forms.ListBox Color_Chk_List;
        private OfficePickers.ColorPicker.ComboBoxColorPicker ColorPicker;
        private System.Windows.Forms.Label PreviewColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog CD;
        private System.Windows.Forms.Button btn_Color_Apply;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox BackUp_Chk_Open;
        private System.Windows.Forms.CheckBox BackUp_Chk_DateTime;
        private System.Windows.Forms.CheckBox BackUp_Chk_DirName;
        private System.Windows.Forms.CheckBox BackUp_Chk_FTPFile;
        private System.Windows.Forms.Button BackUp_Btn_Load;
        private System.Windows.Forms.TextBox BackUp_Txt_FileEx;
        private System.Windows.Forms.TextBox BackUp_Txt_Directory;
        private System.Windows.Forms.Label BackUp_Lab_FileEx;
        private System.Windows.Forms.Label BackUp_Lab_Directory;
        private System.Windows.Forms.TextBox BackUp_Txt_Time;
        private System.Windows.Forms.CheckBox BackUp_Chk_FormClose;
        private System.Windows.Forms.Label label2;
    }
}