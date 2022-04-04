using Application.Services;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;
using Telecom.Extensions;

namespace Telecom.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class TelecomController : ControllerBase
    {
        private readonly IServiceProvider serviceProvider;
        private NumberService _numberService;
        public TelecomController
            (IServiceProvider serviceProvider, NumberService numberService)
        {
            this.serviceProvider = serviceProvider;
            this._numberService = numberService;
        }
        [HttpPost]
        public async Task<ActionResult> Payment(Payment payment)
        {
            var service = serviceProvider
                .GetService<IProviderService>
                (_numberService.DetermineProviderName(payment.Number));
            string response = await service.AddBalanceAsync(payment);
            return Ok(response);
        }
    }
}
