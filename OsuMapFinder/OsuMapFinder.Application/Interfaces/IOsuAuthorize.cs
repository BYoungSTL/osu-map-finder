using OsuMapFinder.Data.DTOs;
using Refit;

namespace OsuMapFinder.Application.Interfaces
{
    public interface IOsuAuthorize
    {
        [Post("/token")]
        Task<ResponseAccessTokenDTO> GetToken([HeaderCollection] IDictionary<string, string> header, [Body] string body);
    }
}
