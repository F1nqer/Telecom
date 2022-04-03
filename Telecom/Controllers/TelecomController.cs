using Application.Services;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
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
        public ActionResult Payment(Payment payment)
        {
            var service = serviceProvider
                .GetService<IProviderService>
                (_numberService.DetermineProviderName(payment.Number));
            string response = service.AddBalance(payment);
            return Ok(response);
        }
    }
}
