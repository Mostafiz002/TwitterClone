using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Interfaces
{
    public interface IMessageRepository
    {
        Message AddMessage(Message message);
        List<Message> GetMessagesByUserId(Guid userId);
        Message? GetMessageById(Guid id);
        bool DeleteMessage(Guid id);
    }
}