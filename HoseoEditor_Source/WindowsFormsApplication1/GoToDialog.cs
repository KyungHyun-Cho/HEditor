using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
 

namespace System.Windows.Forms
{
    public partial class frm_GOTO : Form
    {
        public frm_GOTO()
        {
            InitializeComponent();
            EnableButton();
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            EnableButton();
        }


        private void EnableButton()
        {
            try
            {
                int i = Convert.ToInt32((textBox1.Text));
                BtnOK.Enabled = true;
            }
            catch  
            {
                BtnOK.Enabled = false;
            }
        }
    }
}
