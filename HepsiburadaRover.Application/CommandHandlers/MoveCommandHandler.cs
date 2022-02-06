using HepsiburadaRover.EventBus.Abstraction;
using HepsiburadaRover.Core.Domain.Aggregates;
using HepsiburadaRover.Core.Domain.Commands;
using System.Threading.Tasks;

namespace HepsiburadaRover.Application.CommandHandlers
{
    public class MoveCommandHandler :
        IBaseEventHandler<MoveCommand, RoverAggregate>
    {
        public async Task Handle(MoveCommand @event)
        {
            bool executionResult = await @event.Aggregate.MoveAsync();

        }
    }
}