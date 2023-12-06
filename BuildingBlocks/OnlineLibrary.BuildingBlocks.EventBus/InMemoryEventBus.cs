﻿using OnlineRentCar.BuildingBlocks.Infrastructure.EventBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRentCar.BuildingBlocks.EventBus
{
    public sealed class InMemoryEventBus
    {
        static InMemoryEventBus()
        {
        }

        private InMemoryEventBus()
        {
            _handlersDictionary = new Dictionary<string, List<IIntegrationEventHandler>>();
        }

        public static InMemoryEventBus Instance { get; } = new InMemoryEventBus();

        private readonly IDictionary<string, List<IIntegrationEventHandler>> _handlersDictionary;

        public void Subscribe<T>(IIntegrationEventHandler<T> handler)
            where T : IntegrationEvent
        {
            var eventType = typeof(T).FullName;
            if (eventType != null)
            {
                if (_handlersDictionary.ContainsKey(eventType))
                {
                    var handlers = _handlersDictionary[eventType];
                    handlers.Add(handler);
                }
                else
                {
                    _handlersDictionary.Add(eventType, new List<IIntegrationEventHandler> { handler });
                }
            }
        }

        public async Task Publish<T>(T @event)
            where T : IntegrationEvent
        {
            var eventType = @event.GetType().FullName;

            if (eventType == null)
            {
                return;
            }

            List<IIntegrationEventHandler> integrationEventHandlers = _handlersDictionary[eventType];

            foreach (var integrationEventHandler in integrationEventHandlers)
            {
                if (integrationEventHandler is IIntegrationEventHandler<T> handler)
                {
                    await handler.Handle(@event);
                }
            }
        }
    }
}
