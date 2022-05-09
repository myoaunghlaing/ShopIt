using MediatR;
using ShopItBackend.Data;
using ShopItBackend.RequestModels.QueryRequestModels;
using ShopItBackend.ResponseModels.QueryResponseModels;

namespace ShopItBackend.Handlers.QueryHandlers
{
    public class ProductsQueryHandler : IRequestHandler<ProductsRequestModel, List<ProductsResponseModel>>
    {
        private readonly IShopItDBContext shopItDbContext;

        public ProductsQueryHandler(IShopItDBContext shopItDBContext)
        {
            this.shopItDbContext = shopItDBContext;
        }
        public async Task<List<ProductsResponseModel>> Handle(ProductsRequestModel request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => shopItDbContext.GetProducts().ToList());
        }
    }
}
