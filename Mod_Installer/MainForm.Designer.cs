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

namespace Mod_Installer
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.folderBrowserDialog_DBMPath = new System.Windows.Forms.FolderBrowserDialog();
            this.folderBrowserDialog_BOTPath = new System.Windows.Forms.FolderBrowserDialog();
            this.fileBrowserDialog_AddZipPath = new System.Windows.Forms.OpenFileDialog();
            this.ToolTips = new System.Windows.Forms.ToolTip(this.components);
            this.btnDBMDirectoryBrowse = new System.Windows.Forms.Button();
            this.btnResyncMods = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.btnFile = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.btnHelp = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnReportIssues = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenDBMGithub = new System.Windows.Forms.ToolStripMenuItem();
            this.btnOpenDBMThemeGithub = new System.Windows.Forms.ToolStripMenuItem();
            this.btnAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.btnPatreons = new System.Windows.Forms.ToolStripDropDownButton();
            this.btnDBMPatreon = new System.Windows.Forms.ToolStripMenuItem();
            this.btnGeneralWrexPatreon = new System.Windows.Forms.ToolStripMenuItem();
            this.gbDirectories = new System.Windows.Forms.GroupBox();
            this.DBMDirectory_label = new System.Windows.Forms.Label();
            this.tbDBMDirectory = new System.Windows.Forms.TextBox();
            this.tbBOTDirectory = new System.Windows.Forms.TextBox();
            this.btnBOTDirectoryBrowse = new System.Windows.Forms.Button();
            this.BOTDirectory_label = new System.Windows.Forms.Label();
            this.gbSelectedModZIPArchives = new System.Windows.Forms.GroupBox();
            this.lbModZipList = new System.Windows.Forms.ListBox();
            this.btnRemoveSelectedZip = new System.Windows.Forms.Button();
            this.btnAddZipArchive = new System.Windows.Forms.Button();
            this.gbAdvancedOptions = new System.Windows.Forms.GroupBox();
            this.cbbLanguage_label = new System.Windows.Forms.Label();
            this.cbbLanguage = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dbmModInstallerLog = new System.Windows.Forms.GroupBox();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.btnInstallMods = new System.Windows.Forms.Button();
            this.cbAllowModsWithoutManifests = new System.Windows.Forms.CheckBox();
            this.tbGlobalFileIgnores = new System.Windows.Forms.TextBox();
            this.GlobalFileIgnores_Label = new System.Windows.Forms.Label();
            this.btnClearLog = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.gbDirectories.SuspendLayout();
            this.gbSelectedModZIPArchives.SuspendLayout();
            this.gbAdvancedOptions.SuspendLayout();
            this.dbmModInstallerLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // folderBrowserDialog_DBMPath
            // 
            this.folderBrowserDialog_DBMPath.ShowNewFolderButton = false;
            // 
            // fileBrowserDialog_AddZipPath
            // 
            this.fileBrowserDialog_AddZipPath.DefaultExt = "zip";
            this.fileBrowserDialog_AddZipPath.FileName = "DBM-Mods.zip";
            resources.ApplyResources(this.fileBrowserDialog_AddZipPath, "fileBrowserDialog_AddZipPath");
            this.fileBrowserDialog_AddZipPath.Multiselect = true;
            // 
            // btnDBMDirectoryBrowse
            // 
            resources.ApplyResources(this.btnDBMDirectoryBrowse, "btnDBMDirectoryBrowse");
            this.btnDBMDirectoryBrowse.Name = "btnDBMDirectoryBrowse";
            this.ToolTips.SetToolTip(this.btnDBMDirectoryBrowse, resources.GetString("btnDBMDirectoryBrowse.ToolTip"));
            this.btnDBMDirectoryBrowse.UseVisualStyleBackColor = true;
            this.btnDBMDirectoryBrowse.Click += new System.EventHandler(this.btnDBMDirectoryBrowse_Click);
            // 
            // btnResyncMods
            // 
            this.btnResyncMods.BackColor = System.Drawing.Color.Transparent;
            resources.ApplyResources(this.btnResyncMods, "btnResyncMods");
            this.btnResyncMods.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnResyncMods.Name = "btnResyncMods";
            this.ToolTips.SetToolTip(this.btnResyncMods, resources.GetString("btnResyncMods.ToolTip"));
            this.btnResyncMods.UseVisualStyleBackColor = false;
            this.btnResyncMods.Click += new System.EventHandler(this.btnResyncMods_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            resources.ApplyResources(this.toolStripProgressBar1, "toolStripProgressBar1");
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnFile,
            this.btnHelp,
            this.btnPatreons});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            // 
            // btnFile
            // 
            this.btnFile.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnQuit});
            resources.ApplyResources(this.btnFile, "btnFile");
            this.btnFile.Name = "btnFile";
            // 
            // btnQuit
            // 
            this.btnQuit.Name = "btnQuit";
            resources.ApplyResources(this.btnQuit, "btnQuit");
            this.btnQuit.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // btnHelp
            // 
            this.btnHelp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnReportIssues,
            this.btnOpenDBMGithub,
            this.btnOpenDBMThemeGithub,
            this.btnAbout});
            resources.ApplyResources(this.btnHelp, "btnHelp");
            this.btnHelp.Name = "btnHelp";
            // 
            // btnReportIssues
            // 
            this.btnReportIssues.Name = "btnReportIssues";
            resources.ApplyResources(this.btnReportIssues, "btnReportIssues");
            this.btnReportIssues.Click += new System.EventHandler(this.reportIssuesToolStripMenuItem_Click);
            // 
            // btnOpenDBMGithub
            // 
            this.btnOpenDBMGithub.Name = "btnOpenDBMGithub";
            resources.ApplyResources(this.btnOpenDBMGithub, "btnOpenDBMGithub");
            this.btnOpenDBMGithub.Click += new System.EventHandler(this.openDBToolStripMenuItem_Click);
            // 
            // btnOpenDBMThemeGithub
            // 
            this.btnOpenDBMThemeGithub.Name = "btnOpenDBMThemeGithub";
            resources.ApplyResources(this.btnOpenDBMThemeGithub, "btnOpenDBMThemeGithub");
            this.btnOpenDBMThemeGithub.Click += new System.EventHandler(this.dBMThemesGithubToolStripMenuItem_Click);
            // 
            // btnAbout
            // 
            this.btnAbout.Name = "btnAbout";
            resources.ApplyResources(this.btnAbout, "btnAbout");
            // 
            // btnPatreons
            // 
            this.btnPatreons.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnPatreons.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnDBMPatreon,
            this.btnGeneralWrexPatreon});
            resources.ApplyResources(this.btnPatreons, "btnPatreons");
            this.btnPatreons.Name = "btnPatreons";
            // 
            // btnDBMPatreon
            // 
            this.btnDBMPatreon.Name = "btnDBMPatreon";
            resources.ApplyResources(this.btnDBMPatreon, "btnDBMPatreon");
            this.btnDBMPatreon.Click += new System.EventHandler(this.pledgeToDBMModsPatreonToolStripMenuItem_Click);
            // 
            // btnGeneralWrexPatreon
            // 
            this.btnGeneralWrexPatreon.Name = "btnGeneralWrexPatreon";
            resources.ApplyResources(this.btnGeneralWrexPatreon, "btnGeneralWrexPatreon");
            this.btnGeneralWrexPatreon.Click += new System.EventHandler(this.pledgeToGeneralWrexsPatreonToolStripMenuItem_Click);
            // 
            // gbDirectories
            // 
            this.gbDirectories.Controls.Add(this.DBMDirectory_label);
            this.gbDirectories.Controls.Add(this.tbDBMDirectory);
            this.gbDirectories.Controls.Add(this.btnDBMDirectoryBrowse);
            this.gbDirectories.Controls.Add(this.tbBOTDirectory);
            this.gbDirectories.Controls.Add(this.btnBOTDirectoryBrowse);
            this.gbDirectories.Controls.Add(this.BOTDirectory_label);
            resources.ApplyResources(this.gbDirectories, "gbDirectories");
            this.gbDirectories.Name = "gbDirectories";
            this.gbDirectories.TabStop = false;
            // 
            // DBMDirectory_label
            // 
            resources.ApplyResources(this.DBMDirectory_label, "DBMDirectory_label");
            this.DBMDirectory_label.Name = "DBMDirectory_label";
            // 
            // tbDBMDirectory
            // 
            resources.ApplyResources(this.tbDBMDirectory, "tbDBMDirectory");
            this.tbDBMDirectory.Name = "tbDBMDirectory";
            this.tbDBMDirectory.TextChanged += new System.EventHandler(this.tbDBMDirectory_TextChanged);
            // 
            // tbBOTDirectory
            // 
            resources.ApplyResources(this.tbBOTDirectory, "tbBOTDirectory");
            this.tbBOTDirectory.Name = "tbBOTDirectory";
            this.tbBOTDirectory.TextChanged += new System.EventHandler(this.tbBOTDirectory_TextChanged);
            // 
            // btnBOTDirectoryBrowse
            // 
            resources.ApplyResources(this.btnBOTDirectoryBrowse, "btnBOTDirectoryBrowse");
            this.btnBOTDirectoryBrowse.Name = "btnBOTDirectoryBrowse";
            this.btnBOTDirectoryBrowse.UseVisualStyleBackColor = true;
            this.btnBOTDirectoryBrowse.Click += new System.EventHandler(this.btnBOTDirectoryBrowse_Click);
            // 
            // BOTDirectory_label
            // 
            resources.ApplyResources(this.BOTDirectory_label, "BOTDirectory_label");
            this.BOTDirectory_label.Name = "BOTDirectory_label";
            // 
            // gbSelectedModZIPArchives
            // 
            this.gbSelectedModZIPArchives.Controls.Add(this.lbModZipList);
            this.gbSelectedModZIPArchives.Controls.Add(this.btnRemoveSelectedZip);
            this.gbSelectedModZIPArchives.Controls.Add(this.btnAddZipArchive);
            resources.ApplyResources(this.gbSelectedModZIPArchives, "gbSelectedModZIPArchives");
            this.gbSelectedModZIPArchives.Name = "gbSelectedModZIPArchives";
            this.gbSelectedModZIPArchives.TabStop = false;
            // 
            // lbModZipList
            // 
            this.lbModZipList.AllowDrop = true;
            this.lbModZipList.FormattingEnabled = true;
            resources.ApplyResources(this.lbModZipList, "lbModZipList");
            this.lbModZipList.Name = "lbModZipList";
            this.lbModZipList.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbModZipList_DragDrop);
            this.lbModZipList.DragEnter += new System.Windows.Forms.DragEventHandler(this.lbModZipList_DragEnter);
            // 
            // btnRemoveSelectedZip
            // 
            resources.ApplyResources(this.btnRemoveSelectedZip, "btnRemoveSelectedZip");
            this.btnRemoveSelectedZip.Name = "btnRemoveSelectedZip";
            this.btnRemoveSelectedZip.UseVisualStyleBackColor = true;
            this.btnRemoveSelectedZip.Click += new System.EventHandler(this.btnRemoveSelected_Click);
            // 
            // btnAddZipArchive
            // 
            resources.ApplyResources(this.btnAddZipArchive, "btnAddZipArchive");
            this.btnAddZipArchive.Name = "btnAddZipArchive";
            this.btnAddZipArchive.UseVisualStyleBackColor = true;
            this.btnAddZipArchive.Click += new System.EventHandler(this.btnAddZipArchive_Click);
            // 
            // gbAdvancedOptions
            // 
            this.gbAdvancedOptions.Controls.Add(this.cbAllowModsWithoutManifests);
            this.gbAdvancedOptions.Controls.Add(this.GlobalFileIgnores_Label);
            this.gbAdvancedOptions.Controls.Add(this.tbGlobalFileIgnores);
            this.gbAdvancedOptions.Controls.Add(this.label2);
            this.gbAdvancedOptions.Controls.Add(this.cbbLanguage_label);
            this.gbAdvancedOptions.Controls.Add(this.btnResyncMods);
            this.gbAdvancedOptions.Controls.Add(this.cbbLanguage);
            resources.ApplyResources(this.gbAdvancedOptions, "gbAdvancedOptions");
            this.gbAdvancedOptions.Name = "gbAdvancedOptions";
            this.gbAdvancedOptions.TabStop = false;
            this.gbAdvancedOptions.Enter += new System.EventHandler(this.gbAdvancedOptions_Enter);
            // 
            // cbbLanguage_label
            // 
            resources.ApplyResources(this.cbbLanguage_label, "cbbLanguage_label");
            this.cbbLanguage_label.Name = "cbbLanguage_label";
            // 
            // cbbLanguage
            // 
            this.cbbLanguage.FormattingEnabled = true;
            resources.ApplyResources(this.cbbLanguage, "cbbLanguage");
            this.cbbLanguage.Name = "cbbLanguage";
            this.cbbLanguage.SelectedValueChanged += new System.EventHandler(this.cbbLanguage_SelectedValueChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // dbmModInstallerLog
            // 
            this.dbmModInstallerLog.Controls.Add(this.tbLog);
            resources.ApplyResources(this.dbmModInstallerLog, "dbmModInstallerLog");
            this.dbmModInstallerLog.Name = "dbmModInstallerLog";
            this.dbmModInstallerLog.TabStop = false;
            // 
            // tbLog
            // 
            this.tbLog.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.tbLog.ForeColor = System.Drawing.SystemColors.Window;
            resources.ApplyResources(this.tbLog, "tbLog");
            this.tbLog.Name = "tbLog";
            this.tbLog.ReadOnly = true;
            // 
            // btnInstallMods
            // 
            resources.ApplyResources(this.btnInstallMods, "btnInstallMods");
            this.btnInstallMods.Name = "btnInstallMods";
            this.btnInstallMods.UseVisualStyleBackColor = true;
            this.btnInstallMods.Click += new System.EventHandler(this.btnInstallMods_Click);
            // 
            // cbAllowModsWithoutManifests
            // 
            resources.ApplyResources(this.cbAllowModsWithoutManifests, "cbAllowModsWithoutManifests");
            this.cbAllowModsWithoutManifests.Name = "cbAllowModsWithoutManifests";
            this.cbAllowModsWithoutManifests.UseVisualStyleBackColor = true;
            this.cbAllowModsWithoutManifests.CheckedChanged += new System.EventHandler(this.cbAllowModsWithoutManifests_CheckedChanged);
            // 
            // tbGlobalFileIgnores
            // 
            resources.ApplyResources(this.tbGlobalFileIgnores, "tbGlobalFileIgnores");
            this.tbGlobalFileIgnores.Name = "tbGlobalFileIgnores";
            this.tbGlobalFileIgnores.TextChanged += new System.EventHandler(this.tbGlobalFileIgnores_TextChanged);
            // 
            // GlobalFileIgnores_Label
            // 
            resources.ApplyResources(this.GlobalFileIgnores_Label, "GlobalFileIgnores_Label");
            this.GlobalFileIgnores_Label.Name = "GlobalFileIgnores_Label";
            // 
            // btnClearLog
            // 
            resources.ApplyResources(this.btnClearLog, "btnClearLog");
            this.btnClearLog.Name = "btnClearLog";
            this.btnClearLog.UseVisualStyleBackColor = true;
            this.btnClearLog.Click += new System.EventHandler(this.btnClearLog_Click);
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.btnClearLog);
            this.Controls.Add(this.gbDirectories);
            this.Controls.Add(this.gbSelectedModZIPArchives);
            this.Controls.Add(this.gbAdvancedOptions);
            this.Controls.Add(this.dbmModInstallerLog);
            this.Controls.Add(this.btnInstallMods);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.gbDirectories.ResumeLayout(false);
            this.gbDirectories.PerformLayout();
            this.gbSelectedModZIPArchives.ResumeLayout(false);
            this.gbAdvancedOptions.ResumeLayout(false);
            this.gbAdvancedOptions.PerformLayout();
            this.dbmModInstallerLog.ResumeLayout(false);
            this.dbmModInstallerLog.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_DBMPath;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_BOTPath;
        private System.Windows.Forms.OpenFileDialog fileBrowserDialog_AddZipPath;
        private System.Windows.Forms.ToolTip ToolTips;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripDropDownButton btnFile;
        private System.Windows.Forms.ToolStripMenuItem btnQuit;
        private System.Windows.Forms.ToolStripDropDownButton btnHelp;
        private System.Windows.Forms.ToolStripMenuItem btnReportIssues;
        private System.Windows.Forms.ToolStripMenuItem btnOpenDBMGithub;
        private System.Windows.Forms.ToolStripDropDownButton btnPatreons;
        private System.Windows.Forms.ToolStripMenuItem btnDBMPatreon;
        private System.Windows.Forms.ToolStripMenuItem btnGeneralWrexPatreon;
        private System.Windows.Forms.GroupBox gbDirectories;
        private System.Windows.Forms.Label DBMDirectory_label;
        private System.Windows.Forms.TextBox tbDBMDirectory;
        private System.Windows.Forms.Button btnDBMDirectoryBrowse;
        private System.Windows.Forms.TextBox tbBOTDirectory;
        private System.Windows.Forms.Button btnBOTDirectoryBrowse;
        private System.Windows.Forms.Label BOTDirectory_label;
        private System.Windows.Forms.GroupBox gbSelectedModZIPArchives;
        private System.Windows.Forms.ListBox lbModZipList;
        private System.Windows.Forms.Button btnRemoveSelectedZip;
        private System.Windows.Forms.Button btnAddZipArchive;
        private System.Windows.Forms.GroupBox gbAdvancedOptions;
        private System.Windows.Forms.Label cbbLanguage_label;
        private System.Windows.Forms.ComboBox cbbLanguage;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnResyncMods;
        private System.Windows.Forms.GroupBox dbmModInstallerLog;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Button btnInstallMods;
        private System.Windows.Forms.ToolStripMenuItem btnOpenDBMThemeGithub;
        private System.Windows.Forms.ToolStripMenuItem btnAbout;
        private System.Windows.Forms.Label GlobalFileIgnores_Label;
        private System.Windows.Forms.TextBox tbGlobalFileIgnores;
        private System.Windows.Forms.CheckBox cbAllowModsWithoutManifests;
        private System.Windows.Forms.Button btnClearLog;
    }
}

