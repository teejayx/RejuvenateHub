using System;
namespace SharedProject.Contracts
{
    public interface IDomainEventHandler<TEvent> where TEvent : IDomainEvent
    {
        void Handle(TEvent @event);
    }
}

