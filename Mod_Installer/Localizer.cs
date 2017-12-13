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
using System.Threading;
using System.Resources;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Mod_Installer
{
    public static class StringLocalizationTool
    {

        public static ResourceManager ResourceManager;

        public static void Localize(Control control)
        {
            String txt = GetLocalizedString(control.Name);
            control.Text = txt == "" ? control.Text : txt;
            if (control.Controls.Count > 0)
                Localize(control.Controls);
        }

        private static void Localize(System.Windows.Forms.Control.ControlCollection controls)
        {
            foreach (Control child in controls)
            {
                String txt = GetLocalizedString(child.Name);
                child.Text = txt == "" ? child.Text : txt;
                if (child.Controls.Count > 0)
                    Localize(child);
            }
        }

        private static String GetLocalizedString(string objectName)
        {
            ResourceManager.IgnoreCase = true;

            return ResourceManager.GetObject(objectName) == null ?
                string.Empty :
                ResourceManager.GetString(objectName, Thread.CurrentThread.CurrentCulture);
        }


        private static Dictionary<string, string> Strings = new Dictionary<string, string>();

        private static void AddControlsToDictionary(Control control)
        {
            Strings[control.Name] = control.Text;
            if (control.Controls.Count > 0)
                AddControlsToDictionary(control.Controls);
        }

        private static void AddControlsToDictionary(System.Windows.Forms.Control.ControlCollection controls)
        {
            foreach (Control child in controls)
            {
                Strings[child.Name] = child.Text;
                if (child.Controls.Count > 0)
                    AddControlsToDictionary(child);

            }
        }

        public static void GenerateResourceFileFromControls(Control control)
        {
            AddControlsToDictionary(control);

            using (ResXResourceWriter resx = new ResXResourceWriter(@".\languageTemplate.resx"))
            {
                resx.AddResource("language", "en-US");

                foreach (KeyValuePair<string, string> pair in Strings)
                {
                    if (!string.IsNullOrEmpty(pair.Value)){
                        resx.AddResource(pair.Key, pair.Value);
                    }                
                }

            }

        }

    }
}