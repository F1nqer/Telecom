using Application.Localization;
using Data;
using Data.Contexts;
using Domain.Models;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Services
{
    public class NumberService
    {
        UoW db;
        private readonly IStringLocalizer<SharedResource> sharedResourceLocalizer;
        private readonly ILogger<NumberService> logger;

        public NumberService(TelecomDbContext dbContext, 
            IStringLocalizer<SharedResource> sharedResourceLocalizer,
            ILogger<NumberService> logger)
        {
            db = new UoW(dbContext);
            this.sharedResourceLocalizer = sharedResourceLocalizer;
            this.logger = logger;

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
                logger.LogError(sharedResourceLocalizer["PrefixNotFound"].Value, ex);
                throw new Exception(sharedResourceLocalizer["PrefixNotFound"].Value);
            }
        }

        public string ValidateNumber(string Number)
        {
            Number = Number
                    .Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");
            Exception incorrectNumberEx = new Exception(sharedResourceLocalizer["IncorrectNumber"].Value);
            logger.LogError(incorrectNumberEx.Message);
            Number = Number.Length == 12 && Number[0] == '+' ? Number : throw incorrectNumberEx;
            return Number;
        }
    }
}
