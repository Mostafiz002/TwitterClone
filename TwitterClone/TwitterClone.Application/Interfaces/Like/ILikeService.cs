using TwitterClone.Application.Dtos;

namespace TwitterClone.Application.Interfaces
{
    public interface ILikeService
    {
        LikeDto LikeTweet(CreateLikeDto dto);
        List<LikeDto> GetLikesByTweetId(Guid tweetId);
        List<LikeDto> GetLikesByUserId(Guid userId);
        LikeDto? GetLikeById(Guid id);
        bool UnlikeTweet(Guid id);
    }
}