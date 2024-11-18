using MediatR;

namespace WSB.Biblioteka.Contracts.Generics;

public interface IQuery<out TResponse> : IRequest<TResponse>
    where TResponse : class;