using System;
using System.Collections.Generic;
using System.Text;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface IRetweetRepository
    {
        Retweet AddRetweet(Retweet retweet);
        Retweet? GetRetweetById(Guid id);
        List<Retweet> GetRetweets();
        bool DeleteRetweet(Retweet retweet);
    }
}
