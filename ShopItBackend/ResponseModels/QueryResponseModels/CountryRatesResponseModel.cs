namespace ShopItBackend.ResponseModels.QueryResponseModels
{
    public class CountryRatesResponseModel
    {
        public string CountryCode { get; set; } = default!;
        public string CountryName { get; set; } = default!;
        public string Currency { get; set; } = default!;
        public double ExchangeRate { get; set; }
    }
}
