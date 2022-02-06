using HepsiburadaRover.EventBus.Abstraction;
using System;

namespace HepsiburadaRover.EventBus.Aggregates
{
    public abstract class AggregateRoot : IAggregateRoot
    {
        public AggregateRoot()
        {
            Id = Guid.NewGuid();
        }

        public AggregateRoot(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
