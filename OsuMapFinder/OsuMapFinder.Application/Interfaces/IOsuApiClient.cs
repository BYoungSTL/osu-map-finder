using OsuMapFinder.Data.DTOs;
using Refit;

namespace OsuMapFinder.Application.Interfaces
{
    [Headers("Authorization: Bearer")]
    public interface IOsuApiClient
    {
        [Get("/beatmaps/{beatmap}")]
        Task<OsuBeatmapDTO> GetBeatmap(int beatmap);

        [Get("/users/{user}/{mode}")]
        Task<OsuUserExtendedDTO> GetUserInfo(int user, string? mode = null);

        [Get("/users/{user}/scores/best")]
        Task<OsuUserScoreDTO[]> GetUserScores(int user);
    }
}
