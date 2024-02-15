using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MongoDB.Driver;
using OsuMapFinder.Application.Authentication.Models;
using OsuMapFinder.Application.Authentication.Services;
using OsuMapFinder.Application.Interfaces;
using OsuMapFinder.Data.Configs;
using OsuMapFinder.Data.CRUDs;
using OsuMapFinder.Data.Entities;
using OsuMapFinder.Data.Interfaces;
using OsuMapFinder.Data.Mappers;
using OsuMapFinder.Server.Helpers;
using Refit;

namespace OsuMapFinder.Server
{
    public class Startup(IConfiguration configuration)
    {
        private const string DatabaseConfigName = "Database";
        private const string OsuApiConfigName = "OsuApi";
        private const string OsuApiUri = "https://osu.ppy.sh/api/v2";
        public IConfiguration Configuration { get; } = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            services.AddMvc();
            services.AddCors(options =>
            {
                options.AddPolicy("_origins",
                    policy =>
                    {
                        //Local server and front-end
                        policy.WithOrigins("http://localhost:5173/",
                            "https://localhost:7107");
                    });
            });

            GetConfigs(services);
            ConfigureDatabase(services);
            AddServices(services);
            ConfigureOsuApiClient(services);

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo());
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
            });

            services.AddAuthorization();
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = AuthOptions.ISSUER,
                        ValidateAudience = true,
                        ValidAudience = AuthOptions.AUDIENCE,
                        ValidateLifetime = true,
                        IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                        ValidateIssuerSigningKey = true,
                    };
                });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseCors();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");
            });

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseHttpsRedirection();
        }

        private static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IMongoClient, MongoClient>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILoginAppService, LoginAppService>();
        }

        private void ConfigureDatabase(IServiceCollection services)
        {
            ConfigureEntityMapping();

            //Non-editable config for connection database, no using in services (no IOptions<T>)
            var secOpts = Configuration
                .GetSection(DatabaseConfigName)
                .Get<DatabaseConfig>();

            services.AddSingleton(new MongoClient(secOpts!.ConnectionString).GetDatabase(secOpts.Name));
        }

        private void GetConfigs(IServiceCollection services)
        {
            services.AddKeyedScoped<OsuApiConfig>(Configuration.GetSection(OsuApiConfigName).Get<OsuApiConfig>());
        }

        private static void ConfigureOsuApiClient(IServiceCollection services)
        {
            services
                .AddRefitClient<IOsuApiClient>()
                .ConfigureHttpClient(c => c.BaseAddress = new Uri(OsuApiUri))
                .AddHttpMessageHandler<AuthHandler>();

            services.AddTransient<AuthHandler>();
        }
        private static void ConfigureEntityMapping()
        {
            Mapper<User>.EntityMapper();
        }
    }
}
