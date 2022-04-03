using Data;
using Data.Contexts;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class NumberService
    {
        UoW db;
        public NumberService(TelecomDbContext dbContext)
        {
            db = new UoW(dbContext);
        }

        public string DetermineProviderName(string number)
        {
            int prefix = Convert.ToInt32(number.Substring(2, 4));
            List<ProviderPrefix> providersWithPrefixes = db.ProviderPrefixes.GetAll().ToList();
            string providerName = providersWithPrefixes
                .Where(p => p.Prefix == prefix)
                .FirstOrDefault()
                .Provider
                .Name;
            return providerName;
        }
    }
}
