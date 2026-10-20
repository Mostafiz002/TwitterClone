using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;

namespace TwitterClone.Infrastructure.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly List<Message> _messages = new();

        public Message AddMessage(Message message)
        {
            _messages.Add(message);
            return message;
        }

        public List<Message> GetMessagesByUserId(Guid userId)
        {
            return _messages
                .Where(m => m.SenderId == userId || m.ReceiverId == userId)
                .OrderBy(m => m.SentAt)
                .ToList();
        }

        public Message? GetMessageById(Guid id)
        {
            return _messages.FirstOrDefault(m => m.Id == id);
        }

        public bool DeleteMessage(Guid id)
        {
            var message = GetMessageById(id);

            if (message is null)
                return false;

            return _messages.Remove(message);
        }
    }
}