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
    public class ActivProviderService : IProviderService
    {
        UoW db;
        public ActivProviderService(TelecomDbContext dbContext)
        {
            db = new UoW(dbContext);
        }
        public string AddBalance(Payment payment)
        {
            Bill bill = new Bill();
            bill.Sum = payment.Sum;
            bill.Number = payment.Number;
            bill.ProviderId = db.Providers.GetByName("Activ").Id;
            bill.Provider = db.Providers.GetByName("Activ");
            db.Bills.Create(bill);
            return "Bill with Activ Provider is created";
        }
    }
}
