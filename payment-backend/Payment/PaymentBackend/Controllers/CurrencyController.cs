using Microsoft.AspNetCore.Mvc;
using PaymentBackend.Services.Interfaces;

namespace PaymentBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController: ControllerBase
    {
        private readonly ICurrencyService _currencyService;

        public CurrencyController(ICurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            return Ok(_currencyService.GetAll());
        }
    }
}
