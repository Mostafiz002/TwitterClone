using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface ILikeRepository
    {
        Like AddLike(Like like);
        List<Like> GetLikesByTweetId(Guid tweetId);
        List<Like> GetLikesByUserId(Guid userId);
        Like? GetLikeById(Guid id);
        Like? GetLikeByUserAndTweet(Guid userId, Guid tweetId);
        bool DeleteLike(Guid id);
    }
}