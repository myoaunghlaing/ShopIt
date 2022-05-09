using MediatR;
using ShopItBackend.ResponseModels.QueryResponseModels;

namespace ShopItBackend.RequestModels.QueryRequestModels
{
    public class ProductsRequestModel : IRequest<List<ProductsResponseModel>>
    {
    }
}
