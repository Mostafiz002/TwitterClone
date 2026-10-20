using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Dtos.TweetsDto;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services
{
    public class TweetService : ITweetService
    {
        private readonly ITweetRepository _tweetRepository;
        public TweetService(ITweetRepository tweetRepository)
        {
            _tweetRepository = tweetRepository;
        }

        public TweetDto? AddTweet(CreateTweetDto createTweetDto)
        {
            if (string.IsNullOrWhiteSpace(createTweetDto.Content) ||
                createTweetDto.UserId == Guid.Empty
                )
            {
                return null;
            }

            var createTweet = _tweetRepository.AddTweet(new Tweet(createTweetDto.Content,
                createTweetDto.UserId)
            { });

            return new TweetDto
            {
                Id = createTweet.Id.ToString(),
                Content = createTweet.Content,
                UserId = createTweet.UserId.ToString()
            };
        }

        public List<TweetDto> GetTweets()
        {
            var tweets = _tweetRepository.GetTweets();

            return tweets.Select(tweet => new TweetDto
            {
                Id = tweet.Id.ToString(),
                Content = tweet.Content,
                UserId = tweet.UserId.ToString()
            }).ToList();
        }

        public TweetDto GetTweetById(Guid id)
        {
            var tweet = _tweetRepository.GetTweetById(id);
            return new TweetDto
            {
                Id = tweet.Id.ToString(),
                Content = tweet.Content,
                UserId = tweet.UserId.ToString()
            };
        }


        public TweetDto? UpdateTweet(Guid id, UpdateTweetDto updateTweetDto)
        {
            var tweet = _tweetRepository.GetTweetById(id);
            if (tweet == null)
                return null;

            tweet.UpdateContent(updateTweetDto.Content);

            var updatedTweet = _tweetRepository.UpdateTweet(tweet);

            return new TweetDto
            {
                Id = updatedTweet.Id.ToString(),
                Content = updatedTweet.Content,
                UserId = updatedTweet.UserId.ToString()
            };
        }
        public bool? DeleteTweet(Guid id)
        {
            var tweet = _tweetRepository.GetTweetById(id);
            if (tweet == null)
                return null;

            var isDeleted = _tweetRepository.DeleteTweet(tweet);
            if (!isDeleted)
                return null;

            return true;
        }
    }
}
