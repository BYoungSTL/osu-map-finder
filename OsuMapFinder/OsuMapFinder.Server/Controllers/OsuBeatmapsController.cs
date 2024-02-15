using Microsoft.AspNetCore.Mvc;
using OsuMapFinder.Application.Interfaces;

namespace OsuMapFinder.Server.Controllers
{
    public class OsuBeatmapsController(IOsuApiClient osuApiClient) : Controller
    {
        [HttpGet("beatmap")]
        public async Task<IActionResult> GetBeatmap(int beatmapId)
        {
            return Ok(await osuApiClient.GetBeatmap(beatmapId));
        }
    }
}
