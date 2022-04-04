using Data.Contexts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Repos
{
    public class ProviderPrefixesRepository : IRepository<ProviderPrefix>
    {
        private TelecomDbContext dbContext;
        public ProviderPrefixesRepository(TelecomDbContext context)
        {
            dbContext = context;
        }
        public IQueryable<ProviderPrefix> GetAll()
        {
            return dbContext.ProvidersPrefix
                .Include(p => p.Provider);
        }
        public ProviderPrefix GetById(int id)
        {
            return dbContext.ProvidersPrefix
                .Include(p => p.Provider)
                .FirstOrDefault(p => p.Id == id);
        }
        public ProviderPrefix GetPrefixByName(string name)
        {
            return dbContext.ProvidersPrefix
                .Include(p => p.Provider)
                .Where(p => p.Provider.Name == name)
                .FirstOrDefault();
        }

        public async Task<ProviderPrefix> GetPrefixByNameAsync(string name)
        {
            return await dbContext.ProvidersPrefix
                .Include(p => p.Provider)
                .FirstOrDefaultAsync(p => p.Provider.Name == name);
        }
        public void Create(ProviderPrefix item)
        {
            dbContext.ProvidersPrefix
                .Add(item);
        }
        public void Update(ProviderPrefix item)
        {
            dbContext.ProvidersPrefix
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
