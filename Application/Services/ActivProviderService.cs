using Application.Localization;
using Application.ViewModels;
using Data;
using Data.Contexts;
using Domain.Models;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ActivProviderService : IProviderService
    {
        private UoW db;
        private readonly IStringLocalizer<SharedResource> sharedResourceLocalizer;
        private readonly ILogger<ActivProviderService> logger;

        public ActivProviderService(TelecomDbContext dbContext,
            IStringLocalizer<SharedResource> sharedResourceLocalizer,
            ILogger<ActivProviderService> logger)
        {
            db = new UoW(dbContext);
            this.sharedResourceLocalizer = sharedResourceLocalizer;
            this.logger = logger;
        }

        public string AddBalance(Payment payment)
        {
            var provider = db.ProviderPrefixes.GetPrefixByName("Activ").Provider;
            var bill = new Bill
            {
                Sum = payment.Sum,
                Number = payment.Number,
                Provider = provider,
                ProviderId = provider.Id
            };
            db.Bills.Create(bill);
            db.Save();
            return "Bill with Activ Provider is created";
        }

        public async Task<string> AddBalanceAsync(Payment payment)
        {
            var providerName = "Activ";
            var provider = await db.ProviderPrefixes.GetPrefixByNameAsync(providerName);
            var bill = new Bill
            {
                Sum = payment.Sum,
                Number = payment.Number,
                Provider = provider.Provider,
                ProviderId = provider.Id
            };
            db.Bills.CreateAsync(bill);
            db.Save();
            string message = sharedResourceLocalizer["Ok"] + $" Bill with {providerName} Provider is created";
            logger.LogInformation(message);
            return message;
        }
    }
}