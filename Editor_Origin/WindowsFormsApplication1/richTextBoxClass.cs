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
        /// 新建 RTF 文档 新建 RTF 文档(2) 新建 RTF 文档(3)...
        /// string s = CreateRtfFile2(@"C:\Users\Admin\Desktop\");
        /// richTextBox1.AppendText(s + "\r\n");
        /// </summary>
        /// <param name="path"></param>
        /// <returns>返回当前创建的文件名 如 “新建 RTF 文档” </returns>
        public static string CreateRtfFile2(string path)
        {
            //string path = @"C:\Users\Admin\Desktop\";
            string FileTitle = "新建 RTF 文档";
            string FileExt = ".rtf";
            string Result = FileTitle;

            string s1 = path + FileTitle + FileExt;

            int j = 2;
            if (System.IO.File.Exists(s1))
            {
                string s = String.Format("{0}{1}({2}){3}", path, FileTitle, j, FileExt);

                while (System.IO.File.Exists(s))
                {
                    j++;
                    s = String.Format("{0}{1}({2}){3}", path, FileTitle, j, FileExt);
                }
                if (!System.IO.File.Exists(s))
                {
                    CreateRtfFile(s);
                    FileTitle = System.IO.Path.GetFileNameWithoutExtension(s);
                }
            }
            else
                CreateRtfFile(s1);
            return FileTitle;
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
