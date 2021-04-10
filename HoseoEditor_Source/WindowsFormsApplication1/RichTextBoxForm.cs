using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.IO;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using AdvancedNotepad_CSharp;
using System.Diagnostics;
using MainFormRichTextBox.Forms;
using System.Threading;
using System.Net;

namespace MainFormRichTextBox
{

    public partial class RichTextBoxForm : Form
    {

        //FTP ip id pw path isftp
        public string ftp_ip = "";
        public string ftp_id = "";
        public string ftp_pw = "";
        public bool global_isFTP;                                       //true=FTP flase=Local
        public string ftp_path;                                         //FTP path
        public string local_path = Application.StartupPath + @"\\Temp" + "\\"; //FTP<-->Local path

        public List<String> OpenedFilesList = new List<String> { };
        public List<string> fFormatList = new List<string>();
        public List<string> SyntaxFileList = new List<string>();

        public string Txt_AutoSaveTime;
        public string Txt_BackUpDirectory;
        public string Txt_BackUpFormat;
        public int Cbx_BasicEncode;
        public string Txt_AutoBackUpTime;
        public bool Chk_DirName;
        public bool Chk_DateTime;
        public bool Chk_FtpFile;
        public bool Chk_OpenBU;
        public bool Chk_SaveBU;
        public bool Chk_FCloseBU;


        iniModule.iniModule ini = new iniModule.iniModule();
        public string DeveloperfFormat = "";

