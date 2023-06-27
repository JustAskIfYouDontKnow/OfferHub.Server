using Microsoft.Extensions.Logging;

namespace Offerhub.Database.Offer;

public class OfferRepository : AbstractRepository<OfferModel>, IOfferRepository
{

    public OfferRepository(PostgresContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory) { }
    
    
}