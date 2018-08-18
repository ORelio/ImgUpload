using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.IO;

namespace ImgUpload
{
    static class Settings
    {
        private static string ImgUpload_configFile = Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location) + "\\ImgUpload.cfg";
        public static string ImgUpload_resizetag = "";
        public static char ImgUpload_setting = '1';
        public static int ImgUpload_Provider = 0;

        /// <summary>
        /// List of providers available in the software
        /// </summary>
        public static readonly UploadProvider[] UploadProviders;

        /// <summary>
        /// Dynamically build the provider list from the "Providers" namespace when class is being initialized
        /// </summary>
        static Settings()
        {
            List<UploadProvider> providerList = new List<UploadProvider>();
            IEnumerable<Type> providerTypes = Assembly.GetExecutingAssembly().GetTypes().Where(
                        t => String.Equals(t.Namespace, "ImgUpload.Providers", StringComparison.Ordinal)
                     && t.IsSubclassOf(typeof(UploadProvider)));
            foreach (var module in providerTypes)
                providerList.Add((UploadProvider)Activator.CreateInstance(module));
            UploadProviders = providerList.OrderBy(provider => provider.GetType().Name).ToArray();
        }

        /// <summary>
        /// Resize settings available in the software
        /// </summary>
        public static Dictionary<string, string> descriptions = new Dictionary<string, string>()
        {
            { "resample", Translations.Get("imgsize_resample") },
            { "1600x1600", Translations.Get("imgsize_1600x1600") },
            { "1280x1280", Translations.Get("imgsize_1280x1280") },
            { "1024x1024", Translations.Get("imgsize_1024x1024") },
            { "800x800", Translations.Get("imgsize_800x800") },
            { "640x640", Translations.Get("imgsize_640x640") },
            { "320x320", Translations.Get("imgsize_320x320") },
            { "150x150", Translations.Get("imgsize_150x150") },
            { "100x100", Translations.Get("imgsize_100x100") }
        };

        /// <summary>
        /// Load program settings from a config file
        /// </summary>
        public static void LoadPrefs()
        {
            try
            {
                if (System.IO.File.Exists(ImgUpload_configFile))
                {
                    string[] Lines = System.IO.File.ReadAllLines(ImgUpload_configFile);

                    int compteur = 0;
                    foreach (string line in Lines)
                    {
                        compteur++;
                        if (compteur == 1)
                        {
                            if (line != "ImgUpload Settings")
                            {
                                System.IO.File.Delete(ImgUpload_configFile);
                                break;
                            }
                        }

                        else
                        {
                            if (line == "") { continue; }

                            string[] setting = line.Split('=');

                            if (setting.Length != 2)
                            {
                                continue;
                            }
                            else
                            {
                                switch (setting[0])
                                {
                                    case "ImgSettings":
                                        string[] imgsetting = setting[1].Split(',');
                                        if (imgsetting.Length == 2 && imgsetting[1] != "")
                                        {
                                            ImgUpload_resizetag = imgsetting[0];
                                            ImgUpload_setting = imgsetting[1][0];
                                        }
                                        break;
                                    case "ImgProvider":
                                        for (int i = 0; i < UploadProviders.Length; i++)
                                        {
                                            if (UploadProviders[i].Name.ToLower() == setting[1].ToLower())
                                            {
                                                ImgUpload_Provider = i;
                                                break;
                                            }
                                        }
                                        break;
                                    default:
                                        break;
                                }
                            }
                        }
                    }
                }
            }
            catch { /* Cannot read the file */ }
        }

        /// <summary>
        /// Save program settings in a config file
        /// </summary>
        public static void SavePrefs()
        {
            try
            {
                System.IO.File.WriteAllText(ImgUpload_configFile, "ImgUpload Settings\nImgSettings="
                    + ImgUpload_resizetag + ',' + ImgUpload_setting + "\nImgProvider=" + UploadProviders[ImgUpload_Provider].Name, Encoding.UTF8);
            }
            catch { /* Cannot write the file */ }
        }
    }
}
