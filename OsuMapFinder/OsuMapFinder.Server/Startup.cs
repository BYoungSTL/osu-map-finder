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

namespace OsuMapFinder.Server
{
    public class Startup(IConfiguration configuration)
    {
        public IConfiguration Configuration { get; } = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();

            //Add GetConfiguration(services) with IOptions<T> for configure configs
            ConfigureEntityMapping();

            services.AddMvc();
            services.AddCors(options =>
            {
                options.AddPolicy("_origins",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:5173/",
                            "https://localhost:7107");
                    });
            });

            //Non-editable config for connection database, no using in services (no IOptions<T>)
            var secOpts = Configuration
                .GetSection("Database")
                .Get<DatabaseConfig>();

            services.AddSingleton(new MongoClient(secOpts!.ConnectionString).GetDatabase(secOpts.Name));

            services.AddScoped<IMongoClient, MongoClient>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ILoginAppService, LoginAppService>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo(){});
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

        private static void ConfigureEntityMapping()
        {
            Mapper<User>.EntityMapper();
        }
    }
}
