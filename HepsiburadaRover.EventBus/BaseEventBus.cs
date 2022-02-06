using HepsiburadaRover.EventBus.Abstraction;
using HepsiburadaRover.EventBus.Events;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace HepsiburadaRover.EventBus
{
    public class BaseEventBus : IEventBus
    {
        public readonly IEventBusSubscriptionManeger SubManeger;

        public BaseEventBus(IEventBusSubscriptionManeger subManeger)
        {
            SubManeger = subManeger;
        }

        public async Task<bool> ProcessEvent<TAggregate>(IBaseEvent<TAggregate> @event) where TAggregate : IAggregateRoot
        {
            var processed = false;
            string eventName = @event.GetType().Name;

            if (SubManeger.HasSubscriptionsForEvent(eventName))
            {
                var subscriptions = SubManeger.GetSubscribersForEvent(eventName);

                foreach (var subscription in subscriptions)
                {
                    var instance = Activator.CreateInstance(subscription.HandlerType);

                    MethodInfo method = subscription.HandlerType.GetMethod("Handle");

                    await Task.Run(() => method.Invoke(instance, new object[] { @event }));
                }

                processed = true;

            }

            return processed;
        }

        public async virtual Task PublishAsync<TAggregate>(IBaseEvent<TAggregate> @event) where TAggregate : IAggregateRoot
        {
            await ProcessEvent(@event);
        }

        public virtual void Subscription<TAggregate, T, TH>()
            where TAggregate : IAggregateRoot
            where T : IBaseEvent<TAggregate>
            where TH : IBaseEventHandler<T, TAggregate>
        {
            SubManeger.AddSubscription<T, TH, TAggregate>();
        }


        public static class EventBusBuilder
        {

        }
    }
}
