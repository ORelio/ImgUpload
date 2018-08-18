using System;
using System.Drawing;
using SharpTools;

namespace ImgUpload.Providers
{
    public class JUpload : UploadProvider
    {
        public override Image Logo { get { return global::ImgUpload.Properties.Resources.JUpload; } }
        public override string Name { get { return "JUpload"; } }
        public override string Company { get { return "Benjiman91"; } }
        public override string WebSite { get { return "https://www.jupload.fr/"; } }
        public override bool UploadAndGetURL(string imgfile, ref string ImgURL)
        {
            string data = UploadHelper.PostFile(WebSite, "fichier", imgfile).BodyAsString;
            ImgURL = StringSplitUtils.FindStringWithDelimiters(data, "Lien direct", "value=\"", "\"");
            return Uri.IsWellFormedUriString(ImgURL, UriKind.Absolute);
        }
    }
}
