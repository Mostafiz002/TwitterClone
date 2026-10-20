using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Repositories
{
    public class RetweetRepository : IRetweetRepository
    {
        private List<Retweet> _retweets { get; set; } = new List<Retweet>();

        public Retweet AddRetweet(Retweet retweet)
        {
            _retweets.Add(retweet);
            return retweet;
        }

        public List<Retweet> GetRetweets()
        {
            return _retweets;
        }

        public Retweet? GetRetweetById(Guid id)
        {
            return _retweets.SingleOrDefault(retweet => retweet.Id == id);
        }

        public bool DeleteRetweet(Retweet retweet)
        {
            return _retweets.Remove(retweet);
        }
    }
}