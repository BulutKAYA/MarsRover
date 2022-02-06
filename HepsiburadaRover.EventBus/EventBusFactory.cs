using HepsiburadaRover.EventBus.Abstraction;
using HepsiburadaRover.EventBus.Enums;
using HepsiburadaRover.EventBus.SubManegers;

namespace HepsiburadaRover.EventBus
{
    public class EventBusFactory
    {
        public static IEventBus Create(EventBusType eventBusType)
        {
            //Can be use different massege brokers
            switch (eventBusType)
            {
                case EventBusType.BaseEventBus:
                    return new BaseEventBus(new InMemoryEventBusSubscriptionManeger());
                default:
                    return new BaseEventBus(new InMemoryEventBusSubscriptionManeger());
            }
        }
    }
}