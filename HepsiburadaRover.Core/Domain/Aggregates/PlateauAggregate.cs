using HepsiburadaRover.EventBus.Aggregates;
using HepsiburadaRover.Core.Domain.ValueTypes;
using System;
using System.Threading.Tasks;

namespace HepsiburadaRover.Core.Domain.Aggregates
{
    public class PlateauAggregate : AggregateRoot
    {
        public PlateauAggregate(Guid id) : base(id)
        {
        }

        public Size Size { get; set; }

        #region Aggregate methods
        public Task<bool> InitializeAsync(string surfaceSizeInput)
        {
            if (string.IsNullOrEmpty(surfaceSizeInput))
                return null;

            var gridSize = surfaceSizeInput.Split(' ');

            //If not Length equal to two return null
            if (gridSize.Length != 2)
                return null;

            //width can be converted to int control
            if (!int.TryParse(gridSize[0], out int width))
                return null;

            //height can be converted to int control
            if (!int.TryParse(gridSize[1], out int height))
                return null;

            Size = new Size(width, height);

            return Task.FromResult(true);
        }
        #endregion


    }
}