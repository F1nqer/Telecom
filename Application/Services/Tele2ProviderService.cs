using Application.ViewModels;
using Data;
using Data.Contexts;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            Bill bill = new Bill();
            bill.Sum = payment.Sum;
            bill.Number = payment.Number;
            bill.ProviderId = db.Providers.GetByName("Tele2").Id;
            bill.Provider = db.Providers.GetByName("Tele2");
            db.Bills.Create(bill);
            return "Bill with Tele2 Provider is created";
        }
    }
}
