﻿using LibraryAdministration.Application.Services.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibraryAdministration.Application.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetToken(IdentityUser user)
        {
            var expiration = DateTime.UtcNow.AddMinutes(int.Parse(_configuration["JWTAuthentication:ExpirationInMinutes"]));

            var token = CreateJwtToken(
                CreateClaims(user),
                CreateSigningCredentials(),
                expiration
            );

            var tokenHandler = new JwtSecurityTokenHandler();
            return tokenHandler.WriteToken(token);
        }

        private JwtSecurityToken CreateJwtToken(List<Claim> claims, SigningCredentials credentials, DateTime expiration)
        {
            return new JwtSecurityToken(
                issuer: _configuration["JWTAuthentication:ValidIssuer"],
                audience: _configuration["JWTAuthentication:ValidAudience"],
                claims,
                expires: expiration,
                signingCredentials: credentials
            );
        }

        private List<Claim> CreateClaims(IdentityUser user)
        {
            try
            {
                return new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Sub, "LibraryAdministrationToken"),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.Email, user.Email)
                };
            }
            catch (Exception e)
            {
                //TODO: log
                throw;
            }
        }

        private SigningCredentials CreateSigningCredentials()
        {
            return new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["JWTAuthentication:IssuerSigningKey"])
                ),
                SecurityAlgorithms.HmacSha256
            );
        }
    }
}
