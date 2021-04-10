using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainFormRichTextBox.Forms
{
    public partial class GeneralSetting : Form
    {
        RichTextBoxForm richTextBoxForm;
        public GeneralSetting(RichTextBoxForm rtbf)
        {
            richTextBoxForm = rtbf;
            InitializeComponent();
        }

        public List<string> Set_Name_List = new List<string>();
        public List<string> Set_Detail_List = new List<string>();//Set
        public List<string> Template_Name_List = new List<string>();
        public List<string> Template_Detail_List = new List<string>();//Template
        public List<string> stxFile_Name_List = new List<string>();
        public List<string> stxFile_Detail_List = new List<string>();//stxFile
        iniModule.iniModule ini = new iniModule.iniModule();

        private void Template_Lst_Temp_SelectedIndexChanged(object sender, EventArgs e)
        {
            string[] SplitResult = Template_Detail_List[Template_Lst_Temp.SelectedIndex].Split(new string[] { "||" }, StringSplitOptions.None);
            ///*여기도 뭐가 들어갈지 모르겠습니다.*/ = Template_Lst_Temp.Items[Template_Lst_Temp.SelectedIndex].ToString();
            Template_Txt_File.Text = SplitResult[0];
            Template_Txt_Menu.Text = SplitResult[1];
        }


        private void button12_Click(object sender, EventArgs e)
        {
            Template_Lst_Temp.Items.Add("문서 템플릿 이름");
            Template_Name_List.Add("문서 템플릿 이름");
            Template_Detail_List.Add("");
            Template_Detail_List.Add(Template_Txt_File.Text + "||" + Template_Txt_Menu.Text); // Template의 밑 부분은 아직 작성이 안되어 있어서 detail에 두개만 넣었습니다.
            Template_Txt_File.Text = "";
            Template_Txt_Menu.Text = "";
            Template_Lst_Temp.SelectedIndex = Template_Lst_Temp.Items.Count - 1;
        }


        private void Lst_Sort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Lst_Sort.SelectedIndex == 0)
            {
                Gbx_Set.Visible = false;
                Gbx_Set.Text = "";
                Gbx_Template.Visible = false;
                Gbx_Template.Text = "";
                Gbx_File.Visible = true;
                Gbx_File.Location = new Point(204, 12);
            }
            else if (Lst_Sort.SelectedIndex == 1)
            {
                Gbx_File.Visible = false;
                Gbx_File.Text = "";
                Gbx_Template.Visible = false;
                Gbx_Template.Text = "";
                Gbx_Set.Visible = true;
                Gbx_Set.Location = new Point(204, 12);
                if (Set_Lst_FileSort.Items.Count > 0)
                {
                    Set_Lst_FileSort.SelectedIndex = 0;
                }
            }

            else if (Lst_Sort.SelectedIndex == 2)
            {
                Gbx_File.Visible = false;
                Gbx_File.Text = "";
                Gbx_Set.Visible = false;
                Gbx_Set.Text = "";
                Gbx_Template.Visible = true;
                Gbx_Template.Location = new Point(204, 12);

            }

            else if (Lst_Sort.SelectedIndex == 3)
            {
                Gbx_File.Visible = false;
                Gbx_File.Text = "";
                Gbx_Template.Visible = false;
                Gbx_Template.Text = "";
                Gbx_Template.Visible = false;
                Gbx_Template.Text = "";
            }
        }

        private void GeneralSetting_Load(object sender, EventArgs e)
        {
            Lst_Sort.SelectedIndex = 0;
            GenHighlight_Cbx_Encoding.SelectedIndex = 0;
            File_Cbx_BasicEncode.SelectedIndex = 0;
            try
            {

                File_Txt_Time.Text = ini.Load(Application.StartupPath + "\\Setting.ini", "File", "Txt_AutoSaveTime");

                BackUp_Txt_Directory.Text = ini.Load(Application.StartupPath + "\\Setting.ini", "File", "Txt_BackUpDirectory");
                BackUp_Txt_FileEx.Text = ini.Load(Application.StartupPath + "\\Setting.ini", "File", "Txt_BackUpFormat");
                
                File_Cbx_BasicEncode.SelectedIndex = int.Parse(ini.Load(Application.StartupPath + "\\Setting.ini", "File", "Cbx_BasicEncode"));
                BackUp_Txt_Time.Text = ini.Load(Application.StartupPath + "\\Setting.ini", "File", "Txt_AutoBackUpTime");
                BackUp_Chk_DirName.Checked = bool.Parse(ini.Load(Application.StartupPath + "\\Setting.ini", "File", "Chk_DirName"));
                BackUp_Chk_DateTime.Checked = bool.Parse(ini.Load(Application.StartupPath + "\\Setting.ini", "File", "Chk_DateTime"));
                BackUp_Chk_FTPFile.Checked = bool.Parse(ini.Load(Application.StartupPath + "\\Setting.ini", "File", "Chk_FtpFile"));
                BackUp_Chk_Open.Checked = bool.Parse(ini.Load(Application.StartupPath + "\\Setting.ini", "File", "Chk_OpenBU"));
                BackUp_Chk_Save.Checked = bool.Parse(ini.Load(Application.StartupPath + "\\Setting.ini", "File", "Chk_SaveBU"));
                BackUp_Chk_FormClose.Checked = bool.Parse(ini.Load(Application.StartupPath + "\\Setting.ini", "File", "Chk_FCloseBU"));

                
                //Set_List
                string[] SplitResult = ini.Load(Application.StartupPath + "\\Setting.ini", "Set_List", "Set_List").Split(new string[] { "||" }, StringSplitOptions.None);

                int List_Count = SplitResult.Length - 1; // 배열.length 로 배열의 크기를 구함. 위 설명에 의해 -1해서 사용한 모습
                for (int i = 0; i < List_Count; i++)
                {
                    Set_Name_List.Add(SplitResult[i]);
                    Set_Lst_FileSort.Items.Add(SplitResult[i]);
                    Set_Detail_List.Add(ini.Load(Application.StartupPath + "\\Setting.ini", "Set_List", SplitResult[i]));

                }


            }
            catch (Exception ex) { MessageBox.Show("설정 값을 불러오는 도중 오류가 발생했습니다.\n 오류내용 : " + ex.Message ,"오류",MessageBoxButtons.OK,MessageBoxIcon.Error); } 


        }

        private void Btn_OK_Click(object sender, EventArgs e)
        {
            string Set_List_Text = "";
            ini.Save(Application.StartupPath + "\\Setting.ini", "File", "Txt_AutoSaveTime", File_Txt_Time.Text);

            ini.Save(Application.StartupPath + "\\Setting.ini", "File", "Txt_BackUpDirectory", BackUp_Txt_Directory.Text);
            ini.Save(Application.StartupPath + "\\Setting.ini", "File", "Txt_BackUpFormat", BackUp_Txt_FileEx.Text);
            
            ini.Save(Application.StartupPath + "\\Setting.ini", "File", "Cbx_BasicEncode", File_Cbx_BasicEncode.SelectedIndex.ToString());
            ini.Save(Application.StartupPath + "\\Setting.ini", "File", "Txt_AutoBackUpTime", BackUp_Txt_Time.Text);
            ini.Save(Application.StartupPath + "\\Setting.ini", "File", "Chk_DirName", BackUp_Chk_DirName.Checked.ToString());
            ini.Save(Application.StartupPath + "\\Setting.ini", "File", "Chk_DateTime", BackUp_Chk_DateTime.Checked.ToString());
            ini.Save(Application.StartupPath + "\\Setting.ini", "File", "Chk_FtpFile", BackUp_Chk_FTPFile.Checked.ToString());
            ini.Save(Application.StartupPath + "\\Setting.ini", "File", "Chk_OpenBU", BackUp_Chk_Open.Checked.ToString());
            ini.Save(Application.StartupPath + "\\Setting.ini", "File", "Chk_SaveBU", BackUp_Chk_Save.Checked.ToString());
            ini.Save(Application.StartupPath + "\\Setting.ini", "File", "Chk_FCloseBU", BackUp_Chk_FormClose.Checked.ToString());



            //Set
            for (int i = 0; i < Set_Lst_FileSort.Items.Count; i++)
            {
                Set_List_Text += Set_Name_List[i] + "||";
            }


            ini.Save(Application.StartupPath + "\\Setting.ini", "Set_List", "Set_List", Set_List_Text);


            for (int i = 0; i < Set_Lst_FileSort.Items.Count; i++)
            {
                ini.Save(Application.StartupPath + "\\Setting.ini", "Set_List", Set_Name_List[i], Set_Detail_List[i]);
            }

            /*
            //Template
            for (int i = 0; i < Template_Lst_Temp.Items.Count; i++)
            {
                Template_List_Text += Template_Name_List[i] + "||";
            }


            ini.Save(Application.StartupPath + "\\Setting.ini", "Template_List", "Template_List", Template_List_Text);


            for (int i = 0; i < Template_Lst_Temp.Items.Count; i++)
            {
                ini.Save(Application.StartupPath + "\\Setting.ini", "Template_List", Template_Name_List[i], Template_Detail_List[i]);
            }*/
            MessageBox.Show("현재 열려있는 탭에 대하여 변경 사항은\n탭을 닫은 후 다시 열때 적용됩니다.", "확인", MessageBoxButtons.OK, MessageBoxIcon.Information);
            richTextBoxForm.getDeveloperfFormat(); 
            richTextBoxForm.Load_General_Setting();
            this.Close(); // 해당 폼 종료

        }

        private void Set_Btn_Add_Click(object sender, EventArgs e)
        {
            new AddFiles(this).ShowDialog();
            /*Set_Lst_FileSort.Items.Add("테스트");
            Set_Name_List.Add("테스트");
            Set_Detail_List.Add(""); // Set_Name_List와 Index를 맞추기 위해서 Detail에 공백데이터 삽입
            Set_Detail_List.Add(Set_Txt_FileExp.Text + "||" + GenHighlight_Txt_Syntax1.Text + "||" + GenHighlight_Chk_NoGap.Checked);
            Set_Txt_FileExp.Text = "";
            GenHighlight_Txt_Syntax1.Text = "";
            Set_Lst_FileSort.SelectedIndex = Set_Lst_FileSort.Items.Count - 1; // 최근에 추가한 데이터를 선택시킴
                                                                               //이부분에서 Set_Lst_FileSort 의 SelectedIndexChanged 이벤트 활용해서 아래 데이터들 ini.Load시킬것

            Set_Txt_FileExp.Focus(); // 파일 확장자로 포커스 이동
            */

        }

        private void Set_Btn_Remove_Click(object sender, EventArgs e)
        {
            if (Set_Lst_FileSort.SelectedIndex > -1)
            {
                int Idx = Set_Lst_FileSort.SelectedIndex;
                Set_Lst_FileSort.Items.RemoveAt(Idx);
                Set_Name_List.RemoveAt(Idx);

            }
        }

        private void Template_Btn_Remove_Click(object sender, EventArgs e)
        {
            if (Set_Lst_FileSort.SelectedIndex > -1)
            {
                int Idx = Set_Lst_FileSort.SelectedIndex;
                Set_Lst_FileSort.Items.RemoveAt(Idx);
                Set_Name_List.RemoveAt(Idx);

            }
        }

        private void Set_Lst_FileSort_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Set_Lst_FileSort.SelectedIndex > -1)
                {

                    string[] SplitResult = Set_Detail_List[Set_Lst_FileSort.SelectedIndex].Split(new string[] { "||" }, StringSplitOptions.None);
                    Set_Txt_FileExp.Text = SplitResult[0]; // 0
                    GenHighlight_Txt_Syntax.Text = SplitResult[1]; // 1
                    GenHighlight_Cbx_Encoding.SelectedIndex = int.Parse(SplitResult[2]); // 2
                    GenHighlight_Chk_NoGap.Checked = bool.Parse(SplitResult[3]); // 3
                }
            }
            catch { }
        }

        private void Set_Txt_FileExp_TextChanged(object sender, EventArgs e)
        {
            if (Set_Lst_FileSort.SelectedIndex > -1)
                Set_Detail_List[Set_Lst_FileSort.SelectedIndex] = Set_Txt_FileExp.Text + "||" + GenHighlight_Txt_Syntax.Text + "||" + GenHighlight_Cbx_Encoding.SelectedIndex + "||" + GenHighlight_Chk_NoGap.Checked;

        }

        private void GenHighlight_Txt_Syntax_TextChanged(object sender, EventArgs e)
        {
            if (Set_Lst_FileSort.SelectedIndex > -1)
            {
                Set_Detail_List[Set_Lst_FileSort.SelectedIndex] = Set_Txt_FileExp.Text + "||" + GenHighlight_Txt_Syntax.Text + "||" + GenHighlight_Cbx_Encoding.SelectedIndex + "||" + GenHighlight_Chk_NoGap.Checked;
                if (File.Exists(Application.StartupPath + "\\stxList\\" + GenHighlight_Txt_Syntax.Text))
                {
                    ((Control)SettingTab2).Enabled = true;
                }
                else
                {
                    ((Control)SettingTab2).Enabled = false;
                }
            }

        }

        private void GenHighlight_Cbx_Encoding_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Set_Lst_FileSort.SelectedIndex > -1)
                Set_Detail_List[Set_Lst_FileSort.SelectedIndex] = Set_Txt_FileExp.Text + "||" + GenHighlight_Txt_Syntax.Text + "||" + GenHighlight_Cbx_Encoding.SelectedIndex + "||" + GenHighlight_Chk_NoGap.Checked;

        }

        private void GenHighlight_Chk_NoGap_CheckedChanged(object sender, EventArgs e)
        {
            if (Set_Lst_FileSort.SelectedIndex > -1)
                Set_Detail_List[Set_Lst_FileSort.SelectedIndex] = Set_Txt_FileExp.Text + "||" + GenHighlight_Txt_Syntax.Text + "||" + GenHighlight_Cbx_Encoding.SelectedIndex + "||" + GenHighlight_Chk_NoGap.Checked;

        }

        private void Btn_No_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Btn_Adjust_Click(object sender, EventArgs e)
        {
            string Set_List_Text = "";

            ini.Save(Application.StartupPath + "\\Setting.ini", "File", "Txt_AutoSaveTime", File_Txt_Time.Text);

            ini.Save(Application.StartupPath + "\\Setting.ini", "File", "Txt_BackUpDirectory", BackUp_Txt_Directory.Text);
            ini.Save(Application.StartupPath + "\\Setting.ini", "File", "Txt_BackUpFormat", BackUp_Txt_FileEx.Text);
            
            ini.Save(Application.StartupPath + "\\Setting.ini", "File", "Cbx_BasicEncode", File_Cbx_BasicEncode.SelectedIndex.ToString());
            ini.Save(Application.StartupPath + "\\Setting.ini", "File", "Txt_AutoBackUpTime", BackUp_Txt_Time.Text);
            ini.Save(Application.StartupPath + "\\Setting.ini", "File", "Chk_DirName", BackUp_Chk_DirName.Checked.ToString());
            ini.Save(Application.StartupPath + "\\Setting.ini", "File", "Chk_DateTime", BackUp_Chk_DateTime.Checked.ToString());
            ini.Save(Application.StartupPath + "\\Setting.ini", "File", "Chk_FtpFile", BackUp_Chk_FTPFile.Checked.ToString());
            ini.Save(Application.StartupPath + "\\Setting.ini", "File", "Chk_OpenBU", BackUp_Chk_Open.Checked.ToString());
            ini.Save(Application.StartupPath + "\\Setting.ini", "File", "Chk_SaveBU", BackUp_Chk_Save.Checked.ToString());
            ini.Save(Application.StartupPath + "\\Setting.ini", "File", "Chk_FCloseBU", BackUp_Chk_FormClose.Checked.ToString());


            //Set
            for (int i = 0; i < Set_Lst_FileSort.Items.Count; i++)
            {
                Set_List_Text += Set_Name_List[i] + "||";
            }


            ini.Save(Application.StartupPath + "\\Setting.ini", "Set_List", "Set_List", Set_List_Text);


            for (int i = 0; i < Set_Lst_FileSort.Items.Count; i++)
            {
                ini.Save(Application.StartupPath + "\\Setting.ini", "Set_List", Set_Name_List[i], Set_Detail_List[i]);
            }
        }

        private void Gbx_Set_Enter(object sender, EventArgs e)
        {

        }

        private void GenHighlight_Btn_Click(object sender, EventArgs e)
        {
            CD.Filter = "Syntax 파일|*.stx";
            if (CD.ShowDialog() == DialogResult.OK)
            {
                if (CD.FileName.Contains(Application.StartupPath + "\\stxList\\"))
                {
                    GenHighlight_Txt_Syntax.Text = CD.FileName.Replace(Application.StartupPath + "\\stxList\\", "");
                }
                else
                {
                    MessageBox.Show("stx파일은 반드시 프로그램 폴더의 stxList 폴더 안에 존재해야합니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ColorPicker_SelectedColorChanged(object sender, EventArgs e)
        {
            PreviewColor.ForeColor = ColorPicker.Color;
        }

        private void SettingTab2_Enter(object sender, EventArgs e)
        {
            if (((Control)SettingTab2).Enabled == true)
            {
                //속성 불러오기
            }
        }

        private void SettingTab2_Click(object sender, EventArgs e)
        {

        }

        private void btn_Color_Apply_Click(object sender, EventArgs e)
        {
            if (Color_Chk_List.SelectedIndex <= -1) return;

            if (File.Exists(Application.StartupPath + "\\stxList\\" + GenHighlight_Txt_Syntax.Text))
            {
                string Mode;
                switch (Color_Chk_List.SelectedIndex)
                {
                    case 0:
                        Mode = "KeyWord";
                        break;
                    case 1:
                        Mode = "Contextual Keywords";
                        break;
                    case 2:
                        Mode = "UserDefine1";
                        break;
                    case 3:
                        Mode = "UserDefine2";
                        break;
                    case 4:
                        Mode = "UserDefine3";
                        break;
                    case 5:
                        Mode = "Comment";
                        break;
                    case 6:
                        Mode = "String";
                        break;
                    case 7:
                        Mode = "Number";
                        break;
                    default:
                        Mode = "";
                        break;
                }

                string colorA = ColorPicker.Color.A.ToString();
                string colorR = ColorPicker.Color.R.ToString();
                string colorG = ColorPicker.Color.G.ToString();
                string colorB = ColorPicker.Color.B.ToString();
                string colors = colorA + "/" + colorR + "/" + colorG + "/" + colorB;
                ini.Save(Application.StartupPath + "\\stxList\\" + GenHighlight_Txt_Syntax.Text, Mode, "Color", colors);

            }
        }

        private void Color_Chk_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Color_Chk_List.SelectedIndex <= -1) return;

                if (File.Exists(Application.StartupPath + "\\stxList\\" + GenHighlight_Txt_Syntax.Text))
                {
                    string Mode;
                    switch (Color_Chk_List.SelectedIndex)
                    {
                        case 0:
                            Mode = "KeyWord";
                            break;
                        case 1:
                            Mode = "Contextual Keywords";
                            break;
                        case 2:
                            Mode = "UserDefine1";
                            break;
                        case 3:
                            Mode = "UserDefine2";
                            break;
                        case 4:
                            Mode = "UserDefine3";
                            break;
                        case 5:
                            Mode = "Comment";
                            break;
                        case 6:
                            Mode = "String";
                            break;
                        case 7:
                            Mode = "Number";
                            break;
                        default:
                            Mode = "";
                            break;
                    }


                    string colors = ini.Load(Application.StartupPath + "\\stxList\\" + GenHighlight_Txt_Syntax.Text, Mode, "Color");
                    string colorA = colors.Split('/')[0];
                    string colorR = colors.Split('/')[1];
                    string colorG = colors.Split('/')[2];
                    string colorB = colors.Split('/')[3];
                    ColorPicker.Color = Color.FromArgb(int.Parse(colorA), int.Parse(colorR), int.Parse(colorG), int.Parse(colorB));

                }
            }
            catch
            {
                ColorPicker.Color = Color.Black;
            }

        }

        private void BackUp_Btn_Load_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "백업파일이 저장될 위치를 선택해주세요.";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                BackUp_Txt_Directory.Text = dialog.SelectedPath + "\\";
                Directory.CreateDirectory(BackUp_Txt_Directory.Text);
            }
            
        }
    }
}
