/*
Copyright(c) <2017> <General Wrex>

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

This script was made possible by my patreons, at the time of writing this script, they are;
    MitchDaGamer

Click to become a patreon!: https://www.patreon.com/bePatron?u=8722862
Github Page: https://github.com/generalwrex

*/

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Resources;
using System.Text.RegularExpressions;
using System.Windows.Forms;

[assembly: NeutralResourcesLanguage("en")]

namespace Mod_Installer
{
    public partial class MainForm : Form
    {
        private Config Config = new Config(Path.Combine(Environment.CurrentDirectory, "Config.xml"));

        private string DataPath = "";
        private string BotTempPath = "";
        private string DBMTempPath = "";
        private string ModsTempPath = "";

        private int progress = 0;

        private delegate void SetStringDelegate(string parameter, Exception exception);

        public MainForm()
        {
            InitializeComponent();

            backgroundWorker1.DoWork += backgroundWorker1_DoWork;
            backgroundWorker1.ProgressChanged += backgroundWorker1_ProgressChanged;
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.RunWorkerCompleted += BackgroundWorker1_RunWorkerCompleted;

            SetConfig();
        }

        #region Methods

        public void SetLocalization(string cultureIso, Assembly assembly)
        {
            try
            {
                StringLocalizationTool.ResourceManager = new ResourceManager("Mod_Installer.Resources.Localization.Controls." + cultureIso, assembly);
                //generates resource file from controls
                StringLocalizationTool.GenerateResourceFileFromControls(this);
                StringLocalizationTool.Localize(this);
            }
            catch (Exception) { }
        }

        private void SetConfig()
        {
            Config.LogTargetMethod = Log;

            Config.LoadConfiguration();

            DataPath = Path.Combine(Config.AppPath, "data");
            if (!Directory.Exists(DataPath)) Directory.CreateDirectory(DataPath);

            BotTempPath = Path.Combine(DataPath, "bot");
            if (!Directory.Exists(BotTempPath)) Directory.CreateDirectory(BotTempPath);

            DBMTempPath = Path.Combine(DataPath, "dbm");
            if (!Directory.Exists(DBMTempPath)) Directory.CreateDirectory(DBMTempPath);

            ModsTempPath = Path.Combine(DataPath, "mods");
            if (!Directory.Exists(ModsTempPath)) Directory.CreateDirectory(ModsTempPath);

            Log($"Loaded Configuration.");

            SetLocalization(Config.Settings.ControlsLanguage, typeof(MainForm).Assembly);

            cbbLanguage.DataSource = new BindingSource(Config.Settings.AvailableLanguages, null);
            cbbLanguage.DisplayMember = "Value";
            cbbLanguage.ValueMember = "Key";

            foreach (var zip in Config.Settings.ZipFiles.ToArray())
            {
                AddMod(zip);
            }

            tbDBMDirectory.Text = Config.Settings.DBMRootPath;
            tbBOTDirectory.Text = Config.Settings.BotProjectPath;

            Log("DBM Mod Installer Initiated..");
        }

