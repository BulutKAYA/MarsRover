using HepsiburadaRover.EventBus.Events;
using HepsiburadaRover.Core.Domain.Aggregates;
using System;

namespace HepsiburadaRover.Core.Domain.Commands
{
    public class CreatePlateauSurfaceCommand : BaseEvent<PlateauAggregate>
    {
        public CreatePlateauSurfaceCommand(PlateauAggregate aggregate, string surfaceSizeInput) : base(aggregate)
        {
            SurfaceSizeInput = surfaceSizeInput;
        }

        public string SurfaceSizeInput { get; }
    }
}