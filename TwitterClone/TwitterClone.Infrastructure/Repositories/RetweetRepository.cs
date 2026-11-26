
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories
{
    public class RetweetRepository : IRetweetRepository
    {
        private readonly TwitterCloneDbContext _context;

        public RetweetRepository(TwitterCloneDbContext context)
        {
            _context = context;
        }

        public Retweet AddRetweet(Retweet retweet)
        {
            _context.Retweets.Add(retweet);
            _context.SaveChanges();

            return retweet;
        }

        public List<Retweet> GetRetweets()
        {
            return _context.Retweets.ToList();
        }

        public Retweet? GetRetweetById(Guid id)
        {
            return _context.Retweets.Find(id);
        }

        public bool DeleteRetweet(Retweet retweet)
        {
            var existingRetweet = _context.Retweets.Find(retweet.Id);

            if (existingRetweet == null)
                return false;

            _context.Retweets.Remove(existingRetweet);
            _context.SaveChanges();

            return true;
        }
    }
}
