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
    public class BeelineProviderService : IProviderService
    {
        UoW db;
        public BeelineProviderService(TelecomDbContext dbContext)
        {
            db = new UoW(dbContext);
        }
        public string AddBalance(Payment payment)
        {
            Bill bill = new Bill();
            bill.Sum = payment.Sum;
            bill.Number = payment.Number;
            bill.ProviderId = db.Providers.GetByName("Beeline").Id;
            bill.Provider = db.Providers.GetByName("Beeline");
            db.Bills.Create(bill);
            return "Bill with Beeline Provider is created";
        }
    }
}
