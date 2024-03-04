using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using workoutTracker.Domain.Models.Configuration;
using workoutTracker.Domain.Services.Interface;

namespace workoutTracker.Domain.Services.Implementation
{
    public class GoogleLoginService : IGoogleLoginService
    {
        private readonly GoogleSecrets _googleSecrets;

        public GoogleLoginService(GoogleSecrets googleSecrets)
        {
            _googleSecrets = googleSecrets;
        }

        public async Task<GoogleAccessTokenResponse> GetToken(string code)
        {
            const string redirectUri = "http://localhost:5173";
            const string grantType = "authorization_code";
            var postData = $"code={code}&client_id={_googleSecrets.ClientId}&client_secret={_googleSecrets.ClientSecret}&redirect_uri={redirectUri}&grant_type={grantType}";
            var content = new StringContent(postData, Encoding.UTF8, "application/x-www-form-urlencoded");

            using var httpClient = new HttpClient();
            var response = await httpClient.PostAsync("https://oauth2.googleapis.com/token", content);
            var responseString = await response.Content.ReadAsStringAsync();

            var parsedResponse = await ParseResponse(responseString);

            return parsedResponse;
        }

        private async Task<GoogleAccessTokenResponse> ParseResponse(string responseString)
        {
            var response = JsonConvert.DeserializeObject<GoogleAccessTokenResponse>(responseString);
            return response;
        }
    }

    public class GoogleAccessTokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }

        [JsonProperty("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonProperty("token_type")]
        public string TokenType { get; set; }

        [JsonProperty("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonProperty("id_token")]
        public string IdToken { get; set; }
    }
}
