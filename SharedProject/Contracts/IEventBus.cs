using System;
namespace SharedProject.Contracts
{
	public interface IEventBus
	{
        void Publish<TEvent>(TEvent @event) where TEvent : IDomainEvent;
        void Subscribe<TEvent, THandler>() where TEvent : IDomainEvent where THandler : IDomainEventHandler<TEvent>;

    }
}

