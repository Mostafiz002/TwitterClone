using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private readonly List<Like> _likes = new();

        public Like AddLike(Like like)
        {
            _likes.Add(like);
            return like;
        }

        public List<Like> GetLikesByTweetId(Guid tweetId)
        {
            return _likes
                .Where(like => like.TweetId == tweetId)
                .ToList();
        }

        public List<Like> GetLikesByUserId(Guid userId)
        {
            return _likes
                .Where(like => like.UserId == userId)
                .ToList();
        }

        public Like? GetLikeById(Guid id)
        {
            return _likes.FirstOrDefault(like => like.Id == id);
        }

        public Like? GetLikeByUserAndTweet(Guid userId, Guid tweetId)
        {
            return _likes.FirstOrDefault(
                like => like.UserId == userId && like.TweetId == tweetId);
        }

        public bool DeleteLike(Guid id)
        {
            var like = GetLikeById(id);

            if (like is null)
                return false;

            return _likes.Remove(like);
        }
    }
}