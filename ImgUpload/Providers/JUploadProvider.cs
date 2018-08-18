using System;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Net;

namespace ImgUpload.Providers
{
    public class JUploadProvider : UploadProvider
    {
        public override Image Logo { get { return global::ImgUpload.Properties.Resources.jupload; } }
        public override string Name { get { return "JUpload"; } }
        public override string Company { get { return "Benjiman91"; } }
        public override string WebSite { get { return "http://www.jupload.fr/"; } }
        public override bool UploadAndGetURL(string imgfile, ref string ImgURL)
        {
            string filePath = Path.GetFullPath(imgfile);
            try
            {
                CookieContainer cookies = new CookieContainer();
                NameValueCollection headers = new NameValueCollection();
                headers.Add("Host", "www.jupload.fr");
                headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:27.0) Gecko/20100101 Firefox/27.0");
                headers.Add("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8");
                headers.Add("Accept-Language", "fr,fr-fr;q=0.8,en-us;q=0.5,en;q=0.3");
                headers.Add("Accept-Encoding", "gzip, deflate");
                headers.Add("Connection", "keep-alive");

                using (WebResponse response = UploadHelper.PostFile(new Uri("http://www.jupload.fr/api.php"), new NameValueCollection(), filePath, null, "file", cookies, headers))
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        ImgURL = reader.ReadToEnd();
                        return true;
                    }
                }
            }
            catch { return false; }
        }
    }
}
