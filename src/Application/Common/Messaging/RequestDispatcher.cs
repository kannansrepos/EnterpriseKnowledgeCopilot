using Application.Abstractions.Messaging;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Common.Messaging;

public class RequestDispatcher(IServiceProvider serviceProvider) : IRequestDispatcher
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;

    public async Task<TResponse> Send<TResponse>(IRequest<TResponse> request,
        CancellationToken cancellationToken = default)
    {
        var handlerType = typeof(IRequestHandler<,>)
            .MakeGenericType(request.GetType(), typeof(TResponse));
        var handler = _serviceProvider.GetRequiredService(handlerType);
        var method = handlerType.GetMethod("Handle");
        if (method == null)
            throw new InvalidOperationException("Handler method not found");
        var result = method.Invoke(handler, [request, cancellationToken]);
        return await (Task<TResponse>)result!;
    }

}