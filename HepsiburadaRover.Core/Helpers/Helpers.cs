using HepsiburadaRover.EventBus.Events;
using HepsiburadaRover.Core.Domain.Aggregates;
using HepsiburadaRover.Core.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HepsiburadaRover.Core.Helpers
{
    public static class Helpers
    {
        public static IEnumerable<IBaseEvent<RoverAggregate>> ToRoverCommands(this string input, RoverAggregate rover)
        {
            foreach (Char letter in input.ToCharArray())
            {
                switch (char.ToUpper(letter))
                {
                    case 'L':
                        yield return new TurnLeftCommand(rover);
                        break;

                    case 'R':
                        yield return new TurnRightCommand(rover);
                        break;

                    case 'M':
                        yield return new MoveCommand(rover);
                        break;

                    default:
                        throw new InvalidOperationException();
                }
            }
        }
    }
}
