using EventBus.Events;

namespace Shipment.API.IntegrationEvents.Events
{
    public class ShipmentFailedIntegrationEvent : IntegrationEvent
    {
        public int OrderId { get; }

        public ShipmentFailedIntegrationEvent(int orderId) => OrderId = orderId;
    }
}
