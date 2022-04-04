using Application.Localization;
using Data;
using Data.Contexts;
using Domain.Models;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class NumberService
    {
        UoW db;
        private readonly IStringLocalizer<SharedResource> sharedResourceLocalizer;

        public NumberService(TelecomDbContext dbContext, IStringLocalizer<SharedResource> sharedResourceLocalizer)
        {
            db = new UoW(dbContext);
            this.sharedResourceLocalizer = sharedResourceLocalizer;
        }

        public string DetermineProviderName(string number)
        {
            int prefix = Convert.ToInt32(number.Substring(2, 3));
            try
            {
                ProviderPrefix providerPrefix = db.ProviderPrefixes
                    .GetAll()
                    .FirstOrDefault(p => p.Prefix == prefix) ?? throw new Exception(sharedResourceLocalizer["PrefixNotFound"].Value);
                string providerName = providerPrefix.Provider.Name;
                return providerName;
            }
            catch(NullReferenceException ex)
            {
                throw new Exception(sharedResourceLocalizer["NullError"].Value + ex.Message);
            }
        }
    }
}
