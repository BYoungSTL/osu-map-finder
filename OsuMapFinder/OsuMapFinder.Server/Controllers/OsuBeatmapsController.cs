using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OsuMapFinder.Application.Interfaces;

namespace OsuMapFinder.Server.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class OsuBeatmapsController(IOsuApiClient osuApiClient) : Controller
    {
        [HttpGet("beatmap/{beatmapId}")]
        public async Task<IActionResult> GetBeatmap(int beatmapId) 
            => Ok(await osuApiClient.GetBeatmap(beatmapId));
    }
}
    