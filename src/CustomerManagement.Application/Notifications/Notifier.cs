using FluentValidation.Results;

namespace CustomerManagement.Application.Notifications
{
    public class Notifier : INotifier
    {
        private List<Notification> _notifications;

        public Notifier()
        {
            _notifications = new List<Notification>();
        }

        public void AddNotification(string notification)
        {
            _notifications.Add(new Notification(notification));
        }

        public void AddNotification(Notification Notification)
        {
            _notifications.Add(Notification);
        }

        public void AddNotifications(List<ValidationFailure> errors)
        {
            foreach (var erro in errors)
            {
                AddNotification(erro.ErrorMessage);
            }
        }

        public List<Notification> GetNotifications()
        {
            return _notifications;
        }

        public bool HasNotification()
        {
            return _notifications.Any();
        }
    }
}
