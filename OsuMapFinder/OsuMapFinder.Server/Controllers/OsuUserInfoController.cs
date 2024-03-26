using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OsuMapFinder.Application.Interfaces;

namespace OsuMapFinder.Server.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class OsuUserInfoController(IOsuApiClient osuApiClient) : Controller
    {
        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUser(int userId) 
            => Ok(await osuApiClient.GetUserInfo(userId));

        [HttpGet("scores/{userId}")]
        public async Task<IActionResult> GetScores(int userId) 
            => Ok(await osuApiClient.GetUserScores(userId));
    }
}
