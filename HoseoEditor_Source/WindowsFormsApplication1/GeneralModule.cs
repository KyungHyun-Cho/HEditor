using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;   //class 추가

namespace MainFormRichTextBox
{
    class GeneralModule
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        public void iniSave(string Path, string Section, string Key, string Value)
        {
            WritePrivateProfileString(Section, Key, Value, Path);
        }

        public string iniLoad(string Path, string Section, string Key)
        {
            StringBuilder temp = new StringBuilder();
            GetPrivateProfileString(Section, Key, "(NONE)", temp, 32, Path);
            return temp.ToString();
        }

    }
    public static class global
    {
        public static string[] Split(this string Expression, string Delimiter = " ")
        {
            return Expression.Split(new string[] { Delimiter }, StringSplitOptions.None);
        }
    }
}
