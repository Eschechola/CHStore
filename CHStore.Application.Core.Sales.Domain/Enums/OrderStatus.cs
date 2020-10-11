namespace CHStore.Application.Sales.Domain.Enums
{
    public enum OrderStatus
    {
        OrderRealized = 1,
        AwaitingPayment = 2,
        PaymentConfirmed = 3,
        SortingOutOrder = 4,
        InvoiceIssued = 5,
        SentToCarrier = 6,
        CollectedByTheCarrier = 7,
        Transit = 8,
        DeliveryRoute = 9,
        Fineshed = 10
    }
}
