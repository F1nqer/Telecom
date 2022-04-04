using Application.Localization;
using Application.ViewModels;
using Data;
using Data.Contexts;
using Domain.Models;
using Microsoft.Extensions.Localization;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AltelProviderService : IProviderService
    {
        UoW db;
        private readonly IStringLocalizer<SharedResource> sharedResourceLocalizer;

        public AltelProviderService(TelecomDbContext dbContext, IStringLocalizer<SharedResource> sharedResourceLocalizer)
        {
            db = new UoW(dbContext);
            this.sharedResourceLocalizer = sharedResourceLocalizer;
        }

        public string AddBalance(Payment payment)
        {
            var provider = db.ProviderPrefixes.GetPrefixByName("Altel").Provider;
            var bill = new Bill
            {
                Sum = payment.Sum,
                Number = payment.Number,
                Provider = provider,
                ProviderId = provider.Id
            };  
            db.Bills.Create(bill);
            db.Save();
            return "Bill with Altel Provider is created";
        }

        public async Task<string> AddBalanceAsync(Payment payment)
        {
            var providerName = "Altel";
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
            
            return sharedResourceLocalizer["Ok"] + $" Bill with {providerName} Provider is created";
        }
    }
}
