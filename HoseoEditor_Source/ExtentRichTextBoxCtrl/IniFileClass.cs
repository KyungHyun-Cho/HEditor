using System;
using System.Text;
using System.Runtime.InteropServices;




//是关键字的值(VALUE).例如:
//[Section1]
//    KeyWord1 = Value1
//    KeyWord2 = Value2
//    ...
//[Section2]
//    KeyWord3 = Value3
//    KeyWord4 = Value4

namespace System.IniFiles
{
    public class IniFileClass
    {
        
        public IniFileClass(string absFileName)
        {
            FFileName = absFileName;
        }
        private string FFileName;


        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        #region 基础
        private void WriteValue(string Section, string KeyWord, string Value, string FileName)
        {
            WritePrivateProfileString(Section, KeyWord, Value, FileName);
        }

        private string ReadValue(string Section, string KeyWord, string DefaultValue, string FileName)
        {
            StringBuilder temp = new StringBuilder(1024);
            int i = GetPrivateProfileString(Section, KeyWord ,"", temp, 1024, FileName);

            string result = temp.ToString();
            if (result == "")
                result = DefaultValue;
            return result;
        }


        #endregion

        #region  字符串的读写

        public void WriteString(string Section, string KeyWord, string value)
        {
            WriteValue(Section, KeyWord, value, FFileName);
        }

        public string ReadString(string Section, string KeyWord, string DefaultValue)
        {
            return ReadValue(Section, KeyWord, DefaultValue, FFileName);
        }

        #endregion

        #region  整型的读写

        public void WriteInteger(string Section, string KeyWord, int Value)
        {
            WriteValue(Section, KeyWord, Value.ToString(), FFileName);
        }


        public int ReadInteger(string Section, string KeyWord, int DefaultValue)
        {
            string Result = ReadValue(Section, KeyWord, DefaultValue.ToString(), FFileName);
            return Convert.ToInt32(Result);
        }
        #endregion
 




    }
}
