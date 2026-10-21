using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Repositories
{
    public class BookmarkRepository : IBookmarkRepository
    {
        private readonly List<Bookmark> _bookmarks = new();

        public Bookmark AddBookmark(Bookmark bookmark)
        {
            _bookmarks.Add(bookmark);
            return bookmark;
        }

        public List<Bookmark> GetBookmarksByUserId(Guid userId)
        {
            return _bookmarks
                .Where(b => b.UserId == userId)
                .ToList();
        }

        public Bookmark? GetBookmarkById(Guid id)
        {
            return _bookmarks.FirstOrDefault(b => b.Id == id);
        }

        public Bookmark? GetBookmarkByUserAndTweet(
            Guid userId,
            Guid tweetId)
        {
            return _bookmarks.FirstOrDefault(
                b => b.UserId == userId && b.TweetId == tweetId);
        }

        public bool DeleteBookmark(Guid id)
        {
            var bookmark = GetBookmarkById(id);

            if (bookmark is null)
                return false;

            return _bookmarks.Remove(bookmark);
        }
    }
}