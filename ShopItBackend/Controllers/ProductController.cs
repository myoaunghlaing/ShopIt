using MediatR;
using Microsoft.AspNetCore.Mvc;
using ShopItBackend.RequestModels.QueryRequestModels;

namespace ShopItBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController :  ControllerBase
    {
        private readonly IMediator mediator;
        public ProductController(IMediator mediator)
        {            
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("products")]
        public async Task<IActionResult> GetAllProducts()
        {            
            var result = await mediator.Send(new ProductsRequestModel());
            return Ok(result);
        }
    }
}
