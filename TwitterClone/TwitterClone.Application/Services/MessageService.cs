using TwitterClone.Application.Dtos;
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Application.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository _messageRepository;

        public MessageService(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public MessageDto SendMessage(CreateMessageDto dto)
        {
            if (dto.SenderId == Guid.Empty)
                throw new ArgumentException("SenderId is required.");

            if (dto.ReceiverId == Guid.Empty)
                throw new ArgumentException("ReceiverId is required.");

            if (dto.SenderId == dto.ReceiverId)
                throw new ArgumentException("A user cannot send a message to themselves.");

            if (string.IsNullOrWhiteSpace(dto.Content))
                throw new ArgumentException("Message content is required.");

            var message = new Message
            {
                SenderId = dto.SenderId,
                ReceiverId = dto.ReceiverId,
                Content = dto.Content.Trim(),
                SentAt = DateTime.UtcNow,
                IsRead = false
            };

            _messageRepository.AddMessage(message);

            return MapToDto(message);
        }

        public List<MessageDto> GetMessagesByUserId(Guid userId)
        {
            if (userId == Guid.Empty)
                throw new ArgumentException("UserId is required.");

            return _messageRepository.GetMessagesByUserId(userId)
                .Select(MapToDto)
                .ToList();
        }

        public MessageDto? GetMessageById(Guid id)
        {
            var message = _messageRepository.GetMessageById(id);

            return message is null ? null : MapToDto(message);
        }

        public bool MarkAsRead(Guid id)
        {
            var message = _messageRepository.GetMessageById(id);

            if (message is null)
                return false;

            message.IsRead = true;
            return true;
        }

        public bool DeleteMessage(Guid id)
        {
            return _messageRepository.DeleteMessage(id);
        }

        private static MessageDto MapToDto(Message message)
        {
            return new MessageDto
            {
                Id = message.Id,
                SenderId = message.SenderId,
                ReceiverId = message.ReceiverId,
                Content = message.Content,
                SentAt = message.SentAt,
                IsRead = message.IsRead
            };
        }
    }
}