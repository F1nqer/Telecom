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
    public class NumberService
    {
        UoW db;
        public NumberService(TelecomDbContext dbContext)
        {
            db = new UoW(dbContext);
        }

        public string DetermineProviderName(string number)
        {
            int prefix = Convert.ToInt32(number.Substring(2,3));
            List<Provider> providersWithPrefixes = db.Providers.GetAll().ToList();
            string providerName = providersWithPrefixes
                .FirstOrDefault(p => p.ProviderPrefixes
                                    .Where(pp => pp.Prefix == prefix)
                                    .First().Prefix == prefix)
                .Name;
            return providerName;
        }
    }
}
