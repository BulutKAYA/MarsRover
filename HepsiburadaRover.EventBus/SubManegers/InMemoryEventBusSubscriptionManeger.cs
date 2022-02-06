using HepsiburadaRover.EventBus.Abstraction;
using HepsiburadaRover.EventBus.Events;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HepsiburadaRover.EventBus.SubManegers
{
    public class InMemoryEventBusSubscriptionManeger : IEventBusSubscriptionManeger
    {
        private readonly Dictionary<string, List<SubscriptionInfo>> _subscribers;
        private readonly List<Type> _eventTypes;

        public InMemoryEventBusSubscriptionManeger()
        {
            _subscribers = new Dictionary<string, List<SubscriptionInfo>>();
            _eventTypes = new List<Type>();
        }

        public bool HasSubscriptionsForEvent(string eventName) => _subscribers.ContainsKey(eventName);

        public void AddSubscription<T, TH, TAggregate>()
                    where TAggregate : IAggregateRoot
                    where T : IBaseEvent<TAggregate>
                    where TH : IBaseEventHandler<T, TAggregate>
        {
            var eventName = GetEventKey<T>();

            AddSubscription(typeof(TH), eventName);

            if (!_eventTypes.Contains(typeof(T)))
                _eventTypes.Add(typeof(T));
        }

        public string GetEventKey<T>()
        {
            return typeof(T).Name;
        }

        private void AddSubscription(Type handlerType, string eventName)
        {
            if (!HasSubscriptionsForEvent(eventName))
            {
                _subscribers.Add(eventName, new List<SubscriptionInfo>());
            }

            if (_subscribers[eventName].Any(x => x.HandlerType == handlerType))
            {
                throw new ArgumentException($"Handler Type {handlerType.Name} already registered for '{eventName}'", nameof(handlerType));
            }
            _subscribers[eventName].Add(SubscriptionInfo.Typed(handlerType));

        }

        public IEnumerable<SubscriptionInfo> GetSubscribersForEvent(string eventName) => _subscribers[eventName];
    }
}
