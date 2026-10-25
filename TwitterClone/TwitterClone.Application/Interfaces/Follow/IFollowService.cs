using TwitterClone.Application.Dtos;

namespace TwitterClone.Application.Interfaces
{
    public interface IFollowService
    {
        FollowDto FollowUser(CreateFollowDto dto);
        List<FollowDto> GetFollowers(Guid userId);
        List<FollowDto> GetFollowing(Guid userId);
        FollowDto? GetFollowById(Guid id);
        bool UnfollowUser(Guid id);
    }
}