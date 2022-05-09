using Moq;
using NUnit.Framework;
using ShopItBackend.Data;
using ShopItBackend.Handlers.CommandHandlers;
using ShopItBackend.RequestModels.CommandRequestModels;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ShopItTest
{
    internal class CreateOrderCommandHandlerTest
    {
        private Mock<IShopItDBContext> mockRepo;
        private CreateOrderRequestModel requestModel;

        [SetUp]
        public void Setup()
        {
            mockRepo = MoqShopItRepository.GetShopItRepository();

            requestModel = new CreateOrderRequestModel();
            var item = new OrderItem() { ProductId = 1, Count = 2};
            requestModel.OrderItems = new OrderItem[1];
            requestModel.OrderItems[0] = item;
            requestModel.Name = "Jones";
            requestModel.Address = "No. 1";
            requestModel.Country = "Australia";
        }

        [Test]
        public void TestCreateOrder()
        {
            var handler = new CreateOrderCommandHandler(mockRepo.Object);
            var result = handler.Handle(requestModel, CancellationToken.None);
            result.Result.ShouldBeOfType<int>();
            result.Result.ShouldBe(1);
        }
    }
}
