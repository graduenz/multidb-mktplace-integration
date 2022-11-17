namespace Integration.Application.Notifications;

public class Notification
{
    public const string Validation = "validation";
    
    public Notification(string type, IReadOnlyList<string> messages)
    {
        Type = type;
        Messages = messages;
    }
    
    public string? Type { get; }
    public IReadOnlyList<string>? Messages { get; }
}