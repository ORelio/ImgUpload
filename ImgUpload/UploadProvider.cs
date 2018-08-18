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
    public abstract class UploadProvider
    {
        public abstract Image Logo { get; }
        public abstract string Name { get; }
        public abstract string Company { get; }
        public abstract string WebSite { get; }
        public abstract bool UploadAndGetURL(string imgfile, ref string ImgURL);
    }
}