        public string[] Split(string Expression, string Delimiter)
        {
            return global.Split(Expression, Delimiter);
        }
        public void BackUpFile(int i)
        {
            string timePlus = "";
            string dirPlus = "";
            if (Chk_DirName)
            {
                dirPlus = "_(" + OpenedFilesList[i].Replace("\\", "_").Replace("/", "_").Replace(":", "").Replace("*","") + ")";
            }
            if (Chk_DateTime == true)
            {
                timePlus = "_(" + DateTime.Now.ToString("yyyy_MM_dd hh_mm_ss") + ")";
            }
            TabPage tabpage = myTabControlZ.TabPages[i];
            if (OpenedFilesList[i].Contains("\\") || OpenedFilesList[i].Contains("ftp://"))
            {
                try
                {
                    var _myRichTextBox = (MyRichTextBox)myTabControlZ.TabPages[i].Controls[0];
                    try
                    {
                        File.WriteAllText(Txt_BackUpDirectory + getFileName(OpenedFilesList[i]) + dirPlus + timePlus + Txt_BackUpFormat, "");
                        StreamWriter strwriter = System.IO.File.AppendText(Txt_BackUpDirectory + getFileName(OpenedFilesList[i]) + dirPlus + timePlus + Txt_BackUpFormat);
                        strwriter.Write(_myRichTextBox.richTextBox1.Text);
                        strwriter.Close();
                        strwriter.Dispose();
                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show(tabpage.Text + "탭의 파일 백업중 다음 오류가 발생했습니다. \n 오류 내용 : " + ex.Message);
                    }
                }
                catch
                {
                    var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[i].Controls[1];
                    try
                    {
                        File.WriteAllText(Txt_BackUpDirectory + getFileName(OpenedFilesList[i]) + dirPlus + timePlus + Txt_BackUpFormat, "");
                        StreamWriter strwriter = System.IO.File.AppendText(Txt_BackUpDirectory + getFileName(OpenedFilesList[i]) + dirPlus + timePlus + Txt_BackUpFormat);
                        strwriter.Write(_myRichTextBox.Text);
                        strwriter.Close();
                        strwriter.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(tabpage.Text + "파일 백업중 다음 오류가 발생했습니다. \n 오류 내용 : " + ex.Message);
                    }

                }


            }

            UpdateCaption();
            UpdateStatusStripButton();
        }
        public void Load_General_Setting()
        {
            int AutoSaveTime = 1;
            int AutoBackupTime = 1;
            try
            {
                Txt_AutoSaveTime = ini.Load(Application.StartupPath + "\\Setting.ini", "File", "Txt_AutoSaveTime");
                Txt_BackUpDirectory = ini.Load(Application.StartupPath + "\\Setting.ini", "File", "Txt_BackUpDirectory");
                Txt_BackUpFormat = ini.Load(Application.StartupPath + "\\Setting.ini", "File", "Txt_BackUpFormat");
                Cbx_BasicEncode = int.Parse(ini.Load(Application.StartupPath + "\\Setting.ini", "File", "Cbx_BasicEncode"));
                Txt_AutoBackUpTime = ini.Load(Application.StartupPath + "\\Setting.ini", "File", "Txt_AutoBackUpTime");
                Chk_DirName = bool.Parse(ini.Load(Application.StartupPath + "\\Setting.ini", "File", "Chk_DirName"));
                Chk_DateTime = bool.Parse(ini.Load(Application.StartupPath + "\\Setting.ini", "File", "Chk_DateTime"));
                Chk_FtpFile = bool.Parse(ini.Load(Application.StartupPath + "\\Setting.ini", "File", "Chk_FtpFile"));
                Chk_OpenBU = bool.Parse(ini.Load(Application.StartupPath + "\\Setting.ini", "File", "Chk_OpenBU"));
                Chk_SaveBU = bool.Parse(ini.Load(Application.StartupPath + "\\Setting.ini", "File", "Chk_SaveBU"));
                Chk_FCloseBU = bool.Parse(ini.Load(Application.StartupPath + "\\Setting.ini", "File", "Chk_FCloseBU"));

                if (int.TryParse(Txt_AutoSaveTime, out AutoSaveTime) == true)
                {
                    if (AutoSaveTime > 0)
                    {
                        saveTimer.Enabled = true;
                        saveTimer.Interval = AutoSaveTime * 1000;
                    }
                    else
                    {
                        saveTimer.Enabled = false;
                    }
                }
                if (int.TryParse(Txt_AutoBackUpTime, out AutoBackupTime) == true)
                {
                    if (AutoBackupTime > 0)
                    {
                        backUpTimer.Enabled = true;
                        backUpTimer.Interval = AutoBackupTime * 1000;
                    }
                    else
                    {
                        backUpTimer.Enabled = false;
                    }
                }

            }
            catch (Exception ex) { MessageBox.Show("설정 값을 불러오는 도중 오류가 발생했습니다.\n 오류내용 : " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error); }
        }
        public void Load_FTP_Setting()
        {
            DirectorySession.Items[1] = "[FTP] " + ini.Load(Application.StartupPath + "\\Setting.ini", "FTP_List", "FTP_Description");
            ftp_ip = ini.Load(Application.StartupPath + "\\Setting.ini", "FTP_List", "FTP_Server");
            ftp_id = ini.Load(Application.StartupPath + "\\Setting.ini", "FTP_List", "FTP_ID");
            ftp_pw = ini.Load(Application.StartupPath + "\\Setting.ini", "FTP_List", "FTP_PW");
        }
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "확인";
            buttonCancel.Text = "취소";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        public bool FTP_Upload(string sourcePath, string destinationPath)
        {
            try
            {
                FtpWebRequest requestFTPUploader =
                (FtpWebRequest)WebRequest.Create(destinationPath);//FP_ToolStrip.Text

                requestFTPUploader.Credentials = new NetworkCredential(ftp_id, ftp_pw);
                requestFTPUploader.Method = WebRequestMethods.Ftp.UploadFile;

                FileInfo fileInfo = new FileInfo(sourcePath);//로컬파일
                FileStream fileStream = fileInfo.OpenRead();

                int bufferLength = 2048;
                byte[] buffer = new byte[bufferLength];

                Stream uploadStream = requestFTPUploader.GetRequestStream();
                int contentLength = fileStream.Read(buffer, 0, bufferLength);
                while (contentLength != 0)
                {
                    uploadStream.Write(buffer, 0, contentLength);
                    contentLength = fileStream.Read(buffer, 0, bufferLength);
                }

                uploadStream.Close();
                fileStream.Close();

                requestFTPUploader = null;


                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public bool FTP_FileOpen()
        {
            if (global_isFTP == true && FileList.SelectedIndex > -1)
            {
                try
                {
                    string destinationPath = local_path;  //local 저장위치 (Application.StartupPath + @"\\Temp" + "\\")
                    string fileName = FileList.SelectedItem.ToString(); // 파일네임 새로 구해야함 , 다운로드할때는 상관이 없으나 업로드시에는 필요
                    string sourcePath = ftp_ip + "/" + ftp_path + "/" + fileName;
                    FtpWebRequest requestFileDownload =
                        (FtpWebRequest)WebRequest.Create(sourcePath); // ftp_ip + "/" + ftp_path + "/" + fileName

                    requestFileDownload.Credentials = new NetworkCredential(ftp_id, ftp_pw);
                    requestFileDownload.Method = WebRequestMethods.Ftp.DownloadFile;

                    FtpWebResponse responseFileDownload =
                    (FtpWebResponse)requestFileDownload.GetResponse();

                    Stream responseStream = responseFileDownload.GetResponseStream();
                    int Length = 2048;
                    char[] buffer = new char[Length];

                    using (var reader = new StreamReader(responseStream, Encoding.UTF8)) // 인코딩부분
                    {
                        using (var tw = new StreamWriter(destinationPath + fileName, false, Encoding.UTF8)) //인코딩부분
                        {
                            while (true)
                            {
                                int ReadCount = reader.Read(buffer, 0, buffer.Length);
                                if (ReadCount == 0) break;
                                tw.Write(buffer, 0, ReadCount);
                            }
                            string ResponseDescription = responseFileDownload.StatusDescription;
                            responseStream.Close();
                            reader.Close();
                            tw.Close();
                        }
                    }

                    requestFileDownload = null;
                    responseFileDownload = null;

                    if (File.Exists(destinationPath + fileName))
                    {
                        if (DeveloperfFormat.Contains(getFormat(destinationPath + fileName)))
                        {
                            OpenDeveloperFile(destinationPath + fileName, sourcePath);
                            File.Delete(destinationPath + fileName);
                        }
                        else
                        {
                            OpenNormalFile(destinationPath + fileName, sourcePath);
                            File.Delete(destinationPath + fileName);
                        }
                        UpdateStatusStripButton();
                        UpdateCaption();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("파일을 여는 도중 오류가 발생하였습니다.\n 오류내용 : " + ex.Message);
                    return false;
                }
            }
            else
            {
                return false;
            }

        }
        //@@ FTP_Download 오버로딩
        public bool FTP_Download(string sourcePath, string destinationPath)
        {
            if (global_isFTP == true && FileList.SelectedIndex > -1)
            {
                try
                {
                    string fileName = FileList.SelectedItem.ToString(); // 파일네임 새로 구해야함 , 다운로드할때는 상관이 없으나 업로드시에는 필요

                    FtpWebRequest requestFileDownload =
                        (FtpWebRequest)WebRequest.Create(sourcePath); // ftp_ip + "/" + ftp_path + "/" + fileName

                    requestFileDownload.Credentials = new NetworkCredential(ftp_id, ftp_pw);
                    requestFileDownload.Method = WebRequestMethods.Ftp.DownloadFile;

                    FtpWebResponse responseFileDownload =
                    (FtpWebResponse)requestFileDownload.GetResponse();

                    Stream responseStream = responseFileDownload.GetResponseStream();
                    FileStream writeStream = new FileStream(destinationPath + "\\" + fileName, FileMode.Create);

                    int Length = 2048;
                    Byte[] buffer = new Byte[Length];
                    int bytesRead = responseStream.Read(buffer, 0, Length);

                    while (bytesRead > 0)
                    {
                        writeStream.Write(buffer, 0, bytesRead);
                        bytesRead = responseStream.Read(buffer, 0, Length);
                    }

                    responseStream.Close();
                    writeStream.Close();

                    requestFileDownload = null;
                    responseFileDownload = null;

                    return true;
                }
                catch
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

        }

        public void getDeveloperfFormat()
        {
            DeveloperfFormat = "";
            fFormatList.Clear();
            SyntaxFileList.Clear();

            string[] SyntaxSubject = ini.Load(Application.StartupPath + "\\Setting.ini", "Set_List", "Set_List").Split(new string[] { "||" }, StringSplitOptions.None);
            string[] SplitResult2;
            int List_Count = SyntaxSubject.Length - 1; // 배열.length 로 배열의 크기를 구함. 위 설명에 의해 -1해서 사용한 모습
            string Temp;
            for (int i = 0; i < List_Count; i++)
            {
                Temp = ini.Load(Application.StartupPath + "\\Setting.ini", "Set_List", SyntaxSubject[i]);
                SplitResult2 = Temp.Split(new string[] { "||" }, StringSplitOptions.None);
                Temp = SplitResult2[0];
                fFormatList.Add(SplitResult2[0]);
                SyntaxFileList.Add(SplitResult2[1]);
                DeveloperfFormat += Temp + ";";
            }
        }
        public void SetSyntaxDeveloperEditor()
        {
            var _myRichTextBox = (MyRichTextBox)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[0];
            string fFormat = getFormat(myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Text);
            string syntaxFilePath = "";


            for (int i = 0; i < fFormatList.Count; i++)
            {
                if (fFormatList[i].Contains(fFormat.Replace("*", "")))
                {
                    syntaxFilePath = SyntaxFileList[i];
                }
            }
            if (File.Exists(Application.StartupPath + "\\stxList\\" + syntaxFilePath))
            {
                string path = Application.StartupPath + "\\stxList\\" + syntaxFilePath;
                StreamReader strReader;

                strReader = new StreamReader(path);
                string str = strReader.ReadToEnd();
                strReader.Close();

                //new string[] { "||" }, StringSplitOptions.None
                string[] KeywordsList = Split(Split(str, "#KeyWordStart")[1], "#KeyWordEnd")[0].Trim().Split('\n');
                string[] ContextualKeywordsList = Split(Split(str, "#Contextual KeywordsStart")[1], "#Contextual KeywordsEnd")[0].Trim().Split('\n');
                string[] UserDefine1List = Split(Split(str, "#UserDefine1Start")[1], "#UserDefine1End")[0].Trim().Split('\n');
                string[] UserDefine2List = Split(Split(str, "#UserDefine2Start")[1], "#UserDefine2End")[0].Trim().Split('\n');
                string[] UserDefine3List = Split(Split(str, "#UserDefine3Start")[1], "#UserDefine3End")[0].Trim().Split('\n');


                for (int i = 0; i < KeywordsList.Length; i++)
                    _myRichTextBox.richTextBox1.Settings.Keywords.Add(KeywordsList[i].Replace("\n", "").Replace("\r", ""));
                for (int i = 0; i < ContextualKeywordsList.Length; i++)
                    _myRichTextBox.richTextBox1.Settings.ContextualKeywords.Add(ContextualKeywordsList[i].Replace("\n", "").Replace("\r", ""));
                for (int i = 0; i < UserDefine1List.Length; i++)
                    _myRichTextBox.richTextBox1.Settings.UserDefine1.Add(UserDefine1List[i].Replace("\n", "").Replace("\r", ""));
                for (int i = 0; i < UserDefine2List.Length; i++)
                    _myRichTextBox.richTextBox1.Settings.UserDefine2.Add(UserDefine2List[i].Replace("\n", "").Replace("\r", ""));
                for (int i = 0; i < UserDefine3List.Length; i++)
                    _myRichTextBox.richTextBox1.Settings.UserDefine3.Add(UserDefine3List[i].Replace("\n", "").Replace("\r", ""));




                string colorA;
                string colorR;
                string colorG;
                string colorB;
                string colors;
                // Set the comment identifier. For Lua this is two minus-signs after each other (--). 
                // For C++ we would set this property to "//".
                _myRichTextBox.richTextBox1.Settings.Comment = "//";


                // Set the colors that will be used.
                colors = ini.Load(path, "KeyWord", "Color");
                colorA = colors.Split('/')[0];
                colorR = colors.Split('/')[1];
                colorG = colors.Split('/')[2];
                colorB = colors.Split('/')[3];
                _myRichTextBox.richTextBox1.Settings.KeywordColor = Color.FromArgb(int.Parse(colorA), int.Parse(colorR), int.Parse(colorG), int.Parse(colorB));

                colors = ini.Load(path, "Contextual Keywords", "Color");
                colorA = colors.Split('/')[0];
                colorR = colors.Split('/')[1];
                colorG = colors.Split('/')[2];
                colorB = colors.Split('/')[3];
                _myRichTextBox.richTextBox1.Settings.ContextualColor = Color.FromArgb(int.Parse(colorA), int.Parse(colorR), int.Parse(colorG), int.Parse(colorB));

                colors = ini.Load(path, "UserDefine1", "Color");
                colorA = colors.Split('/')[0];
                colorR = colors.Split('/')[1];
                colorG = colors.Split('/')[2];
                colorB = colors.Split('/')[3];
                _myRichTextBox.richTextBox1.Settings.UserDefine1Color = Color.FromArgb(int.Parse(colorA), int.Parse(colorR), int.Parse(colorG), int.Parse(colorB));

                colors = ini.Load(path, "UserDefine2", "Color");
                colorA = colors.Split('/')[0];
                colorR = colors.Split('/')[1];
                colorG = colors.Split('/')[2];
                colorB = colors.Split('/')[3];
                _myRichTextBox.richTextBox1.Settings.UserDefine2Color = Color.FromArgb(int.Parse(colorA), int.Parse(colorR), int.Parse(colorG), int.Parse(colorB));

                colors = ini.Load(path, "UserDefine3", "Color");
                colorA = colors.Split('/')[0];
                colorR = colors.Split('/')[1];
                colorG = colors.Split('/')[2];
                colorB = colors.Split('/')[3];
                _myRichTextBox.richTextBox1.Settings.UserDefine3Color = Color.FromArgb(int.Parse(colorA), int.Parse(colorR), int.Parse(colorG), int.Parse(colorB));

                colors = ini.Load(path, "Comment", "Color");
                colorA = colors.Split('/')[0];
                colorR = colors.Split('/')[1];
                colorG = colors.Split('/')[2];
                colorB = colors.Split('/')[3];
                _myRichTextBox.richTextBox1.Settings.CommentColor = Color.FromArgb(int.Parse(colorA), int.Parse(colorR), int.Parse(colorG), int.Parse(colorB));

                colors = ini.Load(path, "String", "Color");
                colorA = colors.Split('/')[0];
                colorR = colors.Split('/')[1];
                colorG = colors.Split('/')[2];
                colorB = colors.Split('/')[3];
                _myRichTextBox.richTextBox1.Settings.StringColor = Color.FromArgb(int.Parse(colorA), int.Parse(colorR), int.Parse(colorG), int.Parse(colorB));

                colors = ini.Load(path, "Number", "Color");
                colorA = colors.Split('/')[0];
                colorR = colors.Split('/')[1];
                colorG = colors.Split('/')[2];
                colorB = colors.Split('/')[3];
                _myRichTextBox.richTextBox1.Settings.IntegerColor = Color.FromArgb(int.Parse(colorA), int.Parse(colorR), int.Parse(colorG), int.Parse(colorB));

                // Let's not process strings and integers.
                _myRichTextBox.richTextBox1.Settings.EnableStrings = true;
                _myRichTextBox.richTextBox1.Settings.EnableIntegers = true;
                _myRichTextBox.richTextBox1.Settings.EnableLineComments = true;


                // Let's make the settings we just set valid by compiling
                // the keywords to a regular expression.
                _myRichTextBox.richTextBox1.CompileKeywords();

                // Load a file and update the syntax highlighting.
                //_myRichTextBox.richTextBox1.LoadFile("../script.lua", RichTextBoxStreamType.PlainText);
                _myRichTextBox.richTextBox1.ProcessAllLines();
            }


        }
        public RichTextBoxForm()
        {
            InitializeComponent();
            string fontName;


            fontComboBox1.Initialize();
            fontSizeComboBox1.Initialize();

        }
        public string getFormat(string path)
        {
            return path.Split(".")[path.Split(".").Length - 1];
        }
        public string getFileName(string FP)
        {
            if (FP.Contains("ftp://"))
            {
                return FP.Split("/")[FP.Split("/").Length - 1];
            }
            else
            {
                return FP.Split("\\")[FP.Split("\\").Length - 1];
            }
        }
        public void NewNormalFile()
        {
            //<수정> FTP모드인경우 무조건 DeveloperMode로 열기
            string fname = "빈 문서 " + count + ".rtf";
            MyTabPage tabpage = new MyTabPage(this, 0);
            tabpage.Text = fname;
            myTabControlZ.TabPages.Add(tabpage);
            count++;
            FP_ToolStrip.Text = fname;

            OpenedFilesList.Add(fname);
            myTabControlZ.SelectedTab = tabpage;

            var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
            _myRichTextBox.Select();
            _myRichTextBox.ContextMenuStrip = contextMenuStrip1;
        }
        public void OpenNormalFile(string path, string FP_Option)
        {
            if (OpenedFilesList.Contains(path))
            {
                myTabControlZ.SelectedIndex = OpenedFilesList.IndexOf(path);
            }
            else
            {
                MyTabPage tabpage = new MyTabPage(this, 0);
                String fname = path.Substring(path.LastIndexOf("\\") + 1);
                tabpage.Text = fname;
                myTabControlZ.TabPages.Add(tabpage);
                FP_ToolStrip.Text = path;

                if (FP_Option == "")
                {
                    OpenedFilesList.Add(path);
                }
                else
                {
                    OpenedFilesList.Add(FP_Option);
                }
                myTabControlZ.SelectedTab = tabpage;

                var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                _myRichTextBox.Select();
                _myRichTextBox.ContextMenuStrip = contextMenuStrip1;

                _myRichTextBox.AllowDrop = false;
                _myRichTextBox.OpenFilelist(path);

                fname = tabpage.Text;
                if (fname.Contains("*"))
                {
                    fname = fname.Remove(fname.Length - 1);
                }
                tabpage.Text = fname;
                if (Chk_OpenBU)
                {
                    if (FP_ToolStrip.Text.Contains("ftp://"))
                    {
                        if (Chk_FtpFile) BackUpFile(myTabControlZ.SelectedIndex);
                    }
                    else
                    {

                        BackUpFile(myTabControlZ.SelectedIndex);
                    }
                }
            }
        }
        public void OpenDeveloperFile(string path, string FP_Option)
        {
            if (OpenedFilesList.Contains(path))
            {
                myTabControlZ.SelectedIndex = OpenedFilesList.IndexOf(path);
            }
            else
            {
                label2.Location = new Point(215, 77);
                StreamReader strReader;
                String str;

                MyTabPage tabpage = new MyTabPage(this, 1);

                strReader = new StreamReader(path);
                str = strReader.ReadToEnd();
                strReader.Close();

                String fname = path.Substring(path.LastIndexOf("\\") + 1);
                tabpage.Text = fname;
                //add contextmenustrip to richTextBox1
                tabpage._developerEditor.richTextBox1.ContextMenuStrip = contextMenuStrip1;

                tabpage._developerEditor.richTextBox1.Text = str;
                myTabControlZ.TabPages.Add(tabpage);
                FP_ToolStrip.Text = path;

                //adding filenames to OpenedFilesList list
                if (FP_Option == "")
                {
                    OpenedFilesList.Add(path);
                }
                else
                {
                    OpenedFilesList.Add(FP_Option);
                }
                myTabControlZ.SelectedTab = tabpage;
                SetSyntaxDeveloperEditor();



                /* check (*) is available on TabPage Text
                 adding filename to tab page by removing (*) */
                fname = tabpage.Text;
                if (fname.Contains("*"))
                {
                    fname = fname.Remove(fname.Length - 1);
                }
                tabpage.Text = fname;





                if (myTabControlZ.SelectedIndex >= 0)
                {
                    var _myRichTextBox = (MyRichTextBox)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[0];
                    _myRichTextBox.richTextBox1.Select();
                }

                if (Chk_OpenBU)
                {
                    if (FP_ToolStrip.Text.Contains("ftp://"))
                    {
                        if(Chk_FtpFile) BackUpFile(myTabControlZ.SelectedIndex);
                    }
                    else
                    {

                        BackUpFile(myTabControlZ.SelectedIndex);
                    }
                } 
                label2.Location = new Point(9999, 9999);
            }

        }

        #region Functions...

        //AbsFileName 
        //D:\Administrator\Documents\MyProject\CSHARP_WinCtrl\WindowsFormsApplication1\bin\Debug\我的文件夹\Bugs\ToDoList.rtf
        public string AbsFileName = "";






        #region AddFont

        private void AddFont()
        {
            foreach (FontFamily fam in FontFamily.Families)
            {
                fontComboBox1.Items.Add(fam.Name);
                fontComboBox1.AutoCompleteCustomSource.Add(fam.Name);
            }

        }
        #endregion
        #region StatueStrip
        public void UpdateStatusStripButton()
        {
            Point pt;
            string modify;
            if (myTabControlZ.TabCount > 0)
            {
                if (myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[0] is MyRichTextBox)
                {
                    var _myRichTextBox = (MyRichTextBox)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[0];
                    pt = _myRichTextBox.GetCaretPosition();
                    modify = _myRichTextBox.richTextBox1.Modified ? "Modified" : "Ready";
                }
                else
                {
                    var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                    pt = _myRichTextBox.GetCaretPosition();
                    modify = _myRichTextBox.Modified ? "Modified" : "Ready";
                }

                string Col = "Column: " + pt.X;
                string Line = "Line: " + pt.Y;

                try
                {
                    FP_ToolStrip.Text = OpenedFilesList[myTabControlZ.SelectedIndex];
                }
                catch
                {
                    FP_ToolStrip.Text = "Hoseo-Editor";
                }
                toolStripStatusLabel1.Text = string.Format("{0}    {1}    {2}    {3}    {4}", modify, Line, Col, "", "");//,SelStart, SelLength);

            }


        }

        #endregion
        #endregion


        #region ToolStrip 

        private void Form1_Load(object sender, EventArgs e)
        {
            AddFont();
            getDeveloperfFormat();
            Load_FTP_Setting();
            Load_General_Setting();
            //this.BackColor = richTextBoxCtrl1.BackColor;
            customTrackBar1.BackColor = this.BackColor;
            EnabledColorPickStatus();
            DirectorySession.SelectedIndex = 0;
            UpdateStatusStripButton();
            label2.Location = new Point(9999, 9999);
        }

        private void fontComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            float fontSize;

            try
            {
                var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                try
                {
                    fontSize = _myRichTextBox.SelectionFont.Size;
                }
                catch
                {
                    fontSize = _myRichTextBox.Font.Size;
                }
                _myRichTextBox.SelectionFont = new Font(fontComboBox1.Text, fontSize);

            }
            catch
            {

            }
        }

        private void fontSizeComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string fontName;


            float fontSize = Convert.ToSingle(fontSizeComboBox1.Text);
            try
            {
                var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                try
                {
                    fontName = _myRichTextBox.SelectionFont.Name;
                }
                catch
                {
                    fontName = _myRichTextBox.Font.Name;
                }
                _myRichTextBox.SelectionFont = new Font(fontName, fontSize);
            }
            catch
            {

            }
        }

        private void BtnUnOrderlist_Click(object sender, EventArgs e)
        {
            try
            {
                var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                _myRichTextBox.SelectionBullet = !_myRichTextBox.SelectionBullet;
            }
            catch
            {

            }
        }

        private void BtnOrderlist_Click(object sender, EventArgs e)
        {
            try
            {
                var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                _myRichTextBox.SelectionOrderList = !_myRichTextBox.SelectionOrderList;
            }
            catch
            {

            }
        }

        private void BtnNew_Click(object sender, EventArgs e)
        {
            NewNormalFile();
            UpdateCaption();
            UpdateStatusStripButton();
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "모든 파일(*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                if (DeveloperfFormat.Contains(getFormat(openFileDialog1.FileName)))
                {
                    OpenDeveloperFile(openFileDialog1.FileName, "");
                }
                else
                {
                    OpenNormalFile(openFileDialog1.FileName, "");
                }
            }

            UpdateStatusStripButton();
            UpdateCaption();
        }

        public void BtnSaveAs_Click(object sender, EventArgs e)
        {
            if (myTabControlZ.TabCount > 0)
            {
                //<수정> FTP모드인경우에는 다름이름으로 저장 안됌.
                TabPage tabpage = myTabControlZ.SelectedTab;
                string fName = tabpage.Text.Replace("*", "");
                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.Filter = "모든 파일(*.*)|*.*";
                saveFileDialog1.FileName = fName + ".";
                int Mode;
                if (myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[0] is MyRichTextBox)
                {
                    Mode = 1;
                }
                else
                {
                    Mode = 0;
                }

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string filename = saveFileDialog1.FileName;

                    if (Mode == 0)
                    {
                        var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];

                        if (getFormat(saveFileDialog1.FileName).ToLower().Contains("rtf"))
                        {
                            //RTF 저장
                            _myRichTextBox.SaveFile(saveFileDialog1.FileName);
                            tabpage.Text = tabpage.Text.Replace("*", "");
                        }
                        else
                        {
                            File.WriteAllText(filename, "");
                            StreamWriter strwriter = System.IO.File.AppendText(filename);
                            strwriter.Write(_myRichTextBox.Text);
                            strwriter.Close();
                            strwriter.Dispose();
                            tabpage.Text = tabpage.Text.Replace("*", "");
                            //일반저장
                        }
                    }
                    else
                    {
                        var _myRichTextBox = (MyRichTextBox)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[0];
                        File.WriteAllText(filename, "");
                        StreamWriter strwriter = System.IO.File.AppendText(filename);
                        strwriter.Write(_myRichTextBox.richTextBox1.Text);
                        strwriter.Close();
                        strwriter.Dispose();
                        tabpage.Text = tabpage.Text.Replace("*", "");
                    }
                    int Idx = myTabControlZ.SelectedIndex;
                    OpenedFilesList[Idx] = filename;
                    myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Text = filename.Substring(filename.LastIndexOf("\\") + 1); ;
                }
            }


