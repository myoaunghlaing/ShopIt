using Moq;
using ShopItBackend.Data;
using ShopItBackend.RequestModels.CommandRequestModels;
using ShopItBackend.ResponseModels.QueryResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopItTest
{
    public static class MoqShopItRepository
    {
        public static Mock<IShopItDBContext> GetShopItRepository()
        {

            var products = new []
            {
                new ProductsResponseModel() { Id = 1, Title = "Brief Answers to the Big Questions", Description = "How did the universe begin? Will humanity survive on Earth? Is there intelligent life beyond our solar system? Could artificial intelligence ever outsmart us?", ImageUrl = "Briefanswers.jpg", PriceOriginal = 15, CurrencyOriginal = "AUD", SellPrice = 15, CurrencyCurrent = "AUD" },
                new ProductsResponseModel() { Id = 2, Title = "Will", Description = "One of the most dynamic and globally recognised entertainment forces of our time opens up fully about his life, in a brave and inspiring book that traces his learning curve to a place where outer success, inner happiness and human connection are aligned", ImageUrl = "Will.jpg", PriceOriginal = 15, CurrencyOriginal = "AUD", SellPrice = 15, CurrencyCurrent = "AUD"},
                new ProductsResponseModel() { Id = 3, Title = "How to Prevent the Next Pandemic", Description = "Before Bill Gates became an expert on climate science, he was known as one of the few who studied pandemics—how they start, how they spread, how they can be controlled. He warned us years ago in a now-famous TED Talk of their arrival in our future. The future, of course, is now, and now is when we have to plan against a next one.", ImageUrl = "Pandemic.jpg",PriceOriginal = 15, CurrencyOriginal = "AUD", SellPrice = 15, CurrencyCurrent = "AUD" },
                new ProductsResponseModel() { Id = 4, Title = "The Code Breaker", Description = "The best-selling author of Leonardo da Vinci and Steve Jobs returns with a gripping account of how the pioneering scientist Jennifer Doudna, along with her colleagues and rivals, launched a revolution that will allow us to cure diseases, fend off viruses, and enhance our children.", ImageUrl = "CodeBreaker.jpg", PriceOriginal = 15, CurrencyOriginal = "AUD", SellPrice = 15, CurrencyCurrent = "AUD" },
                new ProductsResponseModel() { Id = 5, Title = "A Promised Land", Description = "Join Barack Obama himself as he recounts his journey into politics and presidency in this enchanting audiobook that offers an intimate look at the life of one of the 21st century's most influential leaders.", ImageUrl = "Promisedland.jpg", PriceOriginal = 15, CurrencyOriginal = "AUD", SellPrice = 15, CurrencyCurrent = "AUD" }
            };

            var countryRates = new []
            {
                new CountryRatesResponseModel() { CountryCode = "AU", CountryName = "Australia", Currency = "AUD", ExchangeRate = 1 },
                new CountryRatesResponseModel() { CountryCode = "USA", CountryName = "United States", Currency = "USD", ExchangeRate = 0.71 },
                new CountryRatesResponseModel() { CountryCode = "UK", CountryName = "United Kingdom", Currency = "GBP", ExchangeRate = 0.58 },
            };

            var shippingCharges = new []
            {
                new ShippingChargesResponseModel() { Id = 1, threshold = 1, amount = 10 },
                new ShippingChargesResponseModel() { Id = 2, threshold = 50, amount = 20 },
            };

            var mockRepo = new Mock<IShopItDBContext>();

            mockRepo.Setup(rep => rep.GetProducts()).Returns(products);
            mockRepo.Setup(rep => rep.GetCountryRates()).Returns(countryRates);
            mockRepo.Setup(rep => rep.GetShippingCharges()).Returns(shippingCharges);
            mockRepo.Setup(rep => rep.CreateOrder(It.IsAny<CreateOrderRequestModel>())).Returns((CreateOrderRequestModel order) => 
            {
                if (order.OrderItems != null && order.OrderItems.Length > 0 && order.OrderItems[0].ProductId > 0)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            });

            return mockRepo;
        }
    }
}
