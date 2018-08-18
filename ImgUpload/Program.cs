using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace ImgUpload
{
    static class Program
    {
        /// <summary>
        /// Image Uploader by ORelio (c) 2012-2018.
        /// Allows to upload pictures to various host providers.
        /// This source code is released under the CDDL 1.0 License.
        /// </summary>

        public const string version = "1.5.0";
        public const string name = "ImgUpload";
        public static bool minecraft_mode = false;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Settings.LoadPrefs();
            if (args.Length > 0)
            {
                Application.Run(new UploadForm(args[0]));
            }
            else
            {
                Application.Run(new UploadForm());
            }
        }
    }
}
