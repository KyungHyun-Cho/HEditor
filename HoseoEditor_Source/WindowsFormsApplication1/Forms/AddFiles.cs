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
    public partial class AddFiles : Form
    {
        public GeneralSetting SettingForm;
        public AddFiles(GeneralSetting settingForm)
        {
            SettingForm = settingForm;
            InitializeComponent();
        }

        private void AddFiles_Load(object sender, EventArgs e)
        {

        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            SettingForm.Set_Lst_FileSort.Items.Add(txt_Description.Text);
            SettingForm.Set_Name_List.Add(txt_Description.Text);
            SettingForm.Set_Detail_List.Add("");
            SettingForm.Set_Lst_FileSort.SelectedIndex = SettingForm.Set_Lst_FileSort.Items.Count - 1;
            this.Close();

        }

        private void txt_Description_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btn_OK_Click(sender, null);
            }
        }
        
    }
}
