using Microsoft.AspNetCore.Mvc;
using OsuMapFinder.Application.Interfaces;

namespace OsuMapFinder.Server.Controllers
{
    public class OsuUserInfoController(IOsuApiClient osuApiClient) : Controller
    {
        [HttpGet("/user/{userId}")]
        public async Task<IActionResult> GetUser(int userId) 
            => Ok(await osuApiClient.GetUserInfo(userId));

        [HttpGet("/userscores/{userId}")]
        public async Task<IActionResult> GetUserScores(int userId) 
            => Ok(await osuApiClient.GetUserScores(userId));
    }
}
