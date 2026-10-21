using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services
{
    public class FollowService : IFollowService
    {
        private readonly IFollowRepository _followRepository;

        public FollowService(IFollowRepository followRepository)
        {
            _followRepository = followRepository;
        }

        public FollowDto FollowUser(CreateFollowDto dto)
        {
            if (dto.FollowerId == Guid.Empty)
                throw new ArgumentException("FollowerId is required.");

            if (dto.FollowingId == Guid.Empty)
                throw new ArgumentException("FollowingId is required.");

            if (dto.FollowerId == dto.FollowingId)
                throw new ArgumentException("A user cannot follow themselves.");

            var existingFollow = _followRepository.GetFollowByUsers(
                dto.FollowerId, dto.FollowingId);

            if (existingFollow is not null)
                throw new InvalidOperationException(
                    "You are already following this user.");

            var follow = new Follow(dto.FollowerId, dto.FollowingId);

            _followRepository.AddFollow(follow);

            return MapToDto(follow);
        }

        public List<FollowDto> GetFollowers(Guid userId)
        {
            return _followRepository.GetFollowers(userId)
                .Select(MapToDto)
                .ToList();
        }

        public List<FollowDto> GetFollowing(Guid userId)
        {
            return _followRepository.GetFollowing(userId)
                .Select(MapToDto)
                .ToList();
        }

        public FollowDto? GetFollowById(Guid id)
        {
            var follow = _followRepository.GetFollowById(id);

            return follow is null ? null : MapToDto(follow);
        }

        public bool UnfollowUser(Guid id)
        {
            return _followRepository.DeleteFollow(id);
        }

        private static FollowDto MapToDto(Follow follow)
        {
            return new FollowDto
            {
                Id = follow.Id,
                FollowerId = follow.FollowerId,
                FollowingId = follow.FollowingId
            };
        }
    }
}