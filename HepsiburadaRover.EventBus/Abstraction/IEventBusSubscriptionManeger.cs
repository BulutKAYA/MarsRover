using HepsiburadaRover.EventBus.Events;
using System.Collections.Generic;

namespace HepsiburadaRover.EventBus.Abstraction
{
    public interface IEventBusSubscriptionManeger
    {
        void AddSubscription<T, TH, TAggregate>()
                   where T : IBaseEvent<TAggregate>
                   where TAggregate : IAggregateRoot
                   where TH : IBaseEventHandler<T, TAggregate>;
        bool HasSubscriptionsForEvent(string eventName);

        string GetEventKey<T>();

        IEnumerable<SubscriptionInfo> GetSubscribersForEvent(string eventName);
    }
}
