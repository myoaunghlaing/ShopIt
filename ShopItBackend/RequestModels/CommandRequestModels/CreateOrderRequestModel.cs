using MediatR;

namespace ShopItBackend.RequestModels.CommandRequestModels
{
    public class CreateOrderRequestModel : IRequest<int>
    {
        public OrderItem[] OrderItems { get; set; } = new OrderItem[0];
        public string Name { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string Country { get; set; } = default!;        
    }

    public class OrderItem
    {
        public int ProductId { get; set; }
        public int Count { get; set; }
    }
}
