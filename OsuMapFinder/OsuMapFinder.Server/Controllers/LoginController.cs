using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OsuMapFinder.Application.Interfaces;
using OsuMapFinder.Application.ViewModels;

namespace OsuMapFinder.Server.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class LoginController(ILoginAppService loginAppService) : Controller
    {
        [HttpPost]
        public IActionResult Login(LoginViewModel viewModel)
        {
            return Ok(loginAppService.Login(viewModel.Username, viewModel.Password));
        }
    }
}
