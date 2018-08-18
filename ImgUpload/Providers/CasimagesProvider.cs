using System;
using System.Collections.Specialized;
using System.Drawing;
using System.IO;
using System.Net;

namespace ImgUpload.Providers
{
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
                        string[] temp = data.Split(new string[] { "document.location.href=\"", "\"//-->" }, StringSplitOptions.None);
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
}
