using Application.Services;
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
        public TelecomController(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }
        [HttpPost]
        public ActionResult Payment()
        {
            var service = serviceProvider.GetService<IProviderService>("Activ");
            return Ok();
        }
    }
}
