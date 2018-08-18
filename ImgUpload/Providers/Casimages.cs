using System;
using System.Drawing;
using SharpTools;

namespace ImgUpload.Providers
{
    class Casimages : UploadProvider
    {
        public override Image Logo { get { return global::ImgUpload.Properties.Resources.Casimages; } }
        public override string Name { get { return "Casimages"; } }
        public override string Company { get { return "ASCRIII SARL"; } }
        public override string WebSite { get { return "https://www.casimages.com/"; } }
        public override bool UploadAndGetURL(string imgfile, ref string ImgURL)
        {
            string data = UploadHelper.PostFile(WebSite + "upload_ano.php", "image", imgfile).BodyAsString;
            data = UploadHelper.GetText(WebSite + StringSplitUtils.FindStringWithDelimiters(data, "document.location.href=\"", "\"")).BodyAsString;
            ImgURL = StringSplitUtils.FindStringWithDelimiters(data, "Lien Source", "Grande", "value='", "'");
            return Uri.IsWellFormedUriString(ImgURL, UriKind.Absolute);
        }
    }
}
