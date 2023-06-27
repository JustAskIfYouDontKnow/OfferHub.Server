using Offerhub.Database.Offer;
using Offerhub.Database.Supplier;

namespace Offerhub.Database
{
    public interface IDatabaseContainer
    {
        IOfferRepository Offer { get; }
        ISupplierRepository Supplier { get; }
    }
}
