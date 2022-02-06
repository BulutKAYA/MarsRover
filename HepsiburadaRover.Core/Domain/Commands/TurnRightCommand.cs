using HepsiburadaRover.EventBus.Events;
using HepsiburadaRover.Core.Domain.Aggregates;
using System;

namespace HepsiburadaRover.Core.Domain.Commands
{
    public class TurnRightCommand : BaseEvent<RoverAggregate>
    {
        public TurnRightCommand(
            RoverAggregate aggregate) 
            : base(aggregate)
        {
        }
    }
}