using Data.Contexts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repos
{
    public class ProvidersRepository : IRepository<Provider>
    {
        private TelecomDbContext dbContext;
        public ProvidersRepository(TelecomDbContext context)
        {
            dbContext = context;
        }
        public IQueryable<Provider> GetAll()
        {
            return dbContext.Providers
                .Include(p => p.ProviderPrefixes);
        }
        public Provider GetById(int id)
        {
            return dbContext.Providers
                .Include(p => p.ProviderPrefixes)
                .FirstOrDefault(p => p.Id == id);
        }
        public Provider GetByName(string name)
        {
            return dbContext.Providers
                .Include(p => p.ProviderPrefixes)
                .FirstOrDefault(p => p.Name == name);
        }
        public void Create(Provider item)
        {
            dbContext.Providers
                .Add(item);
        }
        public void Update(Provider item)
        {
            dbContext.Providers
                .Update(item);
        }
        public void DeleteById(int id)
        {
            var provider = dbContext.Providers
                .Find(id);
            if (provider != null)
                dbContext.Providers
                    .Remove(provider);
        }
        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
