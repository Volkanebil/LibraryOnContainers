using EventBus.Abstractions;
using EventBus.Events;
using Shipment.API.IntegrationEvents.Events;
using System;
using System.Threading.Tasks;

namespace Shipment.API.IntegrationEvents.EventHandling
{
    public class PaymentConfirmedEventHandler :
        IIntegrationEventHandler<PaymentConfirmedEvent>
    {
        private readonly IEventBus _eventBus;

        public PaymentConfirmedEventHandler(IEventBus eventBus)
        {
            _eventBus = eventBus;
        }

        public async Task Handle(PaymentConfirmedEvent @event)
        {
            IntegrationEvent shipmentIntegrationEvent;

            if (GetRandomShipmentStatus())
                shipmentIntegrationEvent = new ShipmentSuccesdedIntegrationEvent(@event.OrderId);
            else
                shipmentIntegrationEvent = new ShipmentFailedIntegrationEvent(@event.OrderId);

            _eventBus.Publish(shipmentIntegrationEvent);

            await Task.CompletedTask;
        }

        //TODO: get from somewhere
        private bool GetRandomShipmentStatus()
        {
            Random gen = new Random();
            int prob = gen.Next(100);
            return prob <= 20;
        }
    }
}
