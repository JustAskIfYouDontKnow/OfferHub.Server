using Microsoft.Extensions.Logging;
using Offerhub.Database.Offer;
using Offerhub.Database.Supplier;

namespace Offerhub.Database
{
    public class DatabaseContainer : IDatabaseContainer
    {
        public IOfferRepository Offer { get; }
        public ISupplierRepository Supplier { get; }
        public DatabaseContainer(PostgresContext db, ILoggerFactory loggerFactory)
        {
            Supplier = new SupplierRepository(db, loggerFactory);
            Offer = new OfferRepository(db, loggerFactory);
        }
    }
}