namespace Ordering.API.Application.IntegrationEvents.Events
{
    using TTcms.BuildingBlocks.EventBus.Events;

    public record OrderPaymentFailedIntegrationEvent : IntegrationEvent
    {
        public int OrderId { get; }

        public OrderPaymentFailedIntegrationEvent(int orderId) => OrderId = orderId;
    }
}