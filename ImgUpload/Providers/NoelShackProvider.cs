using System;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Net;

namespace ImgUpload.Providers
{
    public class NoelShackProvider : UploadProvider
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
                using (WebResponse response = UploadHelper.PostFile(new Uri("http://www.noelshack.com/api.php"), new NameValueCollection(), filePath, null, "fichier", null, null))
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
}
