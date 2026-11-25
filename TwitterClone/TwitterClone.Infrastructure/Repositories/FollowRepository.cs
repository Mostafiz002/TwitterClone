
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories
{
    public class FollowRepository : IFollowRepository
    {
        private readonly TwitterCloneDbContext _context;

        public FollowRepository(TwitterCloneDbContext context)
        {
            _context = context;
        }

        public Follow AddFollow(Follow follow)
        {
            _context.Follows.Add(follow);
            _context.SaveChanges();

            return follow;
        }

        public List<Follow> GetFollowers(Guid userId)
        {
            return _context.Follows
                .Where(f => f.FollowingId == userId)
                .ToList();
        }

        public List<Follow> GetFollowing(Guid userId)
        {
            return _context.Follows
                .Where(f => f.FollowerId == userId)
                .ToList();
        }

        public Follow? GetFollowById(Guid id)
        {
            return _context.Follows.Find(id);
        }

        public Follow? GetFollowByUsers(Guid followerId, Guid followingId)
        {
            return _context.Follows.FirstOrDefault(
                f => f.FollowerId == followerId &&
                     f.FollowingId == followingId);
        }

        public bool DeleteFollow(Guid id)
        {
            var follow = _context.Follows.Find(id);

            if (follow is null)
                return false;

            _context.Follows.Remove(follow);
            _context.SaveChanges();

            return true;
        }
    }
}
