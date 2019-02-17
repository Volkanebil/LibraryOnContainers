using EventBus.Events;

namespace Shipment.API.IntegrationEvents.Events
{
    public class PaymentConfirmedEvent : IntegrationEvent
    {
        public int OrderId { get; }

        public PaymentConfirmedEvent(int orderId)
            => OrderId = orderId;
    }
}
