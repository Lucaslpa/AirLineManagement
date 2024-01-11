
using Testes.domain.Interfaces;
using Testes.domain.Notification;

namespace Testes.domain.Notification
{
    public class Notifier : INotifier
    {

        private readonly List<NotificationWarning> _notifications;

        public Notifier()
        {
            _notifications = [];
        }

        public void AddNotification( NotificationWarning notification )
        {
            _notifications.Add(notification);
        }

        public void AddNotifications(IEnumerable<NotificationWarning> notifications)
        {
            _notifications.AddRange( notifications );
        }

        public bool HasNotifications()
        {
            return _notifications.Count != 0;
        }

        public List<NotificationWarning> GetNotifications()
        {
            return _notifications;
        }
    }
}
