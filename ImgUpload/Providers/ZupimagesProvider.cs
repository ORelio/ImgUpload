using System;
using System.Drawing;
using System.IO;
using System.Net;

namespace ImgUpload.Providers
{
    public class ZupimagesProvider : UploadProvider
    {
        public override Image Logo { get { return global::ImgUpload.Properties.Resources.zupimages; } }
        public override string Name { get { return "Zupimages"; } }
        public override string Company { get { return "Graphikaweb"; } }
        public override string WebSite { get { return "http://www.zupimages.net/"; } }
        public override bool UploadAndGetURL(string imgfile, ref string ImgURL)
        {
            string filePath = Path.GetFullPath(imgfile);
            try
            {
                using (WebResponse response = UploadHelper.PostFile(new Uri("http://www.zupimages.net/up.php"), null, filePath, null, "files[]", null, null))
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string data = reader.ReadToEnd(); //Results page -> Direct link
                        string[] temp = data.Replace("\n", "").Replace("\r", "").Replace("\t", "")
                            .Split(new string[] { "<strong>Lien direct de votre image :</strong> <input class=\"all-select\" type=\"text\" value=\"", "\" /><br />" }, StringSplitOptions.RemoveEmptyEntries);
                        if (temp.Length > 1)
                        {
                            ImgURL = temp[1];
                            return true;
                        }
                        else return false;
                    }
                }
            }
            catch { return false; }
        }
    }
}