            UpdateCaption();
            UpdateStatusStripButton();


        }

        private void UpdateCaption()
        {
            if (myTabControlZ.TabPages.Count > 0)
            {
                Text = myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Text + " - Hoseo Editor";
            }
            else
            {
                Text = "새로운 파일을 기다리고있습니다!" + " - Hoseo Editor";
            }
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                    _myRichTextBox.ShowShowPagePriviewDlg();
                }
                catch
                {
                    var _myRichTextBox = (MyRichTextBox)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[0];
                    _myRichTextBox.ShowShowPagePriviewDlg();
                }
            }
            catch
            {
                MessageBox.Show("파일이 열려있지 않습니다. 파일을 열어주세요");
            }
        }

        private void btnPageSetUp_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                    _myRichTextBox.ShowPageSetupDlg();
                }
                catch
                {
                    var _myRichTextBox = (MyRichTextBox)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[0];
                    _myRichTextBox.ShowPageSetupDlg();
                }
            }
            catch
            {
                MessageBox.Show("파일이 열려있지 않습니다. 파일을 열어주세요");
            }
        }

        private void BtnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                    _myRichTextBox.ShowPrintDlg();
                }
                catch
                {
                    var _myRichTextBox = (MyRichTextBox)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[0];
                    _myRichTextBox.ShowPrintDlg();
                }
            }
            catch
            {
                MessageBox.Show("파일이 열려있지 않습니다. 파일을 열어주세요");
            }
        }

        private void BtnInsertPicture_Click(object sender, EventArgs e)
        {
            try
            {
                var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                _myRichTextBox.ShowInsertImageDlg();
            }
            catch
            {

            }
        }

        private void BtnBold_Click(object sender, EventArgs e)
        {
            try
            {
                var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                _myRichTextBox.ToggleBold();
                ToolButtonCheckedState();
            }
            catch
            {

            }

        }

        private void BtnItatic_Click(object sender, EventArgs e)
        {
            try
            {
                var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                _myRichTextBox.ToggleItalic();
                ToolButtonCheckedState();
            }
            catch
            {

            }

        }

        private void BtnUnderLine_Click(object sender, EventArgs e)
        {
            try
            {
                var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                _myRichTextBox.ToggleUnderLine();
                ToolButtonCheckedState();
            }
            catch
            {

            }

        }

        //func
        private void BtnSubSript_Click(object sender, EventArgs e)
        {
            try
            {
                var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                _myRichTextBox.SelectionSubScript = !_myRichTextBox.SelectionSubScript;
                ToolButtonCheckedState();
            }
            catch
            {

            }

        }
        //func
        private void BtnSuperScript_Click(object sender, EventArgs e)
        {
            try
            {
                var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                _myRichTextBox.SelectionSupperScript = !_myRichTextBox.SelectionSupperScript;
                ToolButtonCheckedState();
            }
            catch
            {

            }

        }

        private void BtnAlignLeft_Click(object sender, EventArgs e)
        {
            try
            {
                var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                _myRichTextBox.SelectionAlignment = HorizontalAlignment.Left;
                ToolButtonCheckedState();
            }
            catch
            {

            }

        }

        private void BtnAlignCenter_Click(object sender, EventArgs e)
        {
            try
            {
                var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                _myRichTextBox.SelectionAlignment = HorizontalAlignment.Center;
                ToolButtonCheckedState();
            }
            catch
            {

            }

        }

        private void BtnAlignRight_Click(object sender, EventArgs e)
        {
            try
            {
                var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                _myRichTextBox.SelectionAlignment = HorizontalAlignment.Right;
                ToolButtonCheckedState();
            }
            catch
            {

            }

        }

        private void BtnForeColor_SelectedColorChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(BtnForeColor.Color.ToString());
            //if (!richTextBoxCtrl1.ReadOnly)
            //    if (BtnForeColor.Pressed)
            try
            {
                var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                _myRichTextBox.SelectionColor = BtnForeColor.Color;
            }
            catch
            {

            }
        }

        private void BtnForeBackColor_SelectedColorChanged(object sender, EventArgs e)
        {
            try
            {
                var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                _myRichTextBox.SelectionBackColor = BtnForeBackColor.Color;
            }
            catch
            {

            }
        }

        private void Cut1_Click(object sender, EventArgs e)
        {
            try
            {
                var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                _myRichTextBox.Cut();
            }
            catch
            {
                var _myRichTextBox = (MyRichTextBox)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[0];
                _myRichTextBox.richTextBox1.Cut();
            }
        }

        private void Copy1_Click(object sender, EventArgs e)
        {
            try
            {
                var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                _myRichTextBox.Copy();
            }
            catch
            {
                var _myRichTextBox = (MyRichTextBox)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[0];
                _myRichTextBox.richTextBox1.Copy();
            }
        }

        private void Paste1_Click(object sender, EventArgs e)
        {
            try
            {
                var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                _myRichTextBox.Paste();
            }
            catch
            {
                var _myRichTextBox = (MyRichTextBox)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[0];
                _myRichTextBox.richTextBox1.Paste();
            }
        }

        private void Delete1_Click(object sender, EventArgs e)
        {
            try
            {
                var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                _myRichTextBox.SelectedText = "";
            }
            catch
            {
                var _myRichTextBox = (MyRichTextBox)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[0];
                _myRichTextBox.richTextBox1.SelectedText = "";
            }
        }

        private void SelectAll1_Click(object sender, EventArgs e)
        {
            try
            {
                var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                _myRichTextBox.SelectAll();
            }
            catch
            {
                var _myRichTextBox = (MyRichTextBox)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[0];
                _myRichTextBox.richTextBox1.SelectAll();
            }
        }

        //SelectionChanged//为什么如何的卡
        //TextChanged

        //KeyDown input slow
        //Click
        private void ToolButtonCheckedState()
        {

            if (myTabControlZ.TabCount > 0)
            {
                try
                {
                    var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                    if (_myRichTextBox.SelectionFont == null)
                        return;

                    fontComboBox1.Text = _myRichTextBox.SelectionFont.Name.ToString();
                    fontSizeComboBox1.Text = _myRichTextBox.SelectionFont.Size.ToString();

                    BtnBold.Checked = _myRichTextBox.SelectionFont.Bold;
                    BtnItatic.Checked = _myRichTextBox.SelectionFont.Italic;
                    BtnUnderLine.Checked = _myRichTextBox.SelectionFont.Underline;


                    cb_FontStyles.Text = _myRichTextBox.GetFontFormat();


                    BtnSubSript.Checked = _myRichTextBox.SelectionSubScript;
                    BtnSuperScript.Checked = _myRichTextBox.SelectionSupperScript;


                    BtnOrderlist.Checked = _myRichTextBox.SelectionOrderList;
                    BtnUnOrderlist.Checked = _myRichTextBox.SelectionBullet;

                    BtnAlignLeft.Checked = (_myRichTextBox.SelectionAlignment == HorizontalAlignment.Left);
                    BtnAlignCenter.Checked = (_myRichTextBox.SelectionAlignment == HorizontalAlignment.Center);
                    BtnAlignRight.Checked = (_myRichTextBox.SelectionAlignment == HorizontalAlignment.Right);
                }
                catch
                {

                }

            }

        }

        private void EnabledColorPickStatus()
        {
            if (myTabControlZ.TabCount > 0)
            {
                try
                {
                    var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                    if (_myRichTextBox.SelectedText == "")
                    {
                        BtnForeColor.Color = _myRichTextBox.SelectionColor;
                        BtnForeBackColor.Color = _myRichTextBox.SelectionBackColor;
                    }
                }
                catch
                {

                }
            }
        }

        private void cb_FontStyles_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                _myRichTextBox.SetFontFormat(cb_FontStyles.SelectedIndex);
            }
            catch
            {

            }

        }

        private void CboFonts_SelectedIndexChanged(object sender, EventArgs e)
        {
            float fontSize;
            try
            {
                var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                try
                {
                    fontSize = _myRichTextBox.SelectionFont.Size;
                }
                catch
                {
                    fontSize = _myRichTextBox.Font.Size;
                }
                _myRichTextBox.SelectionFont = new Font(fontComboBox1.Text, fontSize);
            }
            catch
            {

            }

            
        }

        private void CboFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {

            string fontName;

            try
            {
                var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                try
                {
                    fontName = _myRichTextBox.SelectionFont.Name;
                }
                catch
                {
                    fontName = _myRichTextBox.Font.Name;
                }

                float fontSize = Convert.ToSingle(fontSizeComboBox1.Text);
                _myRichTextBox.SelectionFont = new Font(fontName, fontSize);
            }
            catch
            {

            }


            
        }



        private void Insert_Table_Click(object sender, EventArgs e)
        {
            try
            {
                var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                _myRichTextBox.ShowInsertTableDlg();
            }
            catch
            {

            }
        }



        private void RichTextBoxForm_Resize(object sender, EventArgs e)
        {

        }



        private void ts_Close_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void ts_Find_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                    _myRichTextBox.ShowFindDlg();
                }
                catch
                {
                    var _myRichTextBox = (MyRichTextBox)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[0];
                    _myRichTextBox.ShowFindDlg();
                }
            }
            catch
            {
                MessageBox.Show("파일이 열려있지 않습니다. 파일을 열어주세요");
            }         
        }

        private void ts_Replace_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                    _myRichTextBox.ShowReplaceDlg();
                }
                catch
                {
                    var _myRichTextBox = (MyRichTextBox)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[0];
                    _myRichTextBox.ShowReplaceDlg();
                }
            }
            catch
            {
                MessageBox.Show("파일이 열려있지 않습니다. 파일을 열어주세요");
            }            
        }

        #endregion

        #region MenuStrip
        private void ts_Undo_Click(object sender, EventArgs e)
        {
            try
            {
                var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                _myRichTextBox.Undo();
            }
            catch
            {
                var _myRichTextBox = (MyRichTextBox)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[0];
                _myRichTextBox.richTextBox1.Undo();
            }
        }

        private void ts_Redo_Click(object sender, EventArgs e)
        {
            try
            {
                var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                _myRichTextBox.Redo();
            }
            catch
            {
                var _myRichTextBox = (MyRichTextBox)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[0];
                _myRichTextBox.richTextBox1.Redo();
            }
        }

        private void ts_DateTime_Click(object sender, EventArgs e)
        {
            try
            {
                var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                _myRichTextBox.SelectedText = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            }
            catch
            {
                var _myRichTextBox = (MyRichTextBox)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[0];
                _myRichTextBox.richTextBox1.SelectedText = DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
            }
        }


        private void ts_Font_Click(object sender, EventArgs e)
        {
            try
            {
                var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                _myRichTextBox.ShowFontDlg();
            }
            catch
            {
            }
            
        }

        private void ts_jumptoline_Click(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                    _myRichTextBox.ShowGoToDlg();
                }
                catch
                {
                    var _myRichTextBox = (MyRichTextBox)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[0];
                    _myRichTextBox.ShowGoToDlg();
                }
            }
            catch
            {
                MessageBox.Show("파일이 열려있지 않습니다. 파일을 열어주세요");
            }
        }



        private void ts_PasteAsBmp_Click(object sender, EventArgs e)
        {
            try
            {
                var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                _myRichTextBox.PasteAsBmp();
            }
            catch
            {
            }
        }






        private void customTrackBar1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                _myRichTextBox.ZoomFactor = ((float)customTrackBar1.CurrentValue / 100);
            }
            catch
            {
                try
                {
                    var _myRichTextBox = (MyRichTextBox)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[0];
                    _myRichTextBox.richTextBox1.ZoomFactor = ((float)customTrackBar1.CurrentValue / 100);
                    _myRichTextBox.LineNumberTextBox.ZoomFactor = ((float)customTrackBar1.CurrentValue / 100);

                }
                catch { }
            }
        }
        #endregion



        private void DirectoryTrv_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            if (e.Node.Nodes[0].Text == "*")
            {
                e.Node.Nodes.Clear();
                Fill(e.Node);
            }
        }
        private void Fill(TreeNode dirNode)
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(dirNode.FullPath);
                foreach (DirectoryInfo dirItem in dir.GetDirectories())
                {
                    TreeNode newNode = new TreeNode(dirItem.Name);
                    newNode.ImageIndex = 0;
                    newNode.SelectedImageIndex = 0;
                    dirNode.Nodes.Add(newNode);
                    newNode.Nodes.Add("*");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("디렉토리를 여는동안 문제가 발생했습니다. \n 오류 내용 : " + ex.Message);
            }
        }


        private void DirectorySession_SelectedIndexChanged(object sender, EventArgs e)
        {
            DirectoryTrv.Nodes.Clear();
            FileList.Items.Clear();
            if (DirectorySession.SelectedIndex == 0)
            {
                global_isFTP = false;
                DriveInfo[] allDrives = DriveInfo.GetDrives();

                foreach (DriveInfo dname in allDrives)
                {
                    if (dname.DriveType == DriveType.Fixed)
                    {
                        if (dname.Name == @"C:\")
                        {
                            TreeNode rootNode = new TreeNode(dname.Name);
                            rootNode.ImageIndex = 0;
                            rootNode.SelectedImageIndex = 0;
                            DirectoryTrv.Nodes.Add(rootNode);
                            Fill(rootNode);
                        }
                        else
                        {
                            TreeNode rootNode = new TreeNode(dname.Name);
                            rootNode.ImageIndex = 0;
                            rootNode.SelectedImageIndex = 0;
                            DirectoryTrv.Nodes.Add(rootNode);
                            Fill(rootNode);
                        }
                    }
                }
            }
            else
            {

                try
                {
                    global_isFTP = true;
                    DirectoryTrv.Nodes.Clear();
                    FileList.Items.Clear();

                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp_ip);
                    request.Credentials = new NetworkCredential(ftp_id, ftp_pw);
                    request.Method = WebRequestMethods.Ftp.ListDirectory;
                    StreamReader streamReader = new StreamReader(request.GetResponse().GetResponseStream(), System.Text.Encoding.Default);

                    string fileName = streamReader.ReadLine();
                    string s2 = ".";
                    while (fileName != null)
                    {
                        if (fileName.Contains(s2))    //파일일시 리스트뷰에 추가
                        {
                            FileList.Items.Add(fileName);
                        }
                        else                          //폴더일시 트리뷰에 추가
                        {

                            DirectoryTrv.Nodes.Add(fileName);
                            DirectoryTrv.ImageIndex = 0;
                            DirectoryTrv.SelectedImageIndex = 0;
                        }
                        fileName = streamReader.ReadLine();
                    }

                    request = null;
                    streamReader = null;
                }
                catch (Exception)
                {
                    MessageBox.Show("서버에 연결되어 있지 않습니다.","오류",MessageBoxButtons.OK,MessageBoxIcon.Error);

                }
            }
        }

        private void DirectoryTrv_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (global_isFTP == false)
            {
                try
                {
                    //기존 파일 목록 제거
                    FileList.Items.Clear();
                    DirectoryInfo dir = new DirectoryInfo(DirectoryTrv.SelectedNode.FullPath);

                    //디렉토리의 존재하는 파일목록 보여주기
                    FileInfo[] fishow = dir.GetFiles();
                    foreach (FileInfo fri in fishow)
                    {
                        FileList.Items.Add(fri.Name);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("디렉토리를 여는 도중 오류가 발생하였습니다. \n 오류 내용 : " + ex.Message);
                }
            }
            if (global_isFTP == true)
            {
                try
                {
                    FileList.Items.Clear();

                    //FTP경로 설정
                    ftp_path = DirectoryTrv.SelectedNode.FullPath;
                    ftp_path = ftp_path.Replace("\\", "/");

                    string dirname = DirectoryTrv.SelectedNode.ToString();

                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp_ip + "/" + ftp_path);
                    request.Credentials = new NetworkCredential(ftp_id, ftp_pw);
                    request.Method = WebRequestMethods.Ftp.ListDirectory;
                    StreamReader streamReader = new StreamReader(request.GetResponse().GetResponseStream());

                    string fileName = streamReader.ReadLine();
                    string s2 = ".";
                    DirectoryTrv.SelectedNode.Nodes.Clear();

                    while (fileName != null)
                    {
                        fileName = Split(fileName, "/")[1];
                        if (fileName.Contains(s2))    //파일일시 리스트뷰에 추가
                        {
                            FileList.Items.Add(fileName);
                        }
                        else                          //폴더일시 트리뷰에 추가
                        {
                            DirectoryTrv.SelectedNode.Nodes.Add(fileName);
                            DirectoryTrv.ImageIndex = 0;
                            DirectoryTrv.SelectedImageIndex = 0;
                            DirectoryTrv.SelectedNode.ExpandAll();
                        }
                        fileName = streamReader.ReadLine();
                    }
                    request = null;
                    streamReader = null;
                }
                catch (Exception)
                {
                }
            }
        }

        private void FileList_DoubleClick(object sender, EventArgs e)
        {
            if (global_isFTP == false)
            {
                try
                {
                    string fFormat = FileList.SelectedItem.ToString().Split(".")[FileList.SelectedItem.ToString().Split(".").Length - 1];
                    string path = DirectoryTrv.SelectedNode.FullPath + "\\";
                    path += FileList.SelectedItem.ToString();
                    path = path.Replace("\\\\", "\\");

                    int Mode;
                    if (DeveloperfFormat.Contains(fFormat))
                    {
                        Mode = 1;
                    }
                    else
                    {
                        Mode = 0;
                    }

                    if (Mode == 0)
                    {
                        OpenNormalFile(path, "");
                    }
                    else
                    {
                        OpenDeveloperFile(path, "");
                    }


                    //FilenameToolStripLabel.Text = tabpage.Text;

                    //UpdateWindowsList_WindowMenu();

                    count++;
                    
                    UpdateStatusStripButton();
                    UpdateCaption();
                }
                catch (Exception)
                {
                }

            }
            if (global_isFTP == true)
            {
                string fileName = FileList.SelectedItem.ToString();
                string sourcePath = ftp_ip + "/" + ftp_path + "/" + fileName;

                if (OpenedFilesList.Contains(sourcePath))
                {
                    myTabControlZ.SelectedIndex = OpenedFilesList.IndexOf(sourcePath);
                }
                else
                {
                    FTP_FileOpen();
                }
            }

        }

        public static int count = 1;

        private void myTabControl_Close_MenuItem_Click(object sender, EventArgs e)
        {
            ts_tClose_Click(sender, e);
        }

        private void myTabControl_ContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (myTabControlZ.TabCount > 0)
            {
                TabPage tabpage = myTabControlZ.SelectedTab;
                myTabControl_Save_MenuItem.Text = tabpage.Text + "저장";
            }
        }




        private void myTabControlZ_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FP_ToolStrip.Text = OpenedFilesList[myTabControlZ.SelectedIndex];
                UpdateCaption();
            }
            catch
            {
                FP_ToolStrip.Text = "Hoseo-Editor";
            }
        }

        private void ts_tClose_Click(object sender, EventArgs e)
        {
            if (myTabControlZ.TabCount > 0)
            {
                TabPage tabpage = myTabControlZ.SelectedTab;
                int Idx = myTabControlZ.SelectedIndex;
                if (tabpage.Text.Contains("*"))
                {
                    DialogResult dg = MessageBox.Show(tabpage.Text + "파일을 저장하시겠습니까?", "확인", MessageBoxButtons.YesNoCancel);
                    if (dg == DialogResult.Yes)
                    {
                        //save file before close
                        BtnSaveAs_Click(sender, e);
                        //remove tab
                        myTabControlZ.TabPages.Remove(tabpage);
                        OpenedFilesList.RemoveAt(Idx);
                        myTabControlZ_SelectedIndexChanged(sender, e);


                        if (myTabControlZ.TabCount == 0)
                        {
                            FP_ToolStrip.Text = "Hoseo-Editor";
                            count = 1;
                        }
                    }
                    else if (dg == DialogResult.No)
                    {
                        //remove tab
                        myTabControlZ.TabPages.Remove(tabpage);
                        OpenedFilesList.RemoveAt(Idx);
                        
                        myTabControlZ_SelectedIndexChanged(sender, e);


                        if (myTabControlZ.TabCount == 0)
                        {
                            FP_ToolStrip.Text = "Hoseo-Editor";
                            count = 1;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    //remove tab
                    myTabControlZ.TabPages.Remove(tabpage);
                    OpenedFilesList.RemoveAt(Idx);
                    myTabControlZ_SelectedIndexChanged(sender, e);


                    if (myTabControlZ.TabCount == 0)
                    {
                        FP_ToolStrip.Text = "Hoseo-Editor";
                        count = 1;
                    }
                }

                if (myTabControlZ.SelectedIndex >= 0)
                {
                    try
                    {
                        var _myRichTextBox = (MyRichTextBox)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[0];
                        _myRichTextBox.richTextBox1.Select();
                    }
                    catch
                    {
                        var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                        _myRichTextBox.Select();
                    }

                }

            }
            else
            {
                count = 1;
                FP_ToolStrip.Text = "Hoseo-Editor";
            }
        }

        public void BtnSave_Click(object sender, EventArgs e)
        {
            if (myTabControlZ.TabCount > 0)
            {
                
                TabPage tabpage = myTabControlZ.SelectedTab;
                if (FP_ToolStrip.Text.Contains("\\") || FP_ToolStrip.Text.Contains("ftp://"))
                {
                    if (Chk_SaveBU) BackUpFile(myTabControlZ.SelectedIndex);
                    if (tabpage.Text.Contains("*"))
                    {
                        if (FP_ToolStrip.Text.Contains("ftp://"))
                        {
                            try
                            {
                                var _myRichTextBox = (MyRichTextBox)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[0];
                                try
                                {
                                    File.WriteAllText(local_path + getFileName(FP_ToolStrip.Text), "");
                                    StreamWriter strwriter = System.IO.File.AppendText(local_path + getFileName(FP_ToolStrip.Text));
                                    strwriter.Write(_myRichTextBox.richTextBox1.Text);
                                    strwriter.Close();
                                    strwriter.Dispose();
                                    tabpage.Text = tabpage.Text.Remove(tabpage.Text.Length - 1);
                                    FTP_Upload(local_path + getFileName(FP_ToolStrip.Text), FP_ToolStrip.Text);
                                    File.Delete(local_path + getFileName(FP_ToolStrip.Text));
                                }

                                catch (Exception ex)
                                {
                                    MessageBox.Show("파일 저장중 다음 오류가 발생했습니다. \n 오류 내용 : " + ex.Message);
                                }
                            }
                            catch
                            {
                                var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                                try
                                {
                                    File.WriteAllText(local_path + getFileName(FP_ToolStrip.Text), "");
                                    StreamWriter strwriter = System.IO.File.AppendText(local_path + getFileName(FP_ToolStrip.Text));
                                    strwriter.Write(_myRichTextBox.Text);
                                    strwriter.Close();
                                    strwriter.Dispose();
                                    tabpage.Text = tabpage.Text.Remove(tabpage.Text.Length - 1);
                                    FTP_Upload(local_path + getFileName(FP_ToolStrip.Text), FP_ToolStrip.Text);
                                    File.Delete(local_path + getFileName(FP_ToolStrip.Text));
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("파일 저장중 다음 오류가 발생했습니다. \n 오류 내용 : " + ex.Message);
                                }

                            }

                        }
                        else
                        {
                            String filename = FP_ToolStrip.Text;
                            if (File.Exists(filename))
                            {
                                try
                                {
                                    var _myRichTextBox = (MyRichTextBox)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[0];
                                    try
                                    {
                                        File.WriteAllText(filename, "");
                                        StreamWriter strwriter = System.IO.File.AppendText(filename);
                                        strwriter.Write(_myRichTextBox.richTextBox1.Text);
                                        strwriter.Close();
                                        strwriter.Dispose();
                                        tabpage.Text = tabpage.Text.Remove(tabpage.Text.Length - 1);
                                    }

                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("파일 저장중 다음 오류가 발생했습니다. \n 오류 내용 : " + ex.Message);
                                    }
                                }
                                catch
                                {
                                    var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[myTabControlZ.SelectedIndex].Controls[1];
                                    try
                                    {
                                        File.WriteAllText(filename, "");
                                        StreamWriter strwriter = System.IO.File.AppendText(filename);
                                        strwriter.Write(_myRichTextBox.Text);
                                        strwriter.Close();
                                        strwriter.Dispose();
                                        tabpage.Text = tabpage.Text.Remove(tabpage.Text.Length - 1);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("파일 저장중 다음 오류가 발생했습니다. \n 오류 내용 : " + ex.Message);
                                    }

                                }
                                //UpdateWindowsList_WindowMenu();
                            }
                        }

                    }
                }
                else
                {
                    BtnSaveAs_Click(sender, e);
                }

                UpdateCaption();
                UpdateStatusStripButton();
            }

        }

        private void ts_SaveAll_Click(object sender, EventArgs e)
        {
            if (myTabControlZ.TabCount > 0)
            {
                TabControl.TabPageCollection tabcoll = myTabControlZ.TabPages;

                foreach (TabPage tabpage in tabcoll)
                {
                    myTabControlZ.SelectedTab = tabpage;
                    myTabControlZ_SelectedIndexChanged(sender, e);

                    BtnSave_Click(sender, e);
                }
                //UpdateWindowsList_WindowMenu();
            }
        }

        private void ts_tCloseAll_Click(object sender, EventArgs e)
        {
            if (myTabControlZ.TabCount > 0)
            {
                System.Windows.Forms.TabControl.TabPageCollection tabcoll = myTabControlZ.TabPages;
                foreach (TabPage tabpage in tabcoll)
                {


                    myTabControlZ.SelectedTab = tabpage;
                    int Idx = myTabControlZ.SelectedIndex;
                    if (tabpage.Text.Contains("*"))
                    {
                        DialogResult dg = MessageBox.Show("" + tabpage.Text + "파일을 저장하시겠습니까?", "확인", MessageBoxButtons.YesNoCancel);
                        if (dg == DialogResult.Yes)
                        {
                            //save file
                            BtnSave_Click(sender, e);
                            //remove tab
                            myTabControlZ.TabPages.Remove(tabpage);
                            OpenedFilesList.RemoveAt(Idx);
                            //UpdateWindowsList_WindowMenu();
                            myTabControlZ_SelectedIndexChanged(sender, e);

                            if (myTabControlZ.TabCount == 0)
                            {
                                count = 1;
                            }
                        }
                        else if (dg == DialogResult.No)
                        {
                            //remove tab
                            myTabControlZ.TabPages.Remove(tabpage);

                            OpenedFilesList.RemoveAt(Idx);
                            //UpdateWindowsList_WindowMenu();
                            myTabControlZ_SelectedIndexChanged(sender, e);

                            if (myTabControlZ.TabCount == 0)
                            {
                                count = 1;
                            }
                        }
                        else
                        {
                            return;
                        }
                    }
                    else
                    {
                        //remove tab
                        myTabControlZ.TabPages.Remove(tabpage);
                        OpenedFilesList.RemoveAt(Idx);
                        //UpdateWindowsList_WindowMenu();
                        myTabControlZ_SelectedIndexChanged(sender, e);

                        if (myTabControlZ.TabCount == 0)
                        {
                            count = 1;
                        }
                    }
                }
            }
            else
            {
                count = 1;
                FP_ToolStrip.Text = "Hoseo-Editor";
            }
        }

        private void myTabControl_SaveAll_MenuItem_Click(object sender, EventArgs e)
        {
            ts_SaveAll_Click(sender, e);
        }

        private void myTabControl_Save_MenuItem_Click(object sender, EventArgs e)
        {
            BtnSave_Click(sender, e);
        }

        private void myTabControl_CloseAll_MenuItem_Click(object sender, EventArgs e)
        {
            ts_tCloseAll_Click(sender, e);
        }

        private void myTabControl_CloseAllButThis_MenuItem_Click(object sender, EventArgs e)
        {
            if (myTabControlZ.TabCount > 1)
            {
                string UniqueTab = OpenedFilesList[myTabControlZ.SelectedIndex];
                TabControl.TabPageCollection tabcoll = myTabControlZ.TabPages;
                foreach (TabPage tabpage in tabcoll)
                {

                    myTabControlZ.SelectedTab = tabpage;
                    if (FP_ToolStrip.Text != UniqueTab)
                    {

                        ts_tClose_Click(sender, e);
                    }
                }
            }
        }

        private void myTabControl_OpenFileFolder_MenuItem_Click(object sender, EventArgs e)
        {
            if (myTabControlZ.TabCount > 0)
            {
                if (FP_ToolStrip.Text.Contains("\\"))
                {
                    TabPage tabpage = myTabControlZ.SelectedTab;
                    String tabtext = tabpage.Text;
                    if (tabtext.Contains("*"))
                    {
                        tabtext = tabtext.Replace("*", "");
                    }
                    String fname = FP_ToolStrip.Text;
                    String filename = fname.Remove(fname.Length - (tabtext.Length + 1));
                    Process.Start(filename);
                }
            }
        }

        private void BtnUndo_Click(object sender, EventArgs e)
        {
            ts_Undo_Click(sender, e);
        }

        private void BtnRedo_Click(object sender, EventArgs e)
        {
            ts_Redo_Click(sender, e);
        }


        private void OpenDragDrop(object sender, DragEventArgs e)
        {

            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                if (DeveloperfFormat.Contains(getFormat(file)))
                {
                    OpenDeveloperFile(file, "");

                }
                else
                {
                    OpenNormalFile(file, "");
                }
            }

            return;
        }

        private void OpenDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void ts_GeneralSetting_Click(object sender, EventArgs e)
        {
            new GeneralSetting(this).ShowDialog();
        }

        private void ts_FTPSetting_Click(object sender, EventArgs e)
        {
            new FTPSetting(this).ShowDialog();
        }

        //파일삭제
        private void FLDelete_Click(object sender, EventArgs e)
        {
            if (global_isFTP == false)
            {
                try
                {
                    string path = DirectoryTrv.SelectedNode.FullPath + "\\";
                    path += FileList.SelectedItem.ToString();
                    path = path.Replace("\\\\", "\\");

                    if (MessageBox.Show("이 파일을 정말로 삭제하시겠습니까? \n" + path, "확인", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        File.Delete(path);
                        DirectoryTrv_NodeMouseDoubleClick(sender, null); //새로고침
                    }
                    UpdateStatusStripButton();
                    UpdateCaption();
                }
                catch (Exception)
                {
                }
            }
            if (global_isFTP == true)
            {
                string fileName = FileList.SelectedItem.ToString();
                if (MessageBox.Show("이 파일을 정말로 삭제하시겠습니까? \n" + ftp_ip + "/" + ftp_path + "/" + fileName, "확인", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    FtpWebRequest requestFileDelete =
                    (FtpWebRequest)WebRequest.Create(ftp_ip + "/" + ftp_path + "/" + fileName);

                    requestFileDelete.Credentials = new NetworkCredential(ftp_id, ftp_pw);
                    requestFileDelete.Method = WebRequestMethods.Ftp.DeleteFile;

                    FtpWebResponse responseFileDelete = (FtpWebResponse)requestFileDelete.GetResponse();


                    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftp_ip + "/" + ftp_path);
                    request.Credentials = new NetworkCredential(ftp_id, ftp_pw);
                    request.Method = WebRequestMethods.Ftp.ListDirectory;
                    StreamReader streamReader = new StreamReader(request.GetResponse().GetResponseStream());

                    request = null;
                    streamReader.Close();

                    try
                    {
                        DirectoryTrv_NodeMouseDoubleClick(sender, null); //새로고침
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        //새로고침
        private void FLRefresh_Click(object sender, EventArgs e)
        {
            DirectoryTrv_NodeMouseDoubleClick(sender, null);
        }

        private void FileList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FLFOpen_Click(object sender, EventArgs e)
        {
            FileList_DoubleClick(sender, e);
        }
        [STAThread]
        private void FLCPFName_Click(object sender, EventArgs e)
        {
            string CopyBody;
            try
            {
                if (global_isFTP == false)
                {
                    string path = DirectoryTrv.SelectedNode.FullPath + "\\";
                    path += FileList.SelectedItem.ToString();
                    path = path.Replace("\\\\", "\\");
                    CopyBody = path;
                }
                else
                {
                    string fileName = FileList.SelectedItem.ToString();
                    CopyBody = ftp_ip + "/" + ftp_path + "/" + fileName;
                }
                Clipboard.SetText(CopyBody);
            }
            catch (Exception ex){ MessageBox.Show("파일 이름을 복사하는 도중 오류가 발생했습니다. \n 오류 내용 : " + ex.Message); }
            
        }

        private void FLRename_Click(object sender, EventArgs e)
        {
            if (FileList.SelectedIndex < 0) return;
            string fileName = FileList.SelectedItem.ToString();



            string value = fileName;
            string extension = ".";
            if (InputBox("이름 바꾸기", "바꿀 이름을 입력해주세요.", ref value) == DialogResult.OK)
            {
                if (global_isFTP == true)
                {
                    try
                    {
                        if(value.Contains(extension)){
                            FtpWebRequest requestFileRename = (FtpWebRequest)WebRequest.Create(ftp_ip + "/" + ftp_path + "/" + fileName);
                            requestFileRename.Credentials = new NetworkCredential(ftp_id, ftp_pw);
                            requestFileRename.Method = WebRequestMethods.Ftp.Rename;
                            requestFileRename.RenameTo = value;

                            FtpWebResponse responseFileDelete = (FtpWebResponse)requestFileRename.GetResponse();

                            DirectoryTrv_NodeMouseDoubleClick(sender, null); //새로고침
                        }
                        else
                        {
                            MessageBox.Show("확장자를 입력해주시오");
                        }
                        
                    }
                    catch (Exception)
                    {
                    }
                }
                else
                {
                    try
                    {

                        string path = DirectoryTrv.SelectedNode.FullPath + "\\";
                        path = path.Replace("\\\\", "\\");
                        File.Move(path + fileName, path + value);
                        DirectoryTrv_NodeMouseDoubleClick(sender, null); //새로고침
                    }
                    catch { }
                }
            }

        }

        private void FLNew_Click(object sender, EventArgs e)
        {
            string value = "";
            string extension = ".";
            if (InputBox("새로 작성", "생성할 파일 이름을 입력해 주세요.", ref value) == DialogResult.OK)
            {
                if (global_isFTP == true)
                {
                    if (value.Contains(extension))
                    {
                        try
                        {
                            File.WriteAllText(local_path + value, "");
                            FTP_Upload(local_path + value, ftp_ip + "/" + ftp_path + "/" + value);
                            File.Delete(local_path + value);

                            DirectoryTrv_NodeMouseDoubleClick(sender, null); //새로고침
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("새로운 파일을 만드는 도중 오류가 발생했습니다. \n 오류 내용 : " + ex.Message);
                        }
                    }
                    else
                    {
                        MessageBox.Show("확장자를 입력하시오");
                    }
                    
                }
                else
                {
                    try
                    {
                        string path = DirectoryTrv.SelectedNode.FullPath + "\\";
                        path = path.Replace("\\\\", "\\");
                        File.WriteAllText(path + value, "");
                        DirectoryTrv_NodeMouseDoubleClick(sender, null); //새로고침
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("새로운 파일을 만드는 도중 오류가 발생했습니다. \n 오류 내용 : " + ex.Message);
                    }
                }
            }
        }

        private void RichTextBoxForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Chk_FCloseBU)
            {

                for (int i = 0; i < myTabControlZ.TabCount; i++)
                {
                    if (myTabControlZ.TabPages[i].Text.Contains("*"))
                    {
                        BackUpFile(i);
                    }
                }
            }
        }

        private void saveTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < myTabControlZ.TabCount; i++)
            {
                TabPage tabpage = myTabControlZ.TabPages[i];
                if (OpenedFilesList[i].Contains("\\") || OpenedFilesList[i].Contains("ftp://"))
                {
                    if (tabpage.Text.Contains("*"))
                    {
                        if (OpenedFilesList[i].Contains("ftp://"))
                        {
                            try
                            {
                                var _myRichTextBox = (MyRichTextBox)myTabControlZ.TabPages[i].Controls[0];
                                try
                                {
                                    File.WriteAllText(local_path + getFileName(OpenedFilesList[i]), "");
                                    StreamWriter strwriter = System.IO.File.AppendText(local_path + getFileName(OpenedFilesList[i]));
                                    strwriter.Write(_myRichTextBox.richTextBox1.Text);
                                    strwriter.Close();
                                    strwriter.Dispose();
                                    tabpage.Text = tabpage.Text.Remove(tabpage.Text.Length - 1);
                                    FTP_Upload(local_path + getFileName(OpenedFilesList[i]), OpenedFilesList[i]);
                                    File.Delete(local_path + getFileName(OpenedFilesList[i]));
                                }

                                catch (Exception ex)
                                {
                                    MessageBox.Show(tabpage.Text + "탭의 파일 저장중 다음 오류가 발생했습니다. \n 오류 내용 : " + ex.Message);
                                }
                            }
                            catch
                            {
                                var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[i].Controls[1];
                                try
                                {
                                    File.WriteAllText(local_path + getFileName(OpenedFilesList[i]), "");
                                    StreamWriter strwriter = System.IO.File.AppendText(local_path + getFileName(OpenedFilesList[i]));
                                    strwriter.Write(_myRichTextBox.Text);
                                    strwriter.Close();
                                    strwriter.Dispose();
                                    tabpage.Text = tabpage.Text.Remove(tabpage.Text.Length - 1);
                                    FTP_Upload(local_path + getFileName(OpenedFilesList[i]), OpenedFilesList[i]);
                                    File.Delete(local_path + getFileName(OpenedFilesList[i]));
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show(tabpage.Text + "파일 저장중 다음 오류가 발생했습니다. \n 오류 내용 : " + ex.Message);
                                }

                            }

                        }
                        else
                        {
                            String filename = OpenedFilesList[i];
                            if (File.Exists(filename))
                            {
                                try
                                {
                                    var _myRichTextBox = (MyRichTextBox)myTabControlZ.TabPages[i].Controls[0];
                                    try
                                    {
                                        File.WriteAllText(filename, "");
                                        StreamWriter strwriter = System.IO.File.AppendText(filename);
                                        strwriter.Write(_myRichTextBox.richTextBox1.Text);
                                        strwriter.Close();
                                        strwriter.Dispose();
                                        tabpage.Text = tabpage.Text.Remove(tabpage.Text.Length - 1);
                                    }

                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(tabpage.Text + "파일 저장중 다음 오류가 발생했습니다. \n 오류 내용 : " + ex.Message);
                                    }
                                }
                                catch
                                {
                                    var _myRichTextBox = (System.Windows.Forms.RichTextBoxCtrl)myTabControlZ.TabPages[i].Controls[1];
                                    try
                                    {
                                        File.WriteAllText(filename, "");
                                        StreamWriter strwriter = System.IO.File.AppendText(filename);
                                        strwriter.Write(_myRichTextBox.Text);
                                        strwriter.Close();
                                        strwriter.Dispose();
                                        tabpage.Text = tabpage.Text.Remove(tabpage.Text.Length - 1);
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show(tabpage.Text + "파일 저장중 다음 오류가 발생했습니다. \n 오류 내용 : " + ex.Message);
                                    }

                                }
                                //UpdateWindowsList_WindowMenu();
                            }
                        }

                    }
                }

                UpdateCaption();
                UpdateStatusStripButton();

            }


        }

        private void backUpTimer_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < myTabControlZ.TabCount; i++)
            {
                BackUpFile(i);
            }
        }

        private void customTrackBar1_Load(object sender, EventArgs e)
        {

        }
    }
}

