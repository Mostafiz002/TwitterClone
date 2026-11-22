using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Application.Mappings;

namespace TwitterClone.Application.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;
        private readonly ITokenService _tokenService;

        public AuthService(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher,
            ITokenService tokenService
            )
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
            _tokenService = tokenService;
        }

        public AuthResponseDto? Login(LoginDto loginDto)
        {
            var user = _userRepository.GetUserByEmail(loginDto.Email);
            var userAuthorized = _passwordHasher.VerifyPassword(loginDto.Password, user.PasswordHash);

            if (userAuthorized)
            {
                var (token, expiryTime) = _tokenService.GetToken(user.ToDto());

                return new AuthResponseDto
                {
                    AccessToken = token,
                    ExpiresAt = expiryTime.ToDateTime(TimeOnly.MinValue),
                    User = user.ToDto()
                };
            }

            return null;
        }
    }
}
