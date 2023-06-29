namespace Offerhub.Database.Supplier;

public interface ISupplierRepository
{
    public Task<SupplierModel> GetOneById(int id);
    
    public Task<SupplierModel> CreateSupplier(SupplierModel supplier);
    
    public Task<List<SupplierModel>> SupplierList(int skip, int take);
}