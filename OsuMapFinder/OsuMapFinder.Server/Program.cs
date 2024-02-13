using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using OsuMapFinder.Application.Authentication.Models;
using OsuMapFinder.Application.Authentication.Services;
using OsuMapFinder.Application.Interfaces;
using OsuMapFinder.Data.Configs;
using OsuMapFinder.Data.Entities;
using OsuMapFinder.Data.Mappers;

namespace OsuMapFinder.Server
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
