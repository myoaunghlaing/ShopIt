using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopItBackend.RequestModels.CommandRequestModels;

namespace ShopItBackend.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMediator mediator;
        public OrderController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateOrder(CreateOrderRequestModel requestModel)
        {            
            var result = await mediator.Send(requestModel);
            return Ok(result);
        }
    }
}
