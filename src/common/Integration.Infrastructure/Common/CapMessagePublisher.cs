using DotNetCore.CAP;
using Integration.Application.Interfaces;

namespace Integration.Infrastructure.Common;

public class CapMessagePublisher : IMessagePublisher
{
    private readonly ICapPublisher _cap;

    public CapMessagePublisher(ICapPublisher cap)
    {
        _cap = cap;
    }

    public Task PublishMessageAsync<T>(string name, T data) =>
        _cap.PublishAsync(name, data);

    public Task PublishMessageAsync<T>(string name, T data, Dictionary<string, string> headers) =>
        _cap.PublishAsync(name, data, headers);
}