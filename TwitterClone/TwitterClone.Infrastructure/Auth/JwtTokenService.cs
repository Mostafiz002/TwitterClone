using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Dtos.UsersDto;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Auth
{
    public class JwtTokenService : ITokenService
    {
        public (string, DateOnly) GetToken(UserDto user)
        {
            return (string.Empty, DateOnly.MinValue);
        }
    }
}
