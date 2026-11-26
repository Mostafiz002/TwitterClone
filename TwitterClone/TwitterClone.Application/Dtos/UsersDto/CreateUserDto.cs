using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TwitterClone.Application.Dtos.UsersDto
{
    public class CreateUserDto
    {
        [Required]
        [StringLength(50)]
        public required string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public required string LastName { get; set; }
        [Required]
        [EmailAddress]
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
