using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services
{
    public class BookmarkService : IBookmarkService
    {
        private readonly IBookmarkRepository _bookmarkRepository;

        public BookmarkService(IBookmarkRepository bookmarkRepository)
        {
            _bookmarkRepository = bookmarkRepository;
        }

        public BookmarkDto CreateBookmark(CreateBookmarkDto dto)
        {
            if (dto.UserId == Guid.Empty)
                throw new ArgumentException("UserId is required.");

            if (dto.TweetId == Guid.Empty)
                throw new ArgumentException("TweetId is required.");

            var existingBookmark = _bookmarkRepository
                .GetBookmarkByUserAndTweet(dto.UserId, dto.TweetId);

            if (existingBookmark is not null)
                throw new InvalidOperationException(
                    "This tweet is already bookmarked by the user.");

            var bookmark = new Bookmark(dto.UserId, dto.TweetId);

            _bookmarkRepository.AddBookmark(bookmark);

            return MapToDto(bookmark);
        }

        public List<BookmarkDto> GetBookmarksByUserId(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("UserId is required.");

            return _bookmarkRepository.GetBookmarksByUserId(userId)
                .Select(MapToDto)
                .ToList();
        }

        public BookmarkDto? GetBookmarkById(Guid id)
        {
            var bookmark = _bookmarkRepository.GetBookmarkById(id);

            return bookmark is null ? null : MapToDto(bookmark);
        }

        public bool RemoveBookmark(Guid id)
        {
            return _bookmarkRepository.DeleteBookmark(id);
        }

        private static BookmarkDto MapToDto(Bookmark bookmark)
        {
            return new BookmarkDto
            {
                Id = bookmark.Id,
                UserId = bookmark.UserId,
                TweetId = bookmark.TweetId
            };
        }
    }
}