using MediatR;

namespace hahn.application.contracts;

public interface IRequest<TResponse> : MediatR.IRequest<TResponse>
{
    
}