using HepsiburadaRover.EventBus;
using HepsiburadaRover.EventBus.Events;
using HepsiburadaRover.Core.Domain.Aggregates;
using HepsiburadaRover.Core.Domain.Commands;
using HepsiburadaRover.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HepsiburadaRover
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var roverList = new List<Guid>();
            var plateauList = new List<Guid>();

            Console.WriteLine("Plateau surface size :");

            var sizeInput = Console.ReadLine();

            var plateauAggregateId = Guid.NewGuid();
            var plateauAggregate = new PlateauAggregate(plateauAggregateId);
            AggregateStore.AppAggretates.Add(plateauAggregateId, plateauAggregate);
            plateauList.Add(plateauAggregateId);

            var createPlateauSurfaceCommand = new CreatePlateauSurfaceCommand(plateauAggregate, sizeInput);

            var commands = new List<IEvent>();
            commands.Add(createPlateauSurfaceCommand);

            while (true)
            {
                Console.WriteLine("Position :");
                string roverPositionInput = Console.ReadLine();

                Console.WriteLine("Commands :");
                var roverCommandInput = Console.ReadLine();

                var roverAggregateId = Guid.NewGuid();
                var rover = new RoverAggregate(roverAggregateId, plateauAggregateId);
                roverList.Add(roverAggregateId);
                AggregateStore.AppAggretates.Add(roverAggregateId, rover);

                var deployRoverCommand = new DeployRoverCommand(rover, roverPositionInput);

                commands.Add(deployRoverCommand);
                commands.AddRange(roverCommandInput.ToRoverCommands(rover));

                Console.WriteLine("Do you want to add another rover ? (Y/N)");
                var addRoverInput = Console.ReadLine();

                if (!addRoverInput.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                {
                    break;
                }
            }

            //Can be use different message brokers
            var eventBus = EventBusFactory.Create(EventBus.Enums.EventBusType.BaseEventBus);

            await eventBus.RunAllComands(commands);
            
            Console.WriteLine("Output :");

            foreach (var roverId in roverList)
            {
                var rover = AggregateStore.GetAggregateById<RoverAggregate>(roverId);

                Console.WriteLine($"{rover.RoverPosition.X} " +
                  $"{rover.RoverPosition.Y} " +
                  $"{rover.RoverPosition.Orientation.ToString()}");
            }

            Console.Write("Press <enter> to exit...");
            Console.ReadLine();
        }
    }
}
