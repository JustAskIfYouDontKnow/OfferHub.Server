using Offerhub.Database;
using Offerhub.Database.Supplier;

namespace OfferHub.Host.Services.Supplier;

public class SupplierService : ISupplierService
{
    private readonly IDatabaseContainer _databaseContainer;

    public SupplierService(IDatabaseContainer databaseContainer)
    {
        _databaseContainer = databaseContainer;
    }

    public async Task<SupplierModel> Create(string name)
    {
       var supplierModel = SupplierModel.Create(name, DateTime.Now);
       
       return await _databaseContainer.Supplier.CreateSupplier(supplierModel);
    }

    public async Task<List<SupplierModel>> SupplierList(int skip, int take)
    {
        return await _databaseContainer.Supplier.SupplierList(skip, take);
    }
}