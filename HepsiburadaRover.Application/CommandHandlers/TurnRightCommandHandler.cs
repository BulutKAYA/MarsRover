using HepsiburadaRover.EventBus.Abstraction;
using HepsiburadaRover.Core.Domain.Aggregates;
using HepsiburadaRover.Core.Domain.Commands;
using System.Threading.Tasks;

namespace HepsiburadaRover.Application.CommandHandlers
{
    public class TurnRightCommandHandler :
        IBaseEventHandler<TurnRightCommand, RoverAggregate>
    {

        public async Task Handle(TurnRightCommand @event)
        {
            bool executionResult = @event.Aggregate.TurnRight();

            await Task.FromResult(executionResult);
        }
    }
}