using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Dtos.UsersDto;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Auth
{
    public class JwtTokenService : ITokenService
    {
        private readonly JwtSettings _jwtSettings;
        private JsonWebTokenHandler _jwtHandler = new JsonWebTokenHandler();

        public JwtTokenService(
            JwtSettings jwtSettings)
        {
            _jwtSettings = jwtSettings;
        }

        public (string, DateTime) GetToken(UserDto user)
        {
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
            };

            var expiryTime = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryInMinutes);

            var signKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));

            var descriper = new SecurityTokenDescriptor()
            {
                Audience = _jwtSettings.Audience,
                Issuer = _jwtSettings.Issuer,
                Subject = new ClaimsIdentity(claims),
                Expires = expiryTime,
                SigningCredentials = new SigningCredentials(signKey, SecurityAlgorithms.HmacSha256)
            };

            return (_jwtHandler.CreateToken(descriper), DateTime.UtcNow.AddMinutes(_jwtSettings.ExpiryInMinutes));
        }
    }
}
