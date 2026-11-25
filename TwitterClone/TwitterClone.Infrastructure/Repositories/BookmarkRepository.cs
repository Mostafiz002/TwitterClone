
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories
{
    public class BookmarkRepository : IBookmarkRepository
    {
        private readonly TwitterCloneDbContext _context;

        public BookmarkRepository(TwitterCloneDbContext context)
        {
            _context = context;
        }

        public Bookmark AddBookmark(Bookmark bookmark)
        {
            _context.Bookmarks.Add(bookmark);
            _context.SaveChanges();

            return bookmark;
        }

        public List<Bookmark> GetBookmarksByUserId(Guid userId)
        {
            return _context.Bookmarks
                .Where(b => b.UserId == userId)
                .ToList();
        }

        public Bookmark? GetBookmarkById(Guid id)
        {
            return _context.Bookmarks.Find(id);
        }

        public Bookmark? GetBookmarkByUserAndTweet(
            Guid userId,
            Guid tweetId)
        {
            return _context.Bookmarks.FirstOrDefault(
                b => b.UserId == userId && b.TweetId == tweetId);
        }

        public bool DeleteBookmark(Guid id)
        {
            var bookmark = _context.Bookmarks.Find(id);

            if (bookmark is null)
                return false;

            _context.Bookmarks.Remove(bookmark);
            _context.SaveChanges();

            return true;
        }
    }
}
