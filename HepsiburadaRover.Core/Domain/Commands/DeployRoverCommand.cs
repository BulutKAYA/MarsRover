using HepsiburadaRover.EventBus.Events;
using HepsiburadaRover.Core.Domain.Aggregates;
using System;

namespace HepsiburadaRover.Core.Domain.Commands
{
    public class DeployRoverCommand : BaseEvent<RoverAggregate>
    {
        public DeployRoverCommand(RoverAggregate aggregate, string roverPositionInput) 
            : base(aggregate)
        {
            RoverPositionInput = roverPositionInput;
        }

        public string RoverPositionInput { get; }
        
    }
}