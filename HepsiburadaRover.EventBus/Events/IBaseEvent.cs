using HepsiburadaRover.EventBus.Abstraction;
using System;

namespace HepsiburadaRover.EventBus.Events
{
    public interface IBaseEvent<TAggregate> : IEvent
         where TAggregate : IAggregateRoot
    {
        Guid Id { get; }
        TAggregate Aggregate { get; }

        DateTime CreatedDate { get;}

    }

    public interface IEvent { }
}
