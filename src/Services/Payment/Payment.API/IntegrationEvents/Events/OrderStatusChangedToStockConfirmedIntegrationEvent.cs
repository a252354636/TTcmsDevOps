namespace Payment.API.IntegrationEvents.Events
{
    using TTcms.BuildingBlocks.EventBus.Events;

    public record OrderStatusChangedToStockConfirmedIntegrationEvent : IntegrationEvent
    {
        public int OrderId { get; }

        public OrderStatusChangedToStockConfirmedIntegrationEvent(int orderId)
            => OrderId = orderId;
    }
}