using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Sol3.Google.Extensions
{
    public static class ExtensionHttp
    {
        public static string GetRequestStream(this string url, string payload)
        {
            var webRequest = (HttpWebRequest)WebRequest.Create(url);
            webRequest.Method = "POST";
            //var parameters = "code=" + code + "&amp;client_id=" + ClientId + "&amp;client_secret=" + ClientSecret + "&amp;redirect_uri=" + redirectUrl + "&amp;grant_type=authorization_code";
            var byteArray = Encoding.UTF8.GetBytes(payload);
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.ContentLength = byteArray.Length;
            var postStream = webRequest.GetRequestStream();

            postStream.Write(byteArray, 0, byteArray.Length);
            postStream.Close();
            var response = webRequest.GetResponse();
            postStream = response.GetResponseStream();
            if (postStream == null)
                throw new Exception("");

            var reader = new StreamReader(postStream);
            var responseFromServer = reader.ReadToEnd();

            return responseFromServer;
        }
    }
}
