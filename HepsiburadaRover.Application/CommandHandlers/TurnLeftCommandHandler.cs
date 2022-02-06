using HepsiburadaRover.EventBus.Abstraction;
using HepsiburadaRover.Core.Domain.Aggregates;
using HepsiburadaRover.Core.Domain.Commands;
using System.Threading.Tasks;

namespace HepsiburadaRover.Application.CommandHandlers
{
    public class TurnLeftCommandHandler :
         IBaseEventHandler<TurnLeftCommand, RoverAggregate>
    {
        public Task Handle(TurnLeftCommand @event)
        {
            bool executionResult = @event.Aggregate.TurnLeft();

            return Task.FromResult(executionResult);
        }
    }
}