using System;
using System.Collections.Generic;
using System.Text;

namespace TwitterClone.Application.Dtos.UsersDto
{
    public class UserDto
    {
        public required Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
    }
}
