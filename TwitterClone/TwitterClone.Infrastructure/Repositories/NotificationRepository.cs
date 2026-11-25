
using TwitterClone.Application.Interfaces;
using TwitterClone.Domain.Entities;
using TwitterClone.Infrastructure.Persistence;

namespace TwitterClone.Infrastructure.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly TwitterCloneDbContext _context;

        public NotificationRepository(TwitterCloneDbContext context)
        {
            _context = context;
        }

        public Notification AddNotification(Notification notification)
        {
            _context.Notifications.Add(notification);
            _context.SaveChanges();

            return notification;
        }

        public List<Notification> GetNotifications()
        {
            return _context.Notifications.ToList();
        }

        public Notification? GetNotificationById(Guid id)
        {
            return _context.Notifications.Find(id);
        }

        public bool DeleteNotification(Guid id)
        {
            var notification = _context.Notifications.Find(id);

            if (notification is null)
                return false;

            _context.Notifications.Remove(notification);
            _context.SaveChanges();

            return true;
        }
    }
}
