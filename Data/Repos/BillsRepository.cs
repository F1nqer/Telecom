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
    public class BillsRepository: IRepository<Bill>
    {
        private TelecomDbContext dbContext;
        public BillsRepository(TelecomDbContext context)
        {
            dbContext = context;
        }
        public IQueryable<Bill> GetAll()
        {
            return dbContext.Bills
                .Include(b => b.Provider);
        }
        public Bill GetById(int id)
        {
            return dbContext.Bills
                .Include(b => b.Provider)
                .FirstOrDefault(b => b.Id == id);
        }
        public void Create(Bill item)
        {
            dbContext.Bills
                .Add(item);
        }
        public void Update(Bill item)
        {
            dbContext.Bills
                .Update(item);
        }
        public void DeleteById(int id)
        {
            var bill = dbContext.Bills
                .Find(id);
            if (bill != null)
                dbContext.Bills
                    .Remove(bill);
        }
        public void Save()
        {
            dbContext.SaveChanges();
        }
    }
}
