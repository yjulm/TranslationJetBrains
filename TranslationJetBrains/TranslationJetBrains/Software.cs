using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace TranslationJetBrains
{
    internal struct SoftwareInfo
    {
        public string installLocation;
        public string displayName;
        public string displayVersion;
    }

    internal class Software
    {
        /// <summary>
        /// 取得软件包的目录和其他信息
        /// </summary>
        internal static List<SoftwareInfo> GetInstallSoftwareInfo()
        {
            string localPath64 = @"SOFTWARE\Wow6432Node\Microsoft\Windows\CurrentVersion\Uninstall";
            string localPath32 = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";
            string path = Environment.Is64BitOperatingSystem ? localPath64 : localPath32;
            RegistryKey pathKey = Registry.LocalMachine.OpenSubKey(path);

            List<SoftwareInfo> softwareList = new List<SoftwareInfo>();
            List<string> names = pathKey.GetSubKeyNames().Where((x) =>
            {
                return (x.IndexOf("JetBrains") > -1
                        || x.IndexOf("IntelliJ IDEA") > -1
                        || x.IndexOf("PhpStorm") > -1
                        || x.IndexOf("WebStorm") > -1
                        || x.IndexOf("PyCharm") > -1
                        || x.IndexOf("RubyMine") > -1
                        || x.IndexOf("AppCode") > -1
                        || x.IndexOf("CLion") > -1
                        || x.IndexOf("DataGrip") > -1
                        || x.IndexOf("ReSharper") > -1
                       );
            }).ToList();       // 注册表中可能出现多个JetBrains系列软件

            names.ForEach((name) =>
            {
                pathKey = Registry.LocalMachine.OpenSubKey(Path.Combine(path, name));
                softwareList.Add(new SoftwareInfo()
                {
                    installLocation = Path.Combine((pathKey.GetValue("InstallLocation") as string) ?? "", @"lib\resources_en.jar"),
                    displayName = pathKey.GetValue("DisplayName") as string,
                    displayVersion = pathKey.GetValue("DisplayVersion") as string
                });
            });

            return softwareList;
        }
    }
}