using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace System.Windows.Forms
{
    public class FontSizeComboBox : ComboBox
    {
        public FontSizeComboBox()
        {
            this.comboBox1 = this;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(40, 23);
            this.comboBox1.TabIndex = 1;
            //this.comboBox1.Sorted = true;

            //OwnerDrawVariable
            this.comboBox1.DrawMode = DrawMode.OwnerDrawVariable;
            this.comboBox1.MaxDropDownItems = 40;
            this.comboBox1.DropDownHeight = 406;
            this.comboBox1.DropDownWidth = 200;
            this.comboBox1.Text = "9";                   
            this.comboBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBox1_DrawItem);
            this.comboBox1.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.comboBox1_MeasureItem);
        }

        //这么写原因有2
        //1 comboBox1.Items的赋值了2次
        //2 comboBox1.Items初始化在Form1.Designer.cs产生了大量的代码
        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    fontSizeComboBox1.Initialize();
        //}
        public void Initialize()
        {

            this.comboBox1.Items.Clear();
            this.comboBox1.Items.AddRange(new string[] {
            "8",
            "9",
            "10",
            "11",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24",
            "26",
            "28",
            "36",
            "48",
            "72"});
        }

        private System.Windows.Forms.ComboBox comboBox1;

        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            //e.DrawFocusRectangle();

            string s = comboBox1.Items[e.Index].ToString();
            int fontSize = Convert.ToInt32(comboBox1.Items[e.Index].ToString());
            Font font = new Font("Times New Roman", fontSize);

            e.Graphics.DrawString(s, font, Brushes.Black, e.Bounds);
        }

        private void comboBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = Convert.ToInt32(comboBox1.Items[e.Index].ToString()) + 12;
        }

    }
}
