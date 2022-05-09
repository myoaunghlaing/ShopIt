using MediatR;
using ShopItBackend.Data;
using ShopItBackend.RequestModels.CommandRequestModels;

namespace ShopItBackend.Handlers.CommandHandlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderRequestModel, int>
    {
        private readonly IShopItDBContext shopItDbContext;

        public CreateOrderCommandHandler(IShopItDBContext shopItDBContext)
        {
            this.shopItDbContext = shopItDBContext;
        }
        public async Task<int> Handle(CreateOrderRequestModel request, CancellationToken cancellationToken)
        {    
            return await Task.Run(() => shopItDbContext.CreateOrder(request));           
        }
    }
}
