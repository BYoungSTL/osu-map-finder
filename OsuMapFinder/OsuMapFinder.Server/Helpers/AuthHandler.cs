using OsuMapFinder.Application.Interfaces;
using Refit;
using System.Net.Http.Headers;
using OsuMapFinder.Data.Configs;

namespace OsuMapFinder.Server.Helpers
{
    public class AuthHandler : DelegatingHandler
    {
        private const string OsuApiAuthUrl = "https://osu.ppy.sh/oauth";
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var token = await GetToken();
            request.Headers.Authorization = new
                AuthenticationHeaderValue("Bearer", token);
            return await base.SendAsync(request, cancellationToken);
        }

        //For using Osu Api needs to register application and get auth token, all information you can find on: https://osu.ppy.sh/docs/index.html#authentication
        private static async Task<string> GetToken()
        {
            var header = new Dictionary<string, string>
            {
                { "Accept", "application/json" },
                { "Content-Type", "application/x-www-form-urlencoded" }
            };

            var body = $"client_id={OsuApiConfig.ClientId}&client_secret={OsuApiConfig.ClientSecret}&grant_type=client_credentials&scope=public";

            var response = await RestService.For<IOsuAuthorize>(OsuApiAuthUrl).GetToken(header, body);

            return response.AccessToken;
        }
    }
}
