using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Application.Dtos.TweetsDto;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface ITweetService
    {
        TweetDto AddTweet(CreateTweetDto createTweetDto);
        TweetDto GetTweetById(Guid id);
        List<TweetDto> GetTweets();
        TweetDto UpdateTweet(Guid id, UpdateTweetDto updateTweetDto);
        bool? DeleteTweet(Guid id);
    }
}
