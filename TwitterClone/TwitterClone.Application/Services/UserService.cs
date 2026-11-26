using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Dtos.UsersDto;
using TwitterClone.Application.Interfaces;
using TwitterClone.Application.Mappings;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public IPasswordHasher _PasswordHasher;

        public UserService(
            IUserRepository userRepository,
            IPasswordHasher passwordHasher
            )
        {
            _userRepository = userRepository;
            _PasswordHasher = passwordHasher;
        }

        public UserDto? CreateUser(CreateUserDto createUserDto)
        {
            if (string.IsNullOrWhiteSpace(createUserDto.FirstName) ||
               string.IsNullOrWhiteSpace(createUserDto.LastName) ||
               string.IsNullOrWhiteSpace(createUserDto.Email)
               )
            {
                return null;
            }

            var existingUser = _userRepository.GetUserByEmail(createUserDto.Email);
            if (existingUser != null)
            {
                return null;
            }

            var createdUser = _userRepository.AddUser(new User(createUserDto.Email)
            {
                FirstName = createUserDto.FirstName,
                LastName = createUserDto.LastName,
                PasswordHash = _PasswordHasher.Hash(createUserDto.ToDto(), createUserDto.Password)
            });

            return new UserDto
            {
                Id = createdUser.Id,
                FirstName = createdUser.FirstName,
                LastName = createdUser.LastName,
                Email = createdUser.Email,
            };
        }

        public List<UserDto> GetUsers()
        {
            var users = _userRepository.GetUsers();

            return users.Select(user => new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
            }).ToList();
        }

        public UserDto GetUserById(Guid id)
        {
            var user = _userRepository.GetUserById(id);

            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
            };
        }

        public UserDto? UpdateUser(Guid id, UpdateUserDto updateUserDto)
        {
            var user = _userRepository.GetUserById(id);
            if (user == null)
                return null;

            user.FirstName = updateUserDto.FirstName;
            user.LastName = updateUserDto.LastName;

            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
            };
        }

        public bool DeleteUser(Guid id)
        {
            var isDeleted = _userRepository.DeleteUser(id);
            if (!isDeleted)
                return false;

            return true;
        }
    }
}

