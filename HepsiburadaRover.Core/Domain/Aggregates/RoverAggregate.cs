using HepsiburadaRover.EventBus.Aggregates;
using HepsiburadaRover.Core.Domain.Enums;
using HepsiburadaRover.Core.Domain.ValueTypes;
using System;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace HepsiburadaRover.Core.Domain.Aggregates
{
    public class RoverAggregate : AggregateRoot
    {
        public RoverPosition RoverPosition { get; private set; }
        public Guid PlateauSurfaceId { get; private set; }

        //I maked static because same for all rovers

        public RoverAggregate(Guid id, Guid plateauSurfaceId) : base(id)
        {
            PlateauSurfaceId = plateauSurfaceId;
        }

        #region Aggregate methods
        public bool DeployRover(string roverPositionInput)
        {
            RoverPosition roverPosition = ParsePosition(roverPositionInput);
            this.RoverPosition = roverPosition;
            return true;
        }

        public bool TurnLeft()
        {
            this.RoverPosition.Orientation = (this.RoverPosition.Orientation - 1) < Orientation.N ? Orientation.W : this.RoverPosition.Orientation - 1;
            return true;
        }

        public bool TurnRight()
        {
            this.RoverPosition.Orientation = (this.RoverPosition.Orientation + 1) > Orientation.W ? Orientation.N : this.RoverPosition.Orientation + 1;
            return true;
        }

        public async Task<bool> MoveAsync()
        {
            int roverX = this.RoverPosition.X;
            int roverY = this.RoverPosition.Y;

            switch (this.RoverPosition.Orientation)
            {
                case Orientation.N:
                    this.RoverPosition.Y++;
                    break;

                case Orientation.S:
                    this.RoverPosition.Y--;
                    break;
                case Orientation.W:
                    this.RoverPosition.X--;
                    break;

                case Orientation.E:
                    this.RoverPosition.X++;
                    break;

                default:
                    throw new InvalidOperationException();
            }

            if (await IsRoverOutOfBoundariesAsync())
            {
                this.RoverPosition.X = roverX;
                this.RoverPosition.Y = roverY;
                Console.WriteLine();
            }
            return true;
        }
        #endregion

        #region Private methods
        private RoverPosition ParsePosition(string roverPositionInput)
        {
            var roverPositionArray = roverPositionInput.Split(' ');

            if (roverPositionArray.Length != 3)
                return null;

            string orientation = roverPositionArray[2].ToUpper();

            var oriantations = new List<string> { "N", "S", "E", "W"};

            if (!oriantations.Contains(orientation))
                return null;

            RoverPosition roverPosition = new RoverPosition()
            {
                Orientation = (Orientation)Enum.Parse(typeof(Orientation), orientation),
                X = int.Parse(roverPositionArray[0]),
                Y = int.Parse(roverPositionArray[1])
            };

            return roverPosition;

        }

        private Task<bool> IsRoverOutOfBoundariesAsync()
        {
            var plateau = AggregateStore.GetAggregateById<PlateauAggregate>(PlateauSurfaceId);

            var outsideFromBoundaries = RoverPosition.X > plateau.Size.Width ||
                RoverPosition.X < 0 ||
                RoverPosition.Y > plateau.Size.Height ||
                RoverPosition.Y < 0;

            return Task.FromResult(outsideFromBoundaries);
        }

        #endregion
    }
}