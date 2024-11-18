using MediatR;

namespace WSB.Biblioteka.Contracts.Generics;

public interface IEventHandler<TEvent> : INotificationHandler<TEvent>
    where TEvent : IEvent;