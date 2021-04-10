using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MainFormRichTextBox.Forms
{
    public partial class FTPSetting : Form
    {
        List<string> FTP_Name_List = new List<string>(); // FTP들의 이름(설명)을 저장하는 리스트
        List<string> FTP_Detail_List = new List<string>(); // FTP들의 속성 (IP || ID || PW)들을 저장하는 리스트

        iniModule.iniModule ini = new iniModule.iniModule(); // ini모듈을 사용하기 위해서는 iniModule 인스턴스 생성 필수.

        RichTextBoxForm richTextBoxForm;
        public FTPSetting(RichTextBoxForm rtbf)
        {
            richTextBoxForm = rtbf;
            InitializeComponent();
        }

        public FTPSetting()
        {
            InitializeComponent();
        }

        private void FTPSetting_Load(object sender, EventArgs e)
        {
            FTP_Txt_Inf.Text = ini.Load(Application.StartupPath + "\\Setting.ini", "FTP_List", "FTP_Description");
            FTP_Txt_Server.Text = ini.Load(Application.StartupPath + "\\Setting.ini", "FTP_List", "FTP_Server").Replace("ftp://", "");
            FTP_Txt_Id.Text = ini.Load(Application.StartupPath + "\\Setting.ini", "FTP_List", "FTP_ID");
            FTP_Txt_Pw.Text = ini.Load(Application.StartupPath + "\\Setting.ini", "FTP_List", "FTP_PW");
            /*
             만약 불러왔을때 ini파일이 없거나, 내용이 없으면 오류가 날수있으므로 try-catch문으로 예외처리
             */
            /*try
            {


                string[] SplitResult = ini.Load(Application.StartupPath + "\\Setting.ini", "FTP_List", "FTP_List").Split(new string[] { "||" }, StringSplitOptions.None);

                int List_Count = SplitResult.Length - 1; // 배열.length 로 배열의 크기를 구함. 위 설명에 의해 -1해서 사용한 모습

                for (int i = 0; i < List_Count; i++)
                {
                    FTP_Name_List.Add(SplitResult[i]);
                    FTP_Detail_List.Add(ini.Load(Application.StartupPath + "\\Setting.ini", "FTP_List", SplitResult[i]));
                    FTP_Lst_List.Items.Add(SplitResult[i]);
                }
            }
            catch { }*/
        }

        private void FTP_Btn_Ok_Click(object sender, EventArgs e)
        {
            string Temp_Txt_Server = FTP_Txt_Server.Text;
            
            if (!Temp_Txt_Server.Contains("ftp://"))
            {
                Temp_Txt_Server = "ftp://" + Temp_Txt_Server;
            }

            if ((richTextBoxForm.ftp_ip == Temp_Txt_Server && richTextBoxForm.ftp_id == FTP_Txt_Id.Text && richTextBoxForm.ftp_pw == FTP_Txt_Pw.Text))

            {
                ini.Save(Application.StartupPath + "\\Setting.ini", "FTP_List", "FTP_Description", FTP_Txt_Inf.Text);
                ini.Save(Application.StartupPath + "\\Setting.ini", "FTP_List", "FTP_Server", Temp_Txt_Server);
                ini.Save(Application.StartupPath + "\\Setting.ini", "FTP_List", "FTP_ID", FTP_Txt_Id.Text);
                ini.Save(Application.StartupPath + "\\Setting.ini", "FTP_List", "FTP_PW", FTP_Txt_Pw.Text);

                richTextBoxForm.Load_FTP_Setting();
                this.Close(); // 해당 폼 종료

            }
            else
            {
                if (MessageBox.Show("FTP 관련 설정이 바뀌면 열려있는 FTP에 대한 탭이 저장되지 않고 닫힙니다.\n 저장이 필요한경우 '아니오'를 누른 후 파일을 저장하십시오. \n계속하시겠습니까?", "확인", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    for (int i = richTextBoxForm.myTabControlZ.TabCount - 1; i >= 0; i--)
                    {
                        if (richTextBoxForm.OpenedFilesList[i].Contains("ftp://"))
                        {
                            richTextBoxForm.myTabControlZ.TabPages.Remove(richTextBoxForm.myTabControlZ.TabPages[i]);
                            richTextBoxForm.OpenedFilesList.RemoveAt(i);
                        }
                    }
                    ini.Save(Application.StartupPath + "\\Setting.ini", "FTP_List", "FTP_Description", FTP_Txt_Inf.Text);
                    ini.Save(Application.StartupPath + "\\Setting.ini", "FTP_List", "FTP_Server", Temp_Txt_Server);
                    ini.Save(Application.StartupPath + "\\Setting.ini", "FTP_List", "FTP_ID", FTP_Txt_Id.Text);
                    ini.Save(Application.StartupPath + "\\Setting.ini", "FTP_List", "FTP_PW", FTP_Txt_Pw.Text);

                    richTextBoxForm.Load_FTP_Setting();
                    this.Close(); // 해당 폼 종료
                }
            }


            /*
            string FTP_List_Text = "";

            
             FTP_List 섹션에 몇개의 Key들의 리스트를 구하기위해서
             별도로 FTP_List라는 Key를 만들어서 Key들의 리스트를 그곳에 저장함.
             
            for (int i = 0; i < FTP_Lst_List.Items.Count; i++)
            {
                FTP_List_Text += FTP_Name_List[i] + "||";
            }

            //FTP_List Section에 Key들의 리스트를 담은 FTP_List Section 속에 FTP_List라는 Key들
            ini.Save(Application.StartupPath + "\\Setting.ini", "FTP_List", "FTP_List", FTP_List_Text);


            for (int i = 0; i < FTP_Lst_List.Items.Count; i++)
            {
                ini.Save(Application.StartupPath + "\\Setting.ini", "FTP_List", FTP_Name_List[i], FTP_Detail_List[i]);
            }
            */

        }

        private void FTP_Btn_Add_Click(object sender, EventArgs e)
        {
            FTP_Name_List.Add("New FtpAccount");
            FTP_Detail_List.Add("||||||||");
            FTP_Lst_List.Items.Add("New FtpAccount");
            FTP_Lst_List.SelectedIndex = FTP_Lst_List.Items.Count - 1;

            FTP_Txt_Server.Text = "";
            FTP_Txt_Id.Text = "";
            FTP_Txt_Pw.Text = "";
            FTP_Txt_Inf.Focus();

        }

        private void FTP_Btn_Remove_Click(object sender, EventArgs e)
        {
            if (FTP_Lst_List.SelectedIndex > -1)
            {
                int Idx = FTP_Lst_List.SelectedIndex;
                FTP_Lst_List.Items.RemoveAt(Idx);
                FTP_Name_List.RemoveAt(Idx);
                FTP_Detail_List.RemoveAt(Idx);
            }
        }

        private void FTP_Lst_List_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (FTP_Lst_List.SelectedIndex > -1)
            {
                string[] SplitResult = FTP_Detail_List[FTP_Lst_List.SelectedIndex].Split(new string[] { "||" }, StringSplitOptions.None);
                FTP_Txt_Inf.Text = FTP_Lst_List.Items[FTP_Lst_List.SelectedIndex].ToString();
                FTP_Txt_Server.Text = SplitResult[0];
                FTP_Txt_Id.Text = SplitResult[1];
                FTP_Txt_Pw.Text = SplitResult[2];
            }
        }

        private void FTP_Btn_No_Click(object sender, EventArgs e)
        {
            this.Close(); // 해당 폼 종료
        }

        private void FTP_Txt_Inf_TextChanged(object sender, EventArgs e)
        {
            if (FTP_Lst_List.SelectedIndex > -1)
            {
                FTP_Name_List[FTP_Lst_List.SelectedIndex] = FTP_Txt_Inf.Text;
                FTP_Lst_List.Items[FTP_Lst_List.SelectedIndex] = FTP_Txt_Inf.Text;
                FTP_Detail_List[FTP_Lst_List.SelectedIndex] = FTP_Txt_Server.Text + "||" + FTP_Txt_Id.Text + "||" + FTP_Txt_Pw.Text;
            }
        }

        private void FTP_Txt_Server_TextChanged(object sender, EventArgs e)
        {
            if (FTP_Lst_List.SelectedIndex > -1)
            {
                FTP_Detail_List[FTP_Lst_List.SelectedIndex] = FTP_Txt_Server.Text + "||" + FTP_Txt_Id.Text + "||" + FTP_Txt_Pw.Text;
            }

        }

        private void FTP_Txt_Id_TextChanged(object sender, EventArgs e)
        {
            if (FTP_Lst_List.SelectedIndex > -1)
            {
                FTP_Detail_List[FTP_Lst_List.SelectedIndex] = FTP_Txt_Server.Text + "||" + FTP_Txt_Id.Text + "||" + FTP_Txt_Pw.Text;
            }
        }

        private void FTP_Txt_Pw_TextChanged(object sender, EventArgs e)
        {
            if (FTP_Lst_List.SelectedIndex > -1)
            {
                FTP_Detail_List[FTP_Lst_List.SelectedIndex] = FTP_Txt_Server.Text + "||" + FTP_Txt_Id.Text + "||" + FTP_Txt_Pw.Text;
            }
        }

        private void FTP_Txt_Directory_TextChanged(object sender, EventArgs e)
        {
            if (FTP_Lst_List.SelectedIndex > -1)
            {
                FTP_Detail_List[FTP_Lst_List.SelectedIndex] = FTP_Txt_Server.Text + "||" + FTP_Txt_Id.Text + "||" + FTP_Txt_Pw.Text;
            }
        }
    }
}
