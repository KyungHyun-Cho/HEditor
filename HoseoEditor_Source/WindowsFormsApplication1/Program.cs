using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MainFormRichTextBox
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Application.Run(new WebbrowserForm());
            //Application.Run(new Form1());
            //Application.Run(new FormMain());
            //Application.Run(new OptionsDialog());

            Application.Run(new RichTextBoxForm());
            //Application.Run(new FileListViewForm());
            //Application.Run(new RenameMultipFileDialog());
            //Application.Run(new DirectoryTreeViewForm());

             //Application.Run(new AttachmentDialog());
            // Application.Run(new FindDialog());
            // Application.Run(new ReplaceDialog());
            // Application.Run(new FindReplaceDialog());
        }
    }
}
