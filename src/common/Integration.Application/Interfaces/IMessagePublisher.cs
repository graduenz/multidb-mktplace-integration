namespace Integration.Application.Interfaces;

public interface IMessagePublisher
{
    Task PublishMessageAsync<T>(string name, T data);
    Task PublishMessageAsync<T>(string name, T data, Dictionary<string, string> headers);
}