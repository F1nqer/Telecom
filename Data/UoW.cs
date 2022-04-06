using Data.Contexts;
using Data.Repos;
using System;

namespace Data
{
    public class UoW : IDisposable
    {
        private TelecomDbContext db;
        private BillsRepository BillRepository;
        private ProviderPrefixesRepository ProviderRepository;

        public BillsRepository Bills
        {
            get
            {
                if (BillRepository == null)
                    BillRepository = new BillsRepository(db);
                return BillRepository;
            }
        }

        public ProviderPrefixesRepository ProviderPrefixes
        {
            get
            {
                if (ProviderRepository == null)
                    ProviderRepository = new ProviderPrefixesRepository(db);
                return ProviderRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public async void SaveAsync()
        {
            await db.SaveChangesAsync();
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