using EventBus.Events;

namespace Shipment.API.IntegrationEvents.Events
{
    public class ShipmentSuccesdedIntegrationEvent : IntegrationEvent
    {
        public int OrderId { get; }

        public ShipmentSuccesdedIntegrationEvent(int orderId) => OrderId = orderId;
    }
}
