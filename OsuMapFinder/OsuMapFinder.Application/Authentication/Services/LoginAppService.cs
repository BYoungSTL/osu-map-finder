using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using OsuMapFinder.Application.Authentication.Models;
using OsuMapFinder.Application.Interfaces;
using OsuMapFinder.Data.Entities;
using OsuMapFinder.Data.Interfaces;

namespace OsuMapFinder.Application.Authentication.Services
{
    public class LoginAppService(IUserService userService) : ILoginAppService
    {
        public string Login(string username, string password)
        {
            var claims = new List<Claim> { new(ClaimTypes.Name, username) };
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.ISSUER,
                audience: AuthOptions.AUDIENCE,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(2)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
