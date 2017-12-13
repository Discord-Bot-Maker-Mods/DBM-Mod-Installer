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

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Xml;
using System.Xml.Serialization;

namespace Mod_Installer
{
    [Serializable]
    public class Settings
    {
        [XmlIgnore]
        public Dictionary<string, string> AvailableLanguages = new Dictionary<string, string>();

        [Description("The Root Directory of Discord Bot Maker")]
        public string DBMRootPath;

        [Description("The Language of the UI elements (buttons, labels, etc), Note: some controls may not be localized to your language")]
        public string ControlsLanguage;

        [Description("Bot project path")]
        public string BotProjectPath;

        [Description("List of ModZips")]
        public List<string> ZipFiles;


        [Description("Enable Verbose printing to the Log")]
        public bool DebugMode;

        public Settings()
        {
            AvailableLanguages.Add("en-US", "English - United States");
            AvailableLanguages.Add("de-DE", "German - Germany");

            DBMRootPath = "";
            BotProjectPath = "";
            ControlsLanguage = "en-US";
            ZipFiles = new List<string>();
            DebugMode = true;
        }
    }

    /// <summary>
    /// Using XML configurations as its easy to add comments into the configuration file.
    /// </summary>
    public class Config
    {
        public static string FileName;

        public static Config Instance;

        public static string AppPath = Environment.CurrentDirectory;

        private Settings _settings;

        public Settings Settings
        {
            get => _settings;
            set
            {
                _settings = value;
            }
        }

        public Action<string, Exception> LogTargetMethod = Console.WriteLine;

        private void WriteLine(string msg, Exception ex = null) => LogTargetMethod(msg, ex);

        public Config(string fileName = "Config.xml")
        {
            FileName = fileName;

            Instance = this;
            _settings = new Settings();
            LoadConfiguration();
        }

        public bool SaveConfiguration()
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    var writer = new StreamWriter(ms);
                    var serializer = new XmlSerializer(typeof(Settings));
                    serializer.Serialize(writer, _settings);
                    writer.Flush();

                    File.WriteAllBytes(FileName, ms.ToArray());
                }

                WriteComments();
                return true;
            }
            catch (Exception ex)
            {
                WriteLine("Configuration Save Failed! (SaveConfiguration):" + ex.ToString());
            }
            return false;
        }

        public bool LoadConfiguration()
        {
            if (!File.Exists(FileName))
            {
                WriteLine(FileName + " does not exist, creating one from defaults.");
                SaveConfiguration();
                return true;
            }

            try
            {
                var serializer = new XmlSerializer(typeof(Settings));

                using (Stream fs = new FileStream(FileName, FileMode.Open))
                using (XmlReader reader = new XmlTextReader(fs))
                {
                    if (!serializer.CanDeserialize(reader))
                    {
                        WriteLine("Could not deserialize the Configuration File! Load Failed!");
                        return false;
                    }

                    _settings = (Settings)serializer.Deserialize(reader);
                }
                return true;
            }
            catch (Exception ex)
            {
                WriteLine("Configuration Load Failed! (LoadConfiguration):" + ex.ToString());
            }
            return false;
        }

        private void WriteComments()
        {
            try
            {
                var doc = new XmlDocument();
                doc.Load(FileName);

                var parent = doc.SelectSingleNode(typeof(Settings).Name);
                if (parent == null) return;

                foreach (XmlNode child in parent.ChildNodes)
                {
                    PropertyInfo property = (typeof(Settings).GetProperty(child.Name));

                    if (property != null)
                    {
                        XmlNode nameNode = null;
                        if (Attribute.IsDefined(property, typeof(DisplayNameAttribute)))
                        {
                            DisplayNameAttribute name = (DisplayNameAttribute)property.GetCustomAttribute(typeof(DisplayNameAttribute));
                            nameNode = parent.InsertBefore(doc.CreateComment(name.DisplayName), child);
                        }

                        if (Attribute.IsDefined(property, typeof(DescriptionAttribute)))
                        {
                            DescriptionAttribute description = (DescriptionAttribute)property.GetCustomAttribute(typeof(DescriptionAttribute));

                            parent.InsertBefore(doc.CreateComment(description.Description), child);
                        }
                    }
                }
                doc.Save(FileName);
            }
            catch (Exception ex)
            {
                WriteLine("Configuration Save Failed! (WriteComments)" + ex.ToString());
            }
        }
    }
}