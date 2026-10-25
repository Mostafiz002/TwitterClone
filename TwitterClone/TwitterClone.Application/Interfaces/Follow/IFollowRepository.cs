using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface IFollowRepository
    {
        Follow AddFollow(Follow follow);
        List<Follow> GetFollowers(Guid userId);
        List<Follow> GetFollowing(Guid userId);
        Follow? GetFollowById(Guid id);
        Follow? GetFollowByUsers(Guid followerId, Guid followingId);
        bool DeleteFollow(Guid id);
    }
}