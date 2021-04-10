using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace iniModule
{

    public class iniModule
    {
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal,
                                                        int size, string filePath);

        
        
        public void Save(string path, string section, string key, string value)
        {
            WritePrivateProfileString(section, key, value, path);
        }
            
        public string Load(string Path, string section, string key)
        {
            
            StringBuilder temp = new StringBuilder();

            GetPrivateProfileString(section, key, "(NONE)", temp, 32, Path);
            return temp.ToString();
        }
            
        
    }
}
