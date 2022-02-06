using HepsiburadaRover.EventBus.Events;
using HepsiburadaRover.Core.Domain.Aggregates;
using System;

namespace HepsiburadaRover.Core.Domain.Commands
{
    public class TurnLeftCommand : BaseEvent<RoverAggregate>
    {
        public TurnLeftCommand(
            RoverAggregate aggregate) 
            : base(aggregate)
        {
        }
    }
}