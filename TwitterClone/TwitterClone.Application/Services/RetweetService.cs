using TwitterClone.Application.Dtos.RetweetsDto;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services
{
    public class RetweetService : IRetweetService
    {
        private readonly IRetweetRepository _retweetRepository;

        public RetweetService(IRetweetRepository retweetRepository)
        {
            _retweetRepository = retweetRepository;
        }

        public RetweetDto? AddRetweet(CreateRetweetDto createRetweetDto)
        {
            if (createRetweetDto.UserId == Guid.Empty ||
                createRetweetDto.TweetId == Guid.Empty)
            {
                return null;
            }

            var retweet = _retweetRepository.AddRetweet(
                new Retweet(
                    createRetweetDto.UserId,
                    createRetweetDto.TweetId
                )
            );

            return new RetweetDto
            {
                Id = retweet.Id,
                UserId = retweet.UserId,
                TweetId = retweet.TweetId,
                Comment = retweet.Comment,
                CreatedAt = retweet.CreatedAt
            };
        }

        public List<RetweetDto> GetRetweets()
        {
            var retweets = _retweetRepository.GetRetweets();

            return retweets.Select(retweet => new RetweetDto
            {
                Id = retweet.Id,
                UserId = retweet.UserId,
                TweetId = retweet.TweetId,
                Comment = retweet.Comment,
                CreatedAt = retweet.CreatedAt
            }).ToList();
        }

        public RetweetDto? GetRetweetById(Guid id)
        {
            var retweet = _retweetRepository.GetRetweetById(id);

            if (retweet == null)
                return null;

            return new RetweetDto
            {
                Id = retweet.Id,
                UserId = retweet.UserId,
                TweetId = retweet.TweetId,
                Comment = retweet.Comment,
                CreatedAt = retweet.CreatedAt
            };
        }

        public bool? DeleteRetweet(Guid id)
        {
            var retweet = _retweetRepository.GetRetweetById(id);

            if (retweet == null)
                return null;

            var isDeleted = _retweetRepository.DeleteRetweet(retweet);

            if (!isDeleted)
                return null;

            return true;
        }
    }
}