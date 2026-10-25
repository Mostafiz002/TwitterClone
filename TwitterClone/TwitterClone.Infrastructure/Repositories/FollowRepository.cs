using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Repositories
{
    public class FollowRepository : IFollowRepository
    {
        private readonly List<Follow> _follows = new();

        public Follow AddFollow(Follow follow)
        {
            _follows.Add(follow);
            return follow;
        }

        public List<Follow> GetFollowers(Guid userId)
        {
            return _follows
                .Where(f => f.FollowingId == userId)
                .ToList();
        }

        public List<Follow> GetFollowing(Guid userId)
        {
            return _follows
                .Where(f => f.FollowerId == userId)
                .ToList();
        }

        public Follow? GetFollowById(Guid id)
        {
            return _follows.FirstOrDefault(f => f.Id == id);
        }

        public Follow? GetFollowByUsers(Guid followerId, Guid followingId)
        {
            return _follows.FirstOrDefault(
                f => f.FollowerId == followerId &&
                     f.FollowingId == followingId);
        }

        public bool DeleteFollow(Guid id)
        {
            var follow = GetFollowById(id);

            if (follow is null)
                return false;

            return _follows.Remove(follow);
        }
    }
}