using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Offerhub.Database.Offer;
using Offerhub.Database.Supplier;

namespace Offerhub.Database
{
    public class PostgresContext : DbContext
    {
        public readonly DatabaseContainer Db;
        
        public DbSet<OfferModel> Offer { get; set; }
        public DbSet<SupplierModel> Supplier { get; set; }
        
        
        public PostgresContext(DbContextOptions<PostgresContext> options, ILoggerFactory loggerFactory) : base(options)
        {
            Db = new DatabaseContainer(this, loggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OfferModel>()
                .Property(o => o.Id)
                .UseIdentityAlwaysColumn();

            modelBuilder.Entity<SupplierModel>()
                .Property(s => s.Id)
                .UseIdentityAlwaysColumn();
            
            modelBuilder.Entity<OfferModel>()
                .HasOne(o => o.Supplier)
                .WithMany(s => s.Offers)
                .HasForeignKey(o => o.SupplierId);
        }
    }
}
