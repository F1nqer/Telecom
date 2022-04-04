using Application.ViewModels;
using Data;
using Data.Contexts;
using Domain.Models;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AltelProviderService : IProviderService
    {
        UoW db;
        public AltelProviderService(TelecomDbContext dbContext)
        {
            db = new UoW(dbContext);
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
            
            return $"Bill with {providerName} Provider is created";
        }
    }
}
