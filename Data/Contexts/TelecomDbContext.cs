using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Contexts
{
    public class TelecomDbContext : DbContext
    {
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<ProviderPrefix> ProvidersPrefix { get; set; }
      /*  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Telecom;Trusted_Connection=True;");
        }*/
        public TelecomDbContext(DbContextOptions<TelecomDbContext> options)
           : base(options)
        {

        }
    }
}
