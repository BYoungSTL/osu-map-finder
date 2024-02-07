using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OsuMapFinder.Application.Interfaces;

namespace OsuMapFinder.Server.Controllers
{
    [ApiController]
    [AllowAnonymous]
    public class LoginController(ILoginAppService loginAppService) : Controller
    {
        public IActionResult Login(string username, string password)
        {
            return Ok(loginAppService.Login(username, password));
        }
    }
}
