using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
namespace RichTextBoxCtrl
{
    class richTextBoxClass
    {



        /// <summary>
        /// 创建一个空的RTF文件
        /// </summary>
        /// <param name="RtfFileName"></param>
        public static void CreateRtfFile(string RtfFileName)
        {
            RichTextBox richTextBox1 = new RichTextBox();
            richTextBox1.SaveFile(RtfFileName);
        }
        

        /// <summary>
        /// 把RTF文件保存为纯文本
        /// 只保存字符 转换后文本不包括RTF中的图片信息
        ///  SavetRtfToTextFile(@"C:\Users\Admin\Desktop\CurRoleBase.rtf", @"C:\Users\Admin\Desktop\CurRoleBase.txt");
        /// </summary>
        /// <param name="RtfFileName">"C:\Users\Admin\Desktop\CurRoleBase.rtf"</param>
        /// <param name="TextFileName">"C:\Users\Admin\Desktop\CurRoleBase.txt"</param>
        public static void SavetRtfToTextFile(string RtfFileName, string TextFileName)
        {
            RichTextBox richTextBox1 = new RichTextBox();
            richTextBox1.LoadFile(RtfFileName);
            richTextBox1.SaveFile(TextFileName, RichTextBoxStreamType.TextTextOleObjs);
        }

    }
}
