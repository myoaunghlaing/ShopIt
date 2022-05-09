using MediatR;
using ShopItBackend.ResponseModels.QueryResponseModels;

namespace ShopItBackend.RequestModels.QueryRequestModels
{
    public class CountryRatesRequestModel : IRequest<List<CountryRatesResponseModel>>
    {
    }
}
