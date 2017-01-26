using System;
using System.IO;
using System.Web;
using Newtonsoft.Json;
using Sol3.Google.Extensions;
using Sol3.Infrastructure.Patterns.Creational;

namespace Sol3.Google.Auth
{
    public class Settings : Singleton<Settings>
    {
        public Settings()
        {
            var path = $"{Directory.GetCurrentDirectory()}/client_id.json";
            var json = File.ReadAllText(path);
            var clientInfo = JsonConvert.DeserializeObject<GoogleClientInfo>(json);

            ClientId = clientInfo.client_id;
            ProjectId = clientInfo.project_id;
            ClientSecret = clientInfo.client_secret;
            RedirectUrl = clientInfo.redirect_uris[0];
            AuthUri = clientInfo.auth_uri;
            TokenUri = clientInfo.token_uri;
        }

        public string ClientId { get; set; }
        public string ProjectId { get; set; }
        public string ClientSecret { get; set; }
        public string RedirectUrl { get; set; }
        public string AuthUri { get; set; }
        public string TokenUri { get; set; }
        public string ContactsScope => "https://www.google.com/m8/feeds/&amp;approval_prompt=force&amp;access_type=offline";
        public string AuthCodeUrl => $"{AuthUri}?redirect_uri={RedirectUrl}&amp;response_type=code&amp;client_id={ClientId}&amp;scope={ContactsScope}";


        public string GetAuthToken(string redirectUrl)
        {
            redirectUrl = redirectUrl ?? RedirectUrl;

            HttpContext.Current.Response.Redirect($"https://accounts.google.com/o/oauth2/auth?redirect_uri={redirectUrl}&amp;response_type=code&amp;client_id={ClientId}&amp;scope=https://www.google.com/m8/feeds/&amp;approval_prompt=force&amp;access_type=offline");
            return null;
        }
        public GooglePlusAccessToken GetAccessToken(string redirectUrl, string code)
        {
            redirectUrl = redirectUrl ?? RedirectUrl;
            if(string.IsNullOrEmpty(code))
                throw new NullReferenceException("The input parameter [code] cannot be null!");

            /*Get Access Token and Refresh Token*/
            var parameters = $"code={code}&amp;client_id={ClientId}&amp;client_secret={ClientSecret}&amp;redirect_uri={redirectUrl}&amp;grant_type=authorization_code";
            var responseFromServer = TokenUri.GetRequestStream(parameters);
            var serStatus = JsonConvert.DeserializeObject<GooglePlusAccessTokenInternal>(responseFromServer);

            return new GooglePlusAccessToken(serStatus);
        }
    }
}
