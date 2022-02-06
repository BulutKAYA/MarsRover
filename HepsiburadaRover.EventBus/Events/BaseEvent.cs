using HepsiburadaRover.EventBus.Abstraction;
using System;

namespace HepsiburadaRover.EventBus.Events
{
    public abstract class BaseEvent<TAggregate> : IBaseEvent<TAggregate>
        where TAggregate : IAggregateRoot
    {

        public BaseEvent(TAggregate aggregate)
        {
            Id = Guid.NewGuid();
            Aggregate = aggregate;
            CreatedDate = DateTime.Now;
        }

        public BaseEvent(Guid id, TAggregate aggregate)
        {
            Id = id;
            Aggregate = aggregate;
            CreatedDate = DateTime.Now;
        }

        public Guid Id { get ; }
        public DateTime CreatedDate { get ; }

        public TAggregate Aggregate { get; }
    }
}
