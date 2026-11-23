using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Dtos.TweetsDto;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Utilities.Extensions;

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
                Id = createTweet.Id,
                Content = createTweet.Content,
                UserId = createTweet.UserId
            };
        }

        public List<TweetDto> GetTweets()
        {
            var tweets = _tweetRepository.GetTweets();

            return tweets.Select(tweet => new TweetDto
            {
                Id = tweet.Id,
                Content = tweet.Content,
                UserId = tweet.UserId
            }).ToList();
        }

        public TweetDto GetTweetById(Guid id)
        {
            var tweet = _tweetRepository.GetTweetById(id);
            return new TweetDto
            {
                Id = tweet.Id,
                Content = tweet.Content,
                UserId = tweet.UserId
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
                Id = updatedTweet.Id,
                Content = updatedTweet.Content,
                UserId = updatedTweet.UserId
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

        public static bool IsValidContent(string content)
        {
            return !string.IsNullOrWhiteSpace(content) && content.Length <= Tweet.MaxContentLength && content.IsLong();
        }
    }
}