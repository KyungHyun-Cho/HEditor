using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
 

namespace System.Windows.Forms
{
    public partial class ViewRtfSoruceDlg : Form
    {
        public ViewRtfSoruceDlg()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            buttonAccept.Enabled = textBox1.Text != "";
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {

        }
    }
}
