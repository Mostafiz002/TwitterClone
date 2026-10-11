using TwitterClone.Domain.Entities;

namespace TwitterClone.Api.Data
{
    public class TweetRepository
    {
        private List<Tweet> _tweets { get; set; } = new List<Tweet>();

        public Tweet AddTweet(Tweet tweet)
        {
            _tweets.Add(tweet);
            return tweet;
        }

        public List<Tweet> GetTweets()
        {
            return _tweets;
        }

        public Tweet? GetTweetById(Guid id)
        {
            return _tweets.SingleOrDefault(t => t.Id == id);
        }

        public Tweet UpdateTweet(Tweet tweet)
        {
            var existingTweet = _tweets.FirstOrDefault(t => t.Id == tweet.Id);
            if (existingTweet == null)
                throw new KeyNotFoundException("Tweet not found.");

            existingTweet.UpdateContent(tweet.Content);

            return existingTweet;
        }

        public bool DeleteTweet (Tweet tweet)
        {
            return _tweets.Remove(tweet);
        }
    }
}
