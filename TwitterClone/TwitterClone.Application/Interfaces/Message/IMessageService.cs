using TwitterClone.Application.Dtos;

namespace TwitterClone.Application.Interfaces
{
    public interface IMessageService
    {
        MessageDto SendMessage(CreateMessageDto dto);
        List<MessageDto> GetMessagesByUserId(Guid userId);
        MessageDto? GetMessageById(Guid id);
        bool MarkAsRead(Guid id);
        bool DeleteMessage(Guid id);
    }
}