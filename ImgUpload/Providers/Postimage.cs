using System;
using System.Drawing;
using SharpTools;
using System.Collections.Generic;

namespace ImgUpload.Providers
{
    public class Postimage : UploadProvider
    {
        public override Image Logo { get { return global::ImgUpload.Properties.Resources.Postimage; } }
        public override string Name { get { return "Postimage"; } }
        public override string Company { get { return "Postimage"; } }
        public override string WebSite { get { return "https://postimages.org/"; } }
        public override bool UploadAndGetURL(string imgfile, ref string ImgURL)
        {
            string homepage = UploadHelper.GetText(WebSite).BodyAsString;
            string token = StringSplitUtils.FindStringWithDelimiters(homepage, "\"token\",\"", "\"");
            Dictionary<string, string> formData = new Dictionary<string,string>();
            formData["token"] = token;
            formData["upload_session"] = Guid.NewGuid().ToString().Replace("-", "");
            formData["numfiles"] = "1";
            formData["ui"] = "[24,1024,768,\"true\",\"fr-FR\",\"fr-FR\",\"" + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "\"]";
            formData["optsize"] = "0";
            formData["session_upload"] = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalMilliseconds.ToString();
            formData["gallery"] = "";
            formData["expire"] = "0";

            string data = UploadHelper.PostFile(WebSite + "json/rr", "file", imgfile, formData).BodyAsString;
            data = UploadHelper.GetText(StringSplitUtils.FindStringWithDelimiters(data, "url\":\"", "\"").Replace("\\/", "/")).BodyAsString;
            ImgURL = StringSplitUtils.FindStringWithDelimiters(data, "Lien direct", "value=\"", "\"");
            return Uri.IsWellFormedUriString(ImgURL, UriKind.Absolute);
        }
    }
}
