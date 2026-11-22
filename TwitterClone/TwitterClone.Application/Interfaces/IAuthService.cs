using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Dtos;

namespace TwitterClone.Application.Interfaces
{
    public interface IAuthService
    {
        AuthResponseDto? Login(LoginDto loginDto);
    }
}
