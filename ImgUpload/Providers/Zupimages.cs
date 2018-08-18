using System;
using System.Drawing;
using SharpTools;

namespace ImgUpload.Providers
{
    public class Zupimages : UploadProvider
    {
        public override Image Logo { get { return global::ImgUpload.Properties.Resources.Zupimages; } }
        public override string Name { get { return "Zupimages"; } }
        public override string Company { get { return "Graphikaweb"; } }
        public override string WebSite { get { return "https://www.zupimages.net/"; } }
        public override bool UploadAndGetURL(string imgfile, ref string ImgURL)
        {
            string data = UploadHelper.PostFile(WebSite + "up.php", "files[]", imgfile).BodyAsString;
            ImgURL = StringSplitUtils.FindStringWithDelimiters(data, "Lien direct", "value=\"", "\"");
            return Uri.IsWellFormedUriString(ImgURL, UriKind.Absolute);
        }
    }
}
