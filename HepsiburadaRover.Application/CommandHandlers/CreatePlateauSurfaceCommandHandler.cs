using HepsiburadaRover.EventBus.Abstraction;
using HepsiburadaRover.Core.Domain.Aggregates;
using HepsiburadaRover.Core.Domain.Commands;
using System.Threading.Tasks;

namespace HepsiburadaRover.Application.CommandHandlers
{
    public class CreatePlateauSurfaceCommandHandler :
         IBaseEventHandler<CreatePlateauSurfaceCommand, PlateauAggregate >
    {
        public async Task Handle(CreatePlateauSurfaceCommand @event)
        {
            bool executionResult = await @event.Aggregate.InitializeAsync(@event.SurfaceSizeInput);

            await Task.FromResult(executionResult);
        }
    }
}