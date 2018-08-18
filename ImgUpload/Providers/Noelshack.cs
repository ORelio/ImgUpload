using System;
using System.Drawing;
using SharpTools;

namespace ImgUpload.Providers
{
    public class NoelShack : UploadProvider
    {
        public override Image Logo { get { return global::ImgUpload.Properties.Resources.Noelshack; } }
        public override string Name { get { return "NoelShack"; } }
        public override string Company { get { return "Odyssée Interactive"; } }
        public override string WebSite { get { return "http://www.noelshack.com/"; } }
        public override bool UploadAndGetURL(string imgfile, ref string ImgURL)
        {
            string data = UploadHelper.GetText(UploadHelper.PostFile(WebSite + "api.php", "fichier", imgfile).BodyAsString).BodyAsString;
            ImgURL = StringSplitUtils.FindStringWithDelimiters(data, "<div><span>URL :</span><input type=\"text\" value=\"", "\"");
            return Uri.IsWellFormedUriString(ImgURL, UriKind.Absolute);
        }
    }
}
