using Moq;
using NUnit.Framework;
using ShopItBackend.Data;
using ShopItBackend.Handlers.QueryHandlers;
using ShopItBackend.RequestModels.QueryRequestModels;
using ShopItBackend.ResponseModels.QueryResponseModels;
using Shouldly;
using System.Threading;

namespace ShopItTest
{
    public class CountryRatesQueryHandlerTest
    {
        private Mock<IShopItDBContext> mockRepo;
        [SetUp]
        public void Setup()
        {
            mockRepo = MoqShopItRepository.GetShopItRepository();
        }

        [Test]       
        public void TestGetCountryRates()
        {
            var handler = new CountryRatesQueryHandler(mockRepo.Object);
            var result = handler.Handle(new CountryRatesRequestModel(), CancellationToken.None);
            result.Result.Count.ShouldBe(3);
        }
    }
}