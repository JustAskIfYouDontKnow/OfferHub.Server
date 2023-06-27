using Microsoft.Extensions.Logging;

namespace Offerhub.Database.Supplier;

public class SupplierRepository : AbstractRepository<SupplierModel>, ISupplierRepository
{
    public SupplierRepository(PostgresContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory) { }
    
    
    
}