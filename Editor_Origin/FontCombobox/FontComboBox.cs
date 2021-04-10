using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace System.Windows.Forms
{
    public class FontComboBox : ComboBox
    {
        public FontComboBox()
        {
            this.comboBox1 = this;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(12, 12);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(90, 23);
            this.comboBox1.TabIndex = 1;

            //OwnerDrawVariable
            this.comboBox1.DrawMode = DrawMode.OwnerDrawVariable;
            this.comboBox1.MaxDropDownItems = 30;
            this.comboBox1.DropDownWidth = 200;




            this.comboBox1.Text = "Times New Roman";
            this.comboBox1.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.comboBox1_DrawItem);
            this.comboBox1.MeasureItem += new System.Windows.Forms.MeasureItemEventHandler(this.comboBox1_MeasureItem);
        }

        //这么写原因
        //1 comboBox1.Items初始化在Form1.Designer.cs产生了大量的代码 多出165行代码 我的系统上有165种字体
        //        
        //private void Form1_Load(object sender, EventArgs e)
        //{
        //    fontComboBox1.Initialize();
        //}
        public void Initialize()
        {
            this.comboBox1.Items.Clear();
            foreach (FontFamily f in FontFamily.Families)
            {
                comboBox1.Items.Add(f.Name);
            }
        }


        private System.Windows.Forms.ComboBox comboBox1;

        private void comboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            //e.DrawFocusRectangle();
            string s = comboBox1.Items[e.Index].ToString();

            string fontName = comboBox1.Items[e.Index].ToString();
            Font font = new Font(fontName, 12);

            e.Graphics.DrawString(s, font, Brushes.Black, e.Bounds);
        }

        private void comboBox1_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 20;
        }
    }
}
