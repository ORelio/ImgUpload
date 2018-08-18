using System;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Net;

namespace ImgUpload.Providers
{
    public class HostingPicsProvider : UploadProvider
    {
        public override Image Logo { get { return global::ImgUpload.Properties.Resources.hostingpics; } }
        public override string Name { get { return "HostingPics"; } }
        public override string Company { get { return "EI HostingPics"; } }
        public override string WebSite { get { return "http://hostingpics.net/"; } }
        public override bool UploadAndGetURL(string imgfile, ref string ImgURL)
        {
            string filePath = Path.GetFullPath(imgfile);

            NameValueCollection postData = new NameValueCollection();
            postData.Add("rbar", "1");
            postData.Add("categorie1", "8");
            postData.Add("resize1", "0");

            try
            {
                using (WebResponse response = UploadHelper.PostFile(new Uri("http://www.hostingpics.net/envoi.html"), postData, filePath, null, "photo1", null, null))
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string data = reader.ReadToEnd(); //The API returns a HTML page with the direct link embedded
                        string[] temp = data.Split(new string[] { "<a href=\"http://www.hostingpics.net\" target=\"_blank\"><img src=\"", "\" border=\"0\" alt=\"Upload images\"></a>" }, StringSplitOptions.None);
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
