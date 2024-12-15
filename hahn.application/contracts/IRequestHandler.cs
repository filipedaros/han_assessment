using MediatR;

namespace hahn.application.contracts;

public interface IRequestHandler<TRequest, TResponse> : MediatR.IRequestHandler<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    
}