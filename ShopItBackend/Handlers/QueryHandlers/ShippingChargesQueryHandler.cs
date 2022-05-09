using MediatR;
using ShopItBackend.Data;
using ShopItBackend.RequestModels.QueryRequestModels;
using ShopItBackend.ResponseModels.QueryResponseModels;

namespace ShopItBackend.Handlers.QueryHandlers
{
    public class ShippingChargesQueryHandler : IRequestHandler<ShippingChargesRequestModel, List<ShippingChargesResponseModel>>
    {
        private readonly IShopItDBContext shopItDbContext;

        public ShippingChargesQueryHandler(IShopItDBContext shopItDBContext)
        {
            this.shopItDbContext = shopItDBContext;
        }
        public async Task<List<ShippingChargesResponseModel>> Handle(ShippingChargesRequestModel request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => shopItDbContext.GetShippingCharges().ToList());
        }
    }
}
