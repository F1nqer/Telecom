using Data.Contexts;
using Data.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class UoW : IDisposable
    {
        private TelecomDbContext db;
        private BillsRepository BillRepository;
        private ProvidersRepository ProviderRepository;

        public BillsRepository Bills
        {
            get
            {
                if (BillRepository == null)
                    BillRepository = new BillsRepository(db);
                return BillRepository;
            }
        }

        public ProvidersRepository Providers
        {
            get
            {
                if (ProviderRepository == null)
                    ProviderRepository = new ProvidersRepository(db);
                return ProviderRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public UoW(TelecomDbContext Context)
        {
            db = Context;
        }
        public UoW()
        {

        }
    }
}