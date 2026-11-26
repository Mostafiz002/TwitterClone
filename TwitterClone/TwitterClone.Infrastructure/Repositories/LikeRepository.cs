
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private readonly TwitterCloneDbContext _context;

        public LikeRepository(TwitterCloneDbContext context)
        {
            _context = context;
        }

        public Like AddLike(Like like)
        {
            _context.Likes.Add(like);
            _context.SaveChanges();

            return like;
        }

        public List<Like> GetLikesByTweetId(Guid tweetId)
        {
            return _context.Likes
                .Where(like => like.TweetId == tweetId)
                .ToList();
        }

        public List<Like> GetLikesByUserId(Guid userId)
        {
            return _context.Likes
                .Where(like => like.UserId == userId)
                .ToList();
        }

        public Like? GetLikeById(Guid id)
        {
            return _context.Likes.Find(id);
        }

        public Like? GetLikeByUserAndTweet(Guid userId, Guid tweetId)
        {
            return _context.Likes.FirstOrDefault(
                like => like.UserId == userId && like.TweetId == tweetId);
        }

        public bool DeleteLike(Guid id)
        {
            var like = _context.Likes.Find(id);

            if (like is null)
                return false;

            _context.Likes.Remove(like);
            _context.SaveChanges();

            return true;
        }
    }
}
