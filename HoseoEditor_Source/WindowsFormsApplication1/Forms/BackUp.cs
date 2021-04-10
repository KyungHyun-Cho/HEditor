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
    public partial class BackUp : Form
    {
        iniModule.iniModule ini = new iniModule.iniModule(); // ini모듈을 사용하기 위해서는 iniModule 인스턴스 생성 필수.

        public BackUp()
        {
            InitializeComponent();
        }

        private void BackUp_Btn_No_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BackUp_Load(object sender, EventArgs e)
        {

            try
            {
                BackUp_Chk_FarFile.Checked = bool.Parse(ini.Load(Application.StartupPath + "\\Setting.ini", "BackUp", "Chk_FarFile"));
                BackUp_Chk_DirName.Checked = bool.Parse(ini.Load(Application.StartupPath + "\\Setting.ini", "BackUp", "Chk_DirName"));
                BackUp_Chk_DateTime.Checked = bool.Parse(ini.Load(Application.StartupPath + "\\Setting.ini", "BackUp", "Chk_DateTime"));
                BackUp_Txt_Directory.Text = ini.Load(Application.StartupPath + "\\Setting.ini", "BackUp", "Txt_Directory");
                BackUp_Txt_FileEx.Text = ini.Load(Application.StartupPath + "\\Setting.ini", "BackUp", "Txt_FileEx");
            }
            catch { }
        }

        private void BackUp_Btn_Ok_Click(object sender, EventArgs e)
        {
            ini.Save(Application.StartupPath + "\\Setting.ini", "BackUp", "Chk_FarFile", BackUp_Chk_FarFile.Checked.ToString());
            ini.Save(Application.StartupPath + "\\Setting.ini", "BackUp", "Chk_DirName", BackUp_Chk_DirName.Checked.ToString());
            ini.Save(Application.StartupPath + "\\Setting.ini", "BackUp", "Chk_DateTime", BackUp_Chk_DateTime.Checked.ToString());
            ini.Save(Application.StartupPath + "\\Setting.ini", "BackUp", "Txt_Directory", BackUp_Txt_Directory.Text);
            ini.Save(Application.StartupPath + "\\Setting.ini", "BackUp", "Txt_Directory", BackUp_Txt_FileEx.Text);


            this.Close();
        }
        
    }
}
