using System;
using System.Collections.Generic;
using SharpTools;

namespace ImgUpload
{
    /// <summary>
    /// Wrapper around HTTPRawRequest to perform HTTP GET and POST requests
    /// </summary>
    public static class UploadHelper
    {
        /// <summary>
        /// Retrieve a webpage using an HTTP GET request.
        /// </summary>
        /// <param name="url">Target URL</param>
        /// <param name="cookies">Cookies to attach to the request</param>
        /// <param name="referer">Referer for the request</param>
        /// <param name="userAgent">User-agent for the request</param>
        /// <param name="customHeaders">Other custom headers for the request</param>
        /// <returns>An HTTP Request Result object</returns>
        public static HTTPRequestResult GetText(string url,
            Dictionary<string, string> cookies = null,
            string referer = null, string userAgent = null,
            IEnumerable<string> customHeaders = null)
        {
            Uri uri = new Uri(url);
            string host = uri.Host;
            string endpoint = uri.PathAndQuery;
            int port = uri.Port;

            List<string> headers = HTTPRawRequest.GetGETHeaders(host, endpoint, referer, userAgent, cookies);

            if (customHeaders != null)
                headers.AddRange(customHeaders);

            return HTTPRawRequest.DoRequest(host, headers, port);
        }

        /// <summary>
        /// Upload a file using a multipart/form-data HTTP POST request.
        /// </summary>
        /// <param name="url">Target URL</param>
        /// <param name="fieldName">Form field containing the file</param>
        /// <param name="filePath">Path to the file on disk</param>
        /// <param name="formData">Other key-value pair form fields</param>
        /// <param name="cookies">Cookies to attach to the request</param>
        /// <param name="referer">Referer for the request</param>
        /// <param name="userAgent">User-agent for the request</param>
        /// <param name="customHeaders">Other custom headers for the request</param>
        /// <returns>An HTTP Request Result object</returns>
        public static HTTPRequestResult PostFile(
            string url, string fieldName, string filePath,
            IEnumerable<KeyValuePair<string, string>> formData = null,
            IEnumerable<KeyValuePair<string, string>> cookies = null,
            string referer = null, string userAgent = null,
            IEnumerable<string> customHeaders = null)
        {
            if (formData == null)
                formData = new Dictionary<string, string>();

            var fileInfo = new Dictionary<string, string>();
            fileInfo[fieldName] = filePath;
            byte[] postDataBytes;

            Uri uri = new Uri(url);
            string host = uri.Host;
            string endpoint = uri.PathAndQuery;
            int port = uri.Port;

            List<string> headers = HTTPRawRequest.GetPOSTHeaders(formData, fileInfo, out postDataBytes, host, endpoint, referer, userAgent, cookies);

            if (customHeaders != null)
                headers.AddRange(customHeaders);

            return HTTPRawRequest.DoRequest(host, headers, port, postDataBytes);
        }
    }
}
