namespace ShopItBackend.ResponseModels.QueryResponseModels
{
    public class ProductsResponseModel
    {
        public long Id { get; set; }
        public string Title { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string ImageUrl { get; set; } = default!;
        public double PriceOriginal { get; set; }
        public string CurrencyOriginal { get; set; } = default!;
        public double SellPrice { get; set; }
        public string CurrencyCurrent { get; set; } = default!;

    }
}
