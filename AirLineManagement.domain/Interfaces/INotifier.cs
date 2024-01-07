
using Testes.domain.Notifications;

namespace Testes.domain.Interfaces
{
    public interface INotifier
    {
        public void AddNotification( NotificationWarning notification );
        public void AddNotifications( IEnumerable<NotificationWarning> notifications );
        public bool HasNotifications();
        public List<NotificationWarning> GetNotifications();

    }
}
