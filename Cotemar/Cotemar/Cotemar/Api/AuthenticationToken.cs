using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Cotemar.LocalData;
using Cotemar.Settings;

namespace Cotemar.Api
{
    public class AuthenticationToken
    {
        public string Access_token { get; set; }

        public string Token_type { get; set; }

        int _expires_in;
        public int Expires_in
        {
            get
            {
                return _expires_in;
            }

            set
            {
                _expires_in = value;
            }
        }

        public DateTime? ExpireTime { get; set; }

        public bool IsExpired
        {
            get
            {
                if (ExpireTime != null && DateTime.Now < ExpireTime)
                {
                    return false;
                }

                return true;
            }
        }
    }

    public static class TokenManager
    {
        public static string TAG = nameof(TokenManager);
        public static AuthenticationToken AuthenticationToken;
        public static string Username { get; set; }
        public static string Password { get; set; }

        public static async Task<AuthenticationToken> GetToken()
        {
            try
            {
                AuthenticationToken token = UserSettings.AuthenticationToken;
                HttpClient client = new HttpClient();
                if (token == null)
                {
                    var postData = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>("grant_type", "password"),
                        new KeyValuePair<string, string>("username", AppConfiguration.Values.UserToken),
                        new KeyValuePair<string, string>("password", AppConfiguration.Values.PassToken)
                    };
                    HttpContent content = new FormUrlEncodedContent(postData);

                    var response = await client.PostAsync(AppConfiguration.Values.UrlToken, content);
                    var result = await response.Content.ReadAsStringAsync();

                    token = JsonConvert.DeserializeObject<AuthenticationToken>(result);
                    if (token != null)
                    {
                        Debug.WriteLine("oauth/token==>" + token.Access_token, TAG);
                        token.ExpireTime = DateTime.Now.Add(TimeSpan.FromSeconds(token.Expires_in));
                        UserSettings.AuthenticationToken = token;
                    }
                    return token;
                }
                else
                {
                    if (token.IsExpired)
                    {
                        UserSettings.AuthenticationToken = null;
                        return await GetToken();
                    }
                    else
                    {
                        Debug.WriteLine("oauth/token==>" + token.Access_token, TAG);
                        return UserSettings.AuthenticationToken;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message, TAG);
                return null;
            }
        }
    }
}
