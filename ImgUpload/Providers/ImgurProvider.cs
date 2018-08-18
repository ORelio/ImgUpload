using System;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Net;

namespace ImgUpload.Providers
{
    public class ImgurProvider : UploadProvider
    {
        public override Image Logo { get { return global::ImgUpload.Properties.Resources.imgur; } }
        public override string Name { get { return "Imgur"; } }
        public override string Company { get { return "Imgur LLC"; } }
        public override string WebSite { get { return "http://www.imgur.com/"; } }

        public override bool UploadAndGetURL(string imgfile, ref string ImgURL)
        {
            string filePath = Path.GetFullPath(imgfile);

            NameValueCollection headers = new NameValueCollection();
            headers.Add("Authorization", "Client-ID " + Program.imgur_auth_id);

            try
            {
                using (WebResponse response = UploadHelper.PostFile(new Uri("https://api.imgur.com/3/image"), new NameValueCollection(), filePath, null, "image", null, headers))
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string result = reader.ReadToEnd(); //Result json -> Direct link
                        string[] temp = result.Split(new string[] { "\"link\":\"", "\"},\"success\"" }, StringSplitOptions.None);
                        if (temp.Length > 1)
                        {
                            ImgURL = temp[1].Replace("\\/", "/");
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
