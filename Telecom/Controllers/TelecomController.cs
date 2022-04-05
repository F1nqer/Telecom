using Application.Localization;
using Application.Services;
using Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
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
        private NumberService numberService;
        private readonly IStringLocalizer<SharedResource> sharedResourceLocalizer;
        private readonly ILogger<TelecomController> logger;
        public TelecomController
            (IServiceProvider serviceProvider, NumberService numberService,
            IStringLocalizer<SharedResource> sharedResourceLocalizer,
            ILogger<TelecomController> logger)
        {
            this.serviceProvider = serviceProvider;
            this.numberService = numberService;
            this.sharedResourceLocalizer = sharedResourceLocalizer;
            this.logger = logger;   
        }
        [HttpPost]
        public async Task<ActionResult> Payment(Payment payment, string culture)
        {
            payment.Number = numberService.ValidateNumber(payment.Number);
            var service = serviceProvider
                .GetService<IProviderService>
                (numberService.DetermineProviderName(payment.Number));
            string response = await service.AddBalanceAsync(payment);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture)    
        {
            if (culture == "")
            {
                logger.LogError(sharedResourceLocalizer["NullError"].Value + " in SetLanguage");
                return BadRequest(sharedResourceLocalizer["NullError"].Value);
            }

            try {
                Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions {Expires = DateTimeOffset.UtcNow.AddYears(1)});
                return Ok();
            }

            catch(Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
