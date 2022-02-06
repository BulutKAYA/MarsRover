using HepsiburadaRover;
using HepsiburadaRover.EventBus;
using HepsiburadaRover.EventBus.Events;
using HepsiburadaRover.Core.Domain.Aggregates;
using HepsiburadaRover.Core.Domain.Commands;
using HepsiburadaRover.Core.Domain.Enums;
using HepsiburadaRover.Core.Helpers;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace HepsiburadaRover.Test
{
    public class RoverTests
    {
        [Theory]
        [InlineData(new object[] { "5 5", "1 2 N", "LMLMLMLMM", 1, 3, Orientation.N })]
        public async Task TestRover(
            string plateauSurfaceSize, 
            string roverPosition, 
            string roverCommand,
            int expectedX,
            int exceptedY,
            Orientation expectedOrientation
            )
        {
            var roverList = new List<Guid>();
            var plateauList = new List<Guid>();

            var plateauAggregateId = Guid.NewGuid();
            var plateauAggregate = new PlateauAggregate(plateauAggregateId);
            AggregateStore.AppAggretates.Add(plateauAggregateId, plateauAggregate);
            plateauList.Add(plateauAggregateId);

            var createPlateauSurfaceCommand = new CreatePlateauSurfaceCommand(plateauAggregate, plateauSurfaceSize);

            var commands = new List<IEvent>();
            commands.Add(createPlateauSurfaceCommand);

            var roverAggregateId = Guid.NewGuid();
            var rover = new RoverAggregate(roverAggregateId, plateauAggregateId);
            roverList.Add(roverAggregateId);
            AggregateStore.AppAggretates.Add(roverAggregateId, rover);

            var deployRoverCommand = new DeployRoverCommand(rover, roverPosition);

            commands.Add(deployRoverCommand);
            commands.AddRange(roverCommand.ToRoverCommands(rover));

            var eventBus = EventBusFactory.Create(HepsiburadaRover.EventBus.Enums.EventBusType.BaseEventBus);

            await eventBus.RunAllComands(commands);

            Assert.NotNull(rover);
            Assert.NotNull(rover.RoverPosition);
            Assert.Equal(expectedX, rover.RoverPosition.X);
            Assert.Equal(exceptedY, rover.RoverPosition.Y);
            Assert.Equal(expectedOrientation, rover.RoverPosition.Orientation);
        }
    }
}
