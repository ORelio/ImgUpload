using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Net;
using System.IO;
using System.Collections.Specialized;

namespace ImgUpload
{
    abstract class UploadProvider
    {
        public abstract Image Logo { get; }
        public abstract string Name { get; }
        public abstract string Company { get; }
        public abstract string WebSite { get; }
        public abstract bool UploadAndGetURL(string imgfile, ref string ImgURL);
    }

    class NoelShackProvider : UploadProvider
    {
        public override Image Logo { get { return global::ImgUpload.Properties.Resources.noelshack; } }
        public override string Name { get { return "NoelShack"; } }
        public override string Company { get { return "Odyssée Interactive"; } }
        public override string WebSite { get { return "http://noelshack.com/"; } }
        public override bool UploadAndGetURL(string imgfile, ref string ImgURL)
        {
            string filePath = Path.GetFullPath(imgfile);

            //NoelShack's upload form at noelshack.com/api.php
            //<form method="post" action="" enctype="multipart/form-data">
            // <input type="file" name="file" id="file" size="30" /><br /><br />
            // <input type="submit" name="submit" value="Envoyer" />
            //</form>

            try
            {
                using (WebResponse response = UploadHelper.PostFile(new Uri("http://www.noelshack.com/api.php"), new NameValueCollection(), filePath, null, "file", null, null))
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string data = UploadHelper.GetTextAt(reader.ReadToEnd()); //The API returns a link to the results page, then we need to get the page and extract the direct link
                        string[] temp = data.Split(new string[] { "<div><span>URL :</span><input type=\"text\" value=\"" }, StringSplitOptions.RemoveEmptyEntries);
                        if (temp.Length > 1)
                        {
                            ImgURL = temp[1].Split('"')[0];
                            return true;
                        }
                        else return false;
                    }
                }
            }
            catch { return false; }
        }
    }

    class JUploadProvider : UploadProvider
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

    class HostingPicsProvider : UploadProvider
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

    class CasimagesProvider : UploadProvider
    {
        public override Image Logo { get { return global::ImgUpload.Properties.Resources.casimages; } }
        public override string Name { get { return "Casimages"; } }
        public override string Company { get { return "ASCRIII SARL"; } }
        public override string WebSite { get { return "http://www.casimages.com/"; } }
        public override bool UploadAndGetURL(string imgfile, ref string ImgURL)
        {
            string filePath = Path.GetFullPath(imgfile);

            NameValueCollection postData = new NameValueCollection();
            postData.Add("cat", "12");

            try
            {
                using (WebResponse response = UploadHelper.PostFile(new Uri("http://www.casimages.com/upload_ano.php"), postData, filePath, null, "image", null, null))
                {
                    using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                    {
                        string data = reader.ReadToEnd(); //Temp page -> Results page -> Image page -> Direct link
                        string[] temp = data.Split(new string[] {"document.location.href=\"", "\"//-->"}, StringSplitOptions.None);
                        if (temp.Length > 1)
                        {
                            data = UploadHelper.GetTextAt("http://www.casimages.com/" + temp[1]);
                            System.IO.File.WriteAllText("debug.html", data);
                            temp = data.Split(new string[] { "<p class=\"center\">Exemple : <a href=\"", "\" target=\"_blank\" style=" }, StringSplitOptions.None);
                            if (temp.Length > 1)
                            {
                                data = UploadHelper.GetTextAt(temp[1]);
                                temp = data.Split(new string[] { "<td align='center' id='spoonyalamontagne'  >\n<a href='", "'><img border='0' style='border:0;color: #333333;" }, StringSplitOptions.None);
                                if (temp.Length > 1)
                                {
                                    ImgURL = temp[1];
                                    return true;
                                }
                                else return false;
                            }
                            else return false;
                        }
                        else return false;
                    }
                }
            }
            catch { return false; }
        }
    }

    class ZupimagesProvider : UploadProvider
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
