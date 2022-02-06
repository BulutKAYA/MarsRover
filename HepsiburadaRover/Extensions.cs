using HepsiburadaRover.EventBus.Abstraction;
using HepsiburadaRover.EventBus.Events;
using HepsiburadaRover.Application.CommandHandlers;
using HepsiburadaRover.Core.Domain.Aggregates;
using HepsiburadaRover.Core.Domain.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HepsiburadaRover
{
    public static class Extensions
    {
        public static void ConfigureEventBus(this IEventBus eventBus)
        {
            eventBus.Subscription<PlateauAggregate, CreatePlateauSurfaceCommand, CreatePlateauSurfaceCommandHandler>();
            eventBus.Subscription<RoverAggregate, DeployRoverCommand, DeployRoverCommandHandler>();
            eventBus.Subscription<RoverAggregate, MoveCommand, MoveCommandHandler>();
            eventBus.Subscription<RoverAggregate, TurnLeftCommand, TurnLeftCommandHandler>();
            eventBus.Subscription<RoverAggregate, TurnRightCommand, TurnRightCommandHandler>();
        }

        public async static Task RunAllComands(this IEventBus eventBus, List<IEvent> commands)
        {
            //Adding commands and handlers
            eventBus.ConfigureEventBus();

            foreach (dynamic item in commands)
            {
                await eventBus.PublishAsync(item);
            }

        }
    }
}
