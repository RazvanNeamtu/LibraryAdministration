using LibraryAdministration.Application.DependencyInjection;
using LibraryAdministration.DataAccess.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LibraryAdministration.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            IConfiguration configuration = new ConfigurationBuilder()
                                            .AddJsonFile("appsettings.json")
                                            .Build();
            // Add services to the container.
            builder.Services.AddDbContext<UsersContext>();
            builder.Services.RegisterApplication();

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                            .AddJwtBearer(options =>
                            {
                                options.TokenValidationParameters = new TokenValidationParameters()
                                {
                                    ClockSkew = TimeSpan.Zero,
                                    ValidateIssuer = true,
                                    ValidateAudience = true,
                                    ValidateLifetime = true,
                                    ValidateIssuerSigningKey = true,
                                    ValidIssuer = configuration["JWTAuthentication:ValidIssuer"],
                                    ValidAudience = configuration["JWTAuthentication:ValidAudience"],
                                    IssuerSigningKey = new SymmetricSecurityKey(
                                        Encoding.UTF8.GetBytes(configuration["JWTAuthentication:IssuerSigningKey"])
                                    ),
                                };
                            });

            builder.Services.AddIdentityCore<IdentityUser>(options =>
                            {
                                options.SignIn.RequireConfirmedAccount = false;
                                options.User.RequireUniqueEmail = true;
                                options.Password.RequireDigit = false;
                                options.Password.RequiredLength = 6;
                                options.Password.RequireNonAlphanumeric = false;
                                options.Password.RequireUppercase = false;
                                options.Password.RequireLowercase = false;
                            })
                            .AddEntityFrameworkStores<UsersContext>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}