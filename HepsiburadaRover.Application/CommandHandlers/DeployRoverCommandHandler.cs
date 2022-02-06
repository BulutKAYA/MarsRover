using HepsiburadaRover.EventBus.Abstraction;
using HepsiburadaRover.Core.Domain.Aggregates;
using HepsiburadaRover.Core.Domain.Commands;
using System.Threading.Tasks;

namespace HepsiburadaRover.Application.CommandHandlers
{
    public class DeployRoverCommandHandler :
        IBaseEventHandler<DeployRoverCommand, RoverAggregate>
    {
        public async Task Handle(DeployRoverCommand @event)
        {
            bool executionResult = @event.Aggregate.DeployRover(@event.RoverPositionInput);
            
            await Task.FromResult(executionResult);
        }
    }
}