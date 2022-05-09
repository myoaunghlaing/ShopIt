using MediatR;
using ShopItBackend.ResponseModels.QueryResponseModels;

namespace ShopItBackend.RequestModels.QueryRequestModels
{
    public class ShippingChargesRequestModel : IRequest<List<ShippingChargesResponseModel>>
    {
    }
}
