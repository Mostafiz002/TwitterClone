
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly TwitterCloneDbContext _context;

        public MessageRepository(TwitterCloneDbContext context)
        {
            _context = context;
        }

        public Message AddMessage(Message message)
        {
            _context.Messages.Add(message);
            _context.SaveChanges();

            return message;
        }

        public List<Message> GetMessagesByUserId(Guid userId)
        {
            return _context.Messages
                .Where(m => m.SenderId == userId || m.ReceiverId == userId)
                .OrderBy(m => m.SentAt)
                .ToList();
        }

        public Message? GetMessageById(Guid id)
        {
            return _context.Messages.Find(id);
        }

        public bool DeleteMessage(Guid id)
        {
            var message = _context.Messages.Find(id);

            if (message is null)
                return false;

            _context.Messages.Remove(message);
            _context.SaveChanges();

            return true;
        }
    }
}
