using Refit;

namespace OsuMapFinder.Application.Interfaces
{
    [Headers("Authorization: Bearer")]
    public interface IOsuApiClient
    {
        [Get("/beatmaps/{beatmap}")]
        Task<string> GetBeatmap(int beatmap);
    }
}
