using TwitterClone.Application.Dtos;

namespace TwitterClone.Application.Interfaces
{
    public interface IBookmarkService
    {
        BookmarkDto CreateBookmark(CreateBookmarkDto dto);
        List<BookmarkDto> GetBookmarksByUserId(Guid userId);
        BookmarkDto? GetBookmarkById(Guid id);
        bool RemoveBookmark(Guid id);
    }
}