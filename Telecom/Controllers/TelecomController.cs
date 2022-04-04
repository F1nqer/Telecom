using Application.Localization;
using Application.Services;
using Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
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
        public TelecomController
            (IServiceProvider serviceProvider, NumberService numberService,
            IStringLocalizer<SharedResource> sharedResourceLocalizer)
        {
            this.serviceProvider = serviceProvider;
            this.numberService = numberService;
            this.sharedResourceLocalizer = sharedResourceLocalizer;
        }
        [HttpPost]
        public async Task<ActionResult> Payment(Payment payment)
        {
            if (payment.Number == "" || payment.Sum < 0)
                return BadRequest(sharedResourceLocalizer["NullError"].Value);

            var service = serviceProvider
                .GetService<IProviderService>
                (numberService.DetermineProviderName(payment.GetNumber(sharedResourceLocalizer)));
            string response = await service.AddBalanceAsync(payment);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture)
        {
            if (culture == "")
                return BadRequest(sharedResourceLocalizer["NullError"].Value);

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
