using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services
{
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository _likeRepository;

        public LikeService(ILikeRepository likeRepository)
        {
            _likeRepository = likeRepository;
        }

        public LikeDto LikeTweet(CreateLikeDto dto)
        {
            if (dto.UserId == Guid.Empty)
                throw new ArgumentException("UserId is required.");

            if (dto.TweetId == Guid.Empty)
                throw new ArgumentException("TweetId is required.");

            var existingLike = _likeRepository.GetLikeByUserAndTweet(
                dto.UserId, dto.TweetId);

            if (existingLike is not null)
                throw new InvalidOperationException(
                    "This user has already liked this tweet.");

            var like = new Like(dto.UserId, dto.TweetId);

            _likeRepository.AddLike(like);

            return MapToDto(like);
        }

        public List<LikeDto> GetLikesByTweetId(Guid tweetId)
        {
            return _likeRepository.GetLikesByTweetId(tweetId)
                .Select(MapToDto)
                .ToList();
        }

        public List<LikeDto> GetLikesByUserId(Guid userId)
        {
            return _likeRepository.GetLikesByUserId(userId)
                .Select(MapToDto)
                .ToList();
        }

        public LikeDto? GetLikeById(Guid id)
        {
            var like = _likeRepository.GetLikeById(id);

            return like is null ? null : MapToDto(like);
        }

        public bool UnlikeTweet(Guid id)
        {
            return _likeRepository.DeleteLike(id);
        }

        private static LikeDto MapToDto(Like like)
        {
            return new LikeDto
            {
                Id = like.Id,
                UserId = like.UserId,
                TweetId = like.TweetId
            };
        }
    }
}