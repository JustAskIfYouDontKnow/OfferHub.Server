using Offerhub.Database.Supplier;

namespace OfferHub.Host.Services.Supplier;

public interface ISupplierService
{
    public Task<List<SupplierModel>> GetPopularitySupplier(int skip, int take);
}