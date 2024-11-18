using MediatR;

namespace WSB.Biblioteka.Contracts.Generics;

public interface IQueryHandler<TQuery, TResponse> : IRequestHandler<IQuery<TResponse>, TResponse>
    where TQuery : IQuery<TResponse>
    where TResponse : class;