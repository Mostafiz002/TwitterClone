
using Microsoft.EntityFrameworkCore;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories
{
    public class TweetRepository : ITweetRepository
    {
        private readonly TwitterCloneDbContext _context;

        public TweetRepository(TwitterCloneDbContext context)
        {
            _context = context;
        }

        public Tweet AddTweet(Tweet tweet)
        {
            _context.Tweets.Add(tweet);
            _context.SaveChanges();

            return tweet;
        }

        public List<Tweet> GetTweets()
        {
            return _context.Tweets.ToList();
        }

        public Tweet? GetTweetById(Guid id)
        {
            return _context.Tweets.Find(id);
        }

        public Tweet UpdateTweet(Tweet tweet)
        {
            var existingTweet = _context.Tweets.Find(tweet.Id);

            if (existingTweet == null)
                throw new KeyNotFoundException("Tweet not found.");

            existingTweet.UpdateContent(tweet.Content);

            _context.SaveChanges();

            return existingTweet;
        }

        public bool DeleteTweet(Tweet tweet)
        {
            var existingTweet = _context.Tweets.Find(tweet.Id);

            if (existingTweet == null)
                return false;

            _context.Tweets.Remove(existingTweet);
            _context.SaveChanges();

            return true;
        }
    }
}
