using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface ITweetRepository
    {
        Tweet AddTweet(Tweet tweet);
        Tweet UpdateTweet(Tweet tweet);
        Tweet? GetTweetById(Guid id);
        List<Tweet> GetTweets();
        bool DeleteTweet(Tweet tweet);
    }
}
