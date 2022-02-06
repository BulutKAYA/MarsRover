using HepsiburadaRover.EventBus.Abstraction;
using System;
using System.Collections.Generic;

namespace HepsiburadaRover.Core.Domain.Aggregates
{
    public static class AggregateStore
    {
        public static Dictionary<Guid, IAggregateRoot> AppAggretates { get; set; } = new Dictionary<Guid, IAggregateRoot>();

        public static IAggregate GetAggregateById<IAggregate>(Guid id)
            where IAggregate : IAggregateRoot
        {
            
            return (IAggregate)AppAggretates[id];
        }
    }
}
