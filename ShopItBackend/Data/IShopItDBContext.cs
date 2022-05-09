using ShopItBackend.RequestModels.CommandRequestModels;
using ShopItBackend.ResponseModels.QueryResponseModels;

namespace ShopItBackend.Data
{
    public interface IShopItDBContext
    {
        ProductsResponseModel[] GetProducts();
        CountryRatesResponseModel[] GetCountryRates();
        ShippingChargesResponseModel[] GetShippingCharges();
        int CreateOrder(CreateOrderRequestModel order);
    }
}
