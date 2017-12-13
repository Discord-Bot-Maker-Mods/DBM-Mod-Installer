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

// To parse this JSON data, add NuGet 'Newtonsoft.Json' then do:
//
//    using Mod_Installer;
//
//    var data = ModManifest.FromJson(jsonString);
//
namespace Mod_Installer
{
    using System;
    using System.Net;
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public partial class ModManifest
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("repository")]
        public Repository Repository { get; set; }

        [JsonProperty("mod")]
        public Mod Mod { get; set; }

        [JsonProperty("ignore")]
        public List<string> Ignore { get; set; }
    }

    public partial class Repository
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("repository_url")]
        public string RepositoryUrl { get; set; }

        [JsonProperty("branchname")]
        public string BranchName { get; set; }
    }

    public partial class Mod
    {
        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("installtodbm")]
        public bool InstallToDBM { get; set; }

        [JsonProperty("installtobot")]
        public bool InstallToBot { get; set; }
    }


    public partial class ModManifest
    {
        public static ModManifest FromJson(string json) => JsonConvert.DeserializeObject<ModManifest>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this ModManifest self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    public class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
        };
    }
}
