using FluentValidation.Results;

namespace CustomerManagement.Application.Notifications
{
    public interface INotifier
    {
        bool HasNotification();
        List<Notification> GetNotifications();
        void AddNotification(string notification);
        void AddNotification(Notification Notification);
        void AddNotifications(List<ValidationFailure> errors);
    }
}