        private bool HasManifest(string path)
        {
            using (ZipArchive archive = ZipFile.OpenRead(path))
            {
                foreach (ZipArchiveEntry entry in archive.Entries)
                {
                    if (entry.FullName.EndsWith("modinfo.json", StringComparison.OrdinalIgnoreCase))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private ModManifest ReadManifest(string modName)
        {
            var manifestpath = Path.Combine(ModsTempPath, modName, "modinfo.json");

            if (File.Exists(manifestpath))
            {
                var manifest = File.ReadAllText(manifestpath);

                if (IsValidJson(manifest))
                {
                    return JsonConvert.DeserializeObject<ModManifest>(manifest);
                }
                else
                {
                    Log($"Mods 'modinfo.json' is not valid for '{modName}'");
                }
            }

            return null;
        }

        private bool ShouldIgnoreFile(string path, ModManifest manifest)
        {
            if (path.Contains("modinfo.json"))
                return true;

            foreach (var ignore in manifest.Ignore)
            {
                string rex = "^" + Regex.Escape(ignore).Replace("\\?", ".").Replace("\\*", ".*") + "$";
                if (Regex.IsMatch(path, rex))
                {
                    return true;
                }
            }

            return false;
        }

        private bool CopyFolderContents(string SourcePath, string DestinationPath, ModManifest manifest = null)
        {
            SourcePath = SourcePath.EndsWith(@"\") ? SourcePath : SourcePath + @"\";
            DestinationPath = DestinationPath.EndsWith(@"\") ? DestinationPath : DestinationPath + @"\";

            try
            {
                if (Directory.Exists(SourcePath))
                {
                    if (Directory.Exists(DestinationPath) == false)
                    {
                        Directory.CreateDirectory(DestinationPath);
                    }

                    foreach (string files in Directory.GetFiles(SourcePath))
                    {
                        FileInfo fileInfo = new FileInfo(files);

                        if (manifest != null)
                        {
                            if (!ShouldIgnoreFile(fileInfo.Name, manifest))
                            {
                                fileInfo.CopyTo(string.Format(@"{0}\{1}", DestinationPath, fileInfo.Name), true);
                            }
                        }
                        else
                        {
                            fileInfo.CopyTo(string.Format(@"{0}\{1}", DestinationPath, fileInfo.Name), true);
                        }
                    }

                    foreach (string drs in Directory.GetDirectories(SourcePath))
                    {
                        DirectoryInfo directoryInfo = new DirectoryInfo(drs);
                        if (CopyFolderContents(drs, DestinationPath + directoryInfo.Name) == false)
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void AddProgress(int num = 10)
        {
            if (progress > 100)
                progress = 100;

            if (backgroundWorker1.IsBusy)
            {
                int outprog = progress += num;

                backgroundWorker1.ReportProgress(outprog / (lbModZipList.Items.Count + 1));
            }
        }

        private void CopyMods(string path, string modName)
        {
            var modPath = Path.Combine(ModsTempPath, modName);

            try
            {
                AddProgress();
                ModManifest manifest = ReadManifest(modName);

                Log($"--------MOD INFO-----------");
                Log($"Name: {manifest.Name}");
                Log($"Author: {manifest.Author}");
                Log($"Version: {manifest.Version}");
                Log($"Mod Type: {manifest.Mod.Type}");
                Log($"Description: {manifest.Description}");
                Log($"Repository Url: {manifest.Repository.RepositoryUrl}");
                Log($"----------------------------");

                if (manifest.Mod.InstallToBot)
                {
                    Log($"Copying files for'{modName}' to BOT in '{BotTempPath}'...");
                    AddProgress();
                    CopyFolderContents(modPath, BotTempPath, manifest);
                    AddProgress();
                }

                if (manifest.Mod.InstallToDBM)
                {
                    AddProgress();
                    Log($"Copying files for'{modName}' to DBM '{DBMTempPath}'...");
                    CopyFolderContents(modPath, DBMTempPath, manifest);
                    AddProgress();
                }
                AddProgress();

                InstallMods(path);
            }
            catch (Exception ex)
            {
                Log($"Could not copy mods", ex);
            }
        }

        private void ExtractMod(string path)
        {
            var fileName = Path.GetFileName(path);
            var modName = Path.GetFileNameWithoutExtension(path);
            var modPath = Path.Combine(ModsTempPath, modName);
            try
            {
                if (Directory.Exists(modPath))
                {
                    Directory.Delete(modPath, true);
                }

                Log($"Extracting Mod, This may take a few minutes...");
                ZipFile.ExtractToDirectory(path, ModsTempPath);
                Log($"Mod {modName} Extracted!");

                CopyMods(path, modName);
            }
            catch (Exception ex)
            {
                Log($"Could not extract {fileName}", ex);
            }
        }

        private void InstallMods(string path)
        {
            var fileName = Path.GetFileName(path);
            var modName = Path.GetFileNameWithoutExtension(path);
            var modPath = Path.Combine(ModsTempPath, modName);

            ModManifest manifest = ReadManifest(modName);

            var botPath = tbBOTDirectory.Text;
            var dbmPath = tbDBMDirectory.Text;

            Log($"Installing Mods to the provided directories, This may take a few minutes...");


            try
            {
                if (Directory.Exists(botPath))
                {
                    Log($"Installing Mods Contained In '{manifest.Name}' to BOT at  '{botPath}'");
                    AddProgress();
                    CopyFolderContents(BotTempPath, botPath);
                    AddProgress();
                }

                if (Directory.Exists(dbmPath))
                {
                    Log($"Installing Mods Contained In '{manifest.Name}' to DBM at  '{dbmPath}'");
                    AddProgress();
                    CopyFolderContents(DBMTempPath, dbmPath);
                    AddProgress();
                }
            }
            catch (Exception ex)
            {
                Log($"Could not install mods:", ex);
            }
        }

        private static bool IsValidJson(string strInput)
        {
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    //Exception in parsing json
                    Console.WriteLine(jex.Message);
                    return false;
                }
                catch (Exception ex) //some other exception
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void AddMod(string path)
        {
            try
            {
                if (!string.IsNullOrEmpty(path) &&
               !lbModZipList.Items.Contains(path) &&
               path.EndsWith(".zip"))
                {
                    if (HasManifest(path))
                    {
                        if (!File.Exists(path))
                        {
                            Log($"'{path}' Does not exist in the specified directory, removing from list..");

                            if(lbModZipList.Items.Contains(path))
                                lbModZipList.Items.Remove(path);

                            if (Config.Settings.ZipFiles.Contains(path))
                                Config.Settings.ZipFiles.Remove(path);

                            Log($"Removed '{path}' from the list.");

                            Config.SaveConfiguration();

                            return;
                        }

                        lbModZipList.Items.Add(path);

                        if (!Config.Settings.ZipFiles.Contains(path))
                            Config.Settings.ZipFiles.Add(path);

                        Log($"Added '{path}' to the list.");

                        Config.SaveConfiguration();
                    }
                    else
                    {
                        Log($"Error: Missing 'modinfo.json' in '{path}'");
                    }
                }
            }
            catch (Exception ex)
            {
                Log("Add Mod Failed!", ex);
            }
        }

        private void RemoveMod(string path)
        {
            try
            {
                if (!string.IsNullOrEmpty(path) && lbModZipList.Items.Contains(path))
                {
                    lbModZipList.Items.Remove(path);
                    Config.Settings.ZipFiles.Remove(path);

                    Log($"Removed '{path}' from the list.");

                    Config.SaveConfiguration();
                }
            }
            catch (Exception ex)
            {
                Log("Remove Mod Failed!", ex);
            }
        }

        private void Log(string message, Exception exception = null)
        {
            if (tbLog.InvokeRequired)
            {
                Invoke(new SetStringDelegate(Log), new object[] { message, exception });
            }
            else
            {
                try
                {
                    if (!string.IsNullOrEmpty(message))
                    {
                        if (exception != null)
                        {
                            if (exception.StackTrace != null)
                                tbLog.AppendText($"{DateTime.Now.ToLocalTime().ToShortTimeString()} Error: {message}\r\nMessage: {exception.Message} \r\nStackTrace: {exception.StackTrace}\r\n");
                            else
                                tbLog.AppendText($"{DateTime.Now.ToLocalTime().ToShortTimeString()} Error: {message}\r\nMessage: {exception.Message}\r\n");
                        }
                        else
                        {
                            tbLog.AppendText($"{DateTime.Now.ToLocalTime().ToShortTimeString()} : {message}\r\n");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Log Message Failed!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        #endregion Methods

        #region Event Handlers

        private void btnAddZipArchive_Click(object sender, EventArgs e)
        {
            fileBrowserDialog_AddZipPath.Filter = "Mod ZIPS (*.zip)|*.zip";

            if (fileBrowserDialog_AddZipPath.ShowDialog() == DialogResult.OK)
            {
                foreach (var path in fileBrowserDialog_AddZipPath.FileNames)
                {
                    AddMod(path);
                }
            }
        }

        private void btnRemoveSelected_Click(object sender, EventArgs e)
        {
            RemoveMod(lbModZipList.SelectedItem.ToString());
        }

        private void btnDBMDirectoryBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog_DBMPath.ShowDialog() == DialogResult.OK)
            {
                Config.Settings.DBMRootPath = folderBrowserDialog_DBMPath.SelectedPath;
                tbDBMDirectory.Text = Config.Settings.DBMRootPath;
                Config.SaveConfiguration();
            }
        }

        private void btnBOTDirectoryBrowse_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog_BOTPath.ShowDialog() == DialogResult.OK)
            {
                Config.Settings.BotProjectPath = folderBrowserDialog_BOTPath.SelectedPath;
                tbBOTDirectory.Text = Config.Settings.BotProjectPath;
                Config.SaveConfiguration();
            }
        }

        private void btnInstallMods_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(tbBOTDirectory.Text))
            {
                Log("Bot Project Directory does not exist or is invalid: " + tbBOTDirectory.Text);
                return;
            }

            if (!Directory.Exists(tbDBMDirectory.Text))
            {
                Log("Provided DBM Path Directory does not exist or is invalid: " + tbDBMDirectory.Text);
                return;
            }

            Config.SaveConfiguration();

            btnInstallMods.Enabled = false;

            backgroundWorker1.RunWorkerAsync();
        }

        private void lbModZipList_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] s = (string[])e.Data.GetData(DataFormats.FileDrop, false);
                int i;
                for (i = 0; i < s.Length; i++)
                {
                    AddMod(s[i]);
                }
            }
            catch (Exception ex)
            {
                Log("Drag & Drop Operation Failed!", ex);
            }
        }

        private void lbModZipList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {
        }

        private void btnResyncMods_Click(object sender, EventArgs e)
        {
        }

        private void cbbLanguage_SelectedValueChanged(object sender, EventArgs e)
        {
            string culture = ((KeyValuePair<string, string>)cbbLanguage.SelectedItem).Key;
            Config.Settings.ControlsLanguage = culture;
            Config.SaveConfiguration();
            SetLocalization(Config.Settings.ControlsLanguage, typeof(MainForm).Assembly);
        }

        private void tbDBMDirectory_TextChanged(object sender, EventArgs e)
        {
            Config.Settings.DBMRootPath = tbDBMDirectory.Text;
            Config.SaveConfiguration();
        }

        private void tbBOTDirectory_TextChanged(object sender, EventArgs e)
        {
            Config.Settings.BotProjectPath = tbBOTDirectory.Text;
            Config.SaveConfiguration();
        }

        private void BackgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            btnInstallMods.Enabled = true;

            Log("Mods have been installed! Please restart DBM and your bot to use the new mods!");
        }

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            backgroundWorker1.ReportProgress(0);

            AddProgress(10);

            try
            {
                Log("Running Installer...");
                foreach (var item in lbModZipList.Items)
                {
                    AddProgress();
                    string mod = item.ToString();
                    ExtractMod(mod);
                }
            }
            catch (Exception ex)
            {
                Log("Install Mods Failed!", ex);
            }

            backgroundWorker1.ReportProgress(100);
        }

        private void backgroundWorker1_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
        }

        #endregion Event Handlers


        #region Tool Menu
        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void reportIssuesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenWebpage("https://github.com/Discord-Bot-Maker-Mods/DBM-Mod-Installer/issues");
        }

        private void openDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenWebpage("https://github.com/Discord-Bot-Maker-Mods/DBM-Mods");
        }

        private void pledgeToDBMModsPatreonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenWebpage("https://www.patreon.com/dbmmods/posts");
        }

        private void pledgeToGeneralWrexsPatreonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenWebpage("https://www.patreon.com/generalwrex");
        }

        private void dBMThemesGithubToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenWebpage("https://github.com/Discord-Bot-Maker-Mods/DBM-Themes");
        }

        private void aboutDBMModInstallerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            const string message =
            "Thanks for checking out DBM Mods Installer! \r\n " +
            "We hope the program worked out for you!\r\n\r\n"+
            "Consider checking us out on patreon, you can find " +
            "our links under the Patreon button on the Menu!";
            const string caption = "About DBM Mods Installer";
            var result = MessageBox.Show(message, caption, MessageBoxButtons.OK,MessageBoxIcon.Question);

        }

        private void OpenWebpage(string url)
        {
            System.Diagnostics.Process.Start(url);
        }

        #endregion


    }
}