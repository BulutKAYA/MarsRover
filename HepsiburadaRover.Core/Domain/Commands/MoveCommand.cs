using HepsiburadaRover.EventBus.Events;
using HepsiburadaRover.Core.Domain.Aggregates;
using System;

namespace HepsiburadaRover.Core.Domain.Commands
{
    public class MoveCommand : BaseEvent<RoverAggregate>
    {
        public MoveCommand(RoverAggregate aggregate) 
            : base(aggregate)
        {
        }
    }
}