using HepsiburadaRover.EventBus.Events;
using System.Threading.Tasks;

namespace HepsiburadaRover.EventBus.Abstraction
{
    public interface IEventBus
    {
        Task PublishAsync<TAggregate>(IBaseEvent<TAggregate> @event)
            where TAggregate : IAggregateRoot;


        void Subscription<TAggregate, T, TH>() 
            where TAggregate : IAggregateRoot
            where T : IBaseEvent<TAggregate> 
            where TH : IBaseEventHandler<T, TAggregate> ;

    }
}
