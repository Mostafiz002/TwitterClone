using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Dtos.UsersDto;

namespace TwitterClone.Application.Dtos
{
    public class AuthResponseDto
    {
        public required string AccessToken { get; set; }
        public required DateTime ExpiresAt { get; set; }
        public required UserDto User { get; set; }

    }
}
