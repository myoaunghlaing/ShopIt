using MediatR;
using ShopItBackend.Data;
using ShopItBackend.RequestModels.QueryRequestModels;
using ShopItBackend.ResponseModels.QueryResponseModels;

namespace ShopItBackend.Handlers.QueryHandlers
{
    public class CountryRatesQueryHandler: IRequestHandler<CountryRatesRequestModel, List<CountryRatesResponseModel>>
    {
        private readonly IShopItDBContext shopItDbContext;

        public CountryRatesQueryHandler(IShopItDBContext shopItDBContext)
        {
            this.shopItDbContext = shopItDBContext;
        }
        public async Task<List<CountryRatesResponseModel>> Handle(CountryRatesRequestModel request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => shopItDbContext.GetCountryRates().ToList());
        }
    }
}
