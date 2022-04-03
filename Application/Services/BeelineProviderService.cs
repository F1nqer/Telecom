﻿using Application.ViewModels;
using Data;
using Data.Contexts;
using Domain.Models;

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
            bill.ProviderId = db.ProviderPrefixes.GetPrefixByName("Activ").Provider.Id;
            bill.Provider = db.ProviderPrefixes.GetPrefixByName("Activ").Provider;
            db.Bills.Create(bill);
            db.Save();
            return "Bill with Beeline Provider is created";
        }
    }
}
