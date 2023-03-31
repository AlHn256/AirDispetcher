using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirDispetcher.Model
{
    
    internal class FormSettings
    {
        private string[]? SettingList { get; set; }

        public FormSettings()
        {
            AutoLoade();
        }

        public string[] GetFormSettingList()
        {
            return SettingList;
        }
        //private void ALoade()
        //{

            //string LoadeInfo = FileEdit.AutoLoade();
            //SettingList = AutoLoade().Split('\r').ToArray();

            //if (mas.Count() > 1)
            //{
            //    LinkFile.Text = mas[0];
            //    MDir = mas[1];

            //    if (FileEdit.ChkDir(MDir)) labelMdir.Text = MDir;
            //    else labelMdir.Text = "MDir: " + MDir + " не найден!";

            //    if (CheckMDirFile()) KNCheckBox.Enabled = true;
            //    else KNCheckBox.Enabled = false;
            //}
            //else
            //{
            //    using (var dialog = new FolderBrowserDialog())
            //    {
            //        dialog.Description = "Файл автозагрузки не найден!!!\nНужен LINK файл!!!";
            //        if (dialog.ShowDialog() == DialogResult.OK) LinkSearch(dialog.SelectedPath);
            //        else rTBFile.Text = "Файл автозагрузки не найден!!!";
            //    }
            //}
        //}

        public void AutoLoade()
        {
            string LoadeInfo = "";
            string[] FiletoLoad = GetAutoSaveFilesList();

            foreach (string LFile in FiletoLoad)
            {
                if (File.Exists(LFile))
                {
                    try
                    {
                        StreamReader sr = new StreamReader(LFile);
                        LoadeInfo = sr.ReadToEnd();
                        sr.Close();
                    }
                    catch { };
                }
            }
            SettingList = LoadeInfo.Split('\r').ToArray();
        }

        public bool AutoSave(string[] Info)
        {
            bool fl = false;
            string[] AutoSaveFilesList = GetAutoSaveFilesList();

            string str = "";
            foreach (string txt in Info) str += txt + "\r";
            Byte[] info = new UTF8Encoding(true).GetBytes(str);

            foreach (string FiletoSave in AutoSaveFilesList)
            {
                if (Directory.Exists(Path.GetDirectoryName(FiletoSave)))
                {
                    try
                    {
                        using (FileStream fs = File.Create(FiletoSave))
                        {
                            if (str.Length != 0) fs.Write(info, 0, info.Length);
                            else fl = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка в AutoSave" + ex.Message.ToString());
                        //SetExeption(ex); 
                    };
                }
            }
            return fl;
        }

        private string GetAutoLoadeFirstFile()
        {
            string LoadeFile = "";
            string[] FiletoLoad = GetAutoSaveFilesList();

            foreach (string LFile in FiletoLoad)
            {
                if (File.Exists(LFile))
                {
                    LoadeFile = LFile;
                    break;
                }
            }
            return LoadeFile;
        }
        private string[] GetAutoSaveFilesList()
        {
            string fileName = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName == null ? string.Empty : System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
            string ApplicationFileName = Path.GetFileNameWithoutExtension(fileName.Split('\\').Last()) + "Setting.inf";
            //string[] AutoSaveFiles = new string[] { @"C:\Windows\Temp", @"D:", @"E:", @"C:" };
            string[] AutoSaveFiles = new string[] { @"C:\Windows\Temp"};
            string[] AutoSaveFilesList = new string[AutoSaveFiles.Count() + 1];
            int i = 0;
            AutoSaveFilesList[i++] = Directory.GetCurrentDirectory() + "\\" + ApplicationFileName;
            foreach (string elem in AutoSaveFiles)
            {
                AutoSaveFilesList[i++] = elem + "\\" + ApplicationFileName;
            }

            return AutoSaveFilesList;
        }
    }


}
