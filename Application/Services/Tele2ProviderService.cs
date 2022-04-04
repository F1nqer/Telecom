using Application.ViewModels;
using Data;
using Data.Contexts;
using Domain.Models;
using System.Threading.Tasks;

namespace Application.Services
{
    public class Tele2ProviderService : IProviderService
    {
        UoW db;
        public Tele2ProviderService(TelecomDbContext dbContext)
        {
            db = new UoW(dbContext);
        }
        public string AddBalance(Payment payment)
        {
            var provider = db.ProviderPrefixes.GetPrefixByName("Tele2").Provider;
            var bill = new Bill
            {
                Sum = payment.Sum,
                Number = payment.Number,
                Provider = provider,
                ProviderId = provider.Id
            };
            db.Bills.Create(bill);
            db.Save();
            return "Bill with Tele2 Provider is created";
        }

        public async Task<string> AddBalanceAsync(Payment payment)
        {
            var providerName = "Tele2";
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
            
            return $"Bill with {providerName} Provider is created";
        }
    }
}
