using MediatR;

namespace WSB.Biblioteka.Contracts.Generics;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand> 
    where TCommand : ICommand;