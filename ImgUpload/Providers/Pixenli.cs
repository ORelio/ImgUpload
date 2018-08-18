using System;
using System.Drawing;
using SharpTools;
using System.Collections.Generic;

namespace ImgUpload.Providers
{
    public class Pixenli : UploadProvider
    {
        public override Image Logo { get { return global::ImgUpload.Properties.Resources.Pixenli; } }
        public override string Name { get { return "Pixenli"; } }
        public override string Company { get { return "Pixenli"; } }
        public override string WebSite { get { return "https://www.pixenli.com/"; } }
        public override bool UploadAndGetURL(string imgfile, ref string ImgURL)
        {
            HTTPRequestResult homepage = UploadHelper.GetText(WebSite);
            string token = StringSplitUtils.FindStringWithDelimiters(homepage.BodyAsString, "name=\"_token\" value=\"", "\"");
            Dictionary<string, string> formData = new Dictionary<string,string>();
            formData["_token"] = token;

            string data = UploadHelper.PostFile(WebSite + "upload", "image", imgfile, formData, homepage.NewCookies).BodyAsString;
            data = UploadHelper.GetText(StringSplitUtils.FindStringWithDelimiters(data, "<meta http-equiv=\"refresh\" content=\"0;url=", "\"")).BodyAsString;
            ImgURL = StringSplitUtils.FindStringWithDelimiters(data, "id=\"image-link\" value=\"", "\"");
            return Uri.IsWellFormedUriString(ImgURL, UriKind.Absolute);
        }
    }
}
