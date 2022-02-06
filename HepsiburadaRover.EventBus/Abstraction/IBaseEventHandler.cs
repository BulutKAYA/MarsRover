using HepsiburadaRover.EventBus.Events;
using System.Threading.Tasks;

namespace HepsiburadaRover.EventBus.Abstraction
{
    public interface IBaseEventHandler<TEvent, TAggregate> where TEvent : IBaseEvent<TAggregate>
         where TAggregate : IAggregateRoot
    {
        Task Handle(TEvent @event);
    }
}
