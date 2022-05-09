using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopItBackend.RequestModels.QueryRequestModels;

namespace ShopItBackend.Controllers
{    
    [ApiController]
    [Route("[controller]")]
    public class CountryRateController : ControllerBase
    {
        private readonly IMediator mediator;
        public CountryRateController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("countryrates")]
        public async Task<IActionResult> GetCountryRates()
        {
            var result = await mediator.Send(new CountryRatesRequestModel());
            return Ok(result);
        }

        [HttpGet]
        [Route("shippingcharges")]
        public async Task<IActionResult> GetShippingCharges()
        {
            var result = await mediator.Send(new ShippingChargesRequestModel());
            return Ok(result);
        }
    }
}
