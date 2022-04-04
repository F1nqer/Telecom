using Application.ViewModels;
using Data;
using Data.Contexts;
using Domain.Models;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ActivProviderService : IProviderService
    {
        UoW db;
        public ActivProviderService(TelecomDbContext dbContext)
        {
            db = new UoW(dbContext);
        }
        public string AddBalance(Payment payment)
        {
            var provider = db.ProviderPrefixes.GetPrefixByName("Activ").Provider;
            var bill = new Bill 
                {Sum = payment.Sum,
                Number = payment.Number,
                Provider = provider,
                ProviderId = provider.Id};
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

            return $"Bill with {providerName} Provider is created";
        }
    }
}
