namespace Ordering.API.Application.IntegrationEvents.Events
{
    using TTcms.BuildingBlocks.EventBus.Events;

    public record OrderPaymentSucceededIntegrationEvent : IntegrationEvent
    {
        public int OrderId { get; }

        public OrderPaymentSucceededIntegrationEvent(int orderId) => OrderId = orderId;
    }
}