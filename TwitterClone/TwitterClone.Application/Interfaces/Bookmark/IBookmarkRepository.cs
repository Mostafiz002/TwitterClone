using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface IBookmarkRepository
    {
        Bookmark AddBookmark(Bookmark bookmark);
        List<Bookmark> GetBookmarksByUserId(Guid userId);
        Bookmark? GetBookmarkById(Guid id);
        Bookmark? GetBookmarkByUserAndTweet(Guid userId, Guid tweetId);
        bool DeleteBookmark(Guid id);
    }
}