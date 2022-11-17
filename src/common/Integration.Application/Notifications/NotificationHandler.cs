namespace Integration.Application.Notifications;

public class NotificationHandler
{
    private readonly List<Notification> _notifications;
    public IReadOnlyList<Notification> Notifications => _notifications;
    public bool HasNotifications => _notifications.Any();
    
    public void AddNotification(string type, IEnumerable<string> messages)
    {
        var notification = new Notification(type, messages.ToList());
        _notifications.Add(notification);
    }
    
    public void AddNotification(string type, string message)
    {
        var notification = new Notification(type, new[] { message });
        _notifications.Add(notification);
    }
}