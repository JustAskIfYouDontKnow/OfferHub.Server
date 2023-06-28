using Offerhub.Database.Supplier;

namespace OfferHub.Host.Services.Supplier;

public interface ISupplierService
{
    public Task<SupplierModel> Create(string name);
    public Task<List<SupplierModel>> SupplierList(int skip, int take);
}