using TwitterClone.Application.Dtos.RetweetsDto;

namespace TwitterClone.Application.Interfaces
{
    public interface IRetweetService
    {
        RetweetDto? AddRetweet(CreateRetweetDto createRetweetDto);
        RetweetDto? GetRetweetById(Guid id);
        List<RetweetDto> GetRetweets();
        bool? DeleteRetweet(Guid id);
    }
}