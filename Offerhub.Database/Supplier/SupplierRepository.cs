using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Offerhub.Database.Supplier;

public class SupplierRepository : AbstractRepository<SupplierModel>, ISupplierRepository
{
    public SupplierRepository(PostgresContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory) { }

    
    public async Task<SupplierModel> GetOneById(int id)
    {
        var model = await DbModel
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

        if (model is null)
        {
            throw new ArgumentException($"Supplier with Id: {id} is not found");
        }

        return model;
    }


    public async Task<SupplierModel> CreateSupplier(SupplierModel supplier)
    {
        var result = await CreateModelAsync(supplier);
        
        if(supplier is null)
        {
            throw new ArgumentException("Supplier is not created. Instantiate error");
        }
            
        return result;
    }
    

    public async Task<List<SupplierModel>> SupplierList(int skip, int take)
    {
        return await DbModel
            .Include(x => x.Offers)
            .OrderBy(x => x.Id)
            .Skip(skip)
            .Take(take)
            .ToListAsync();
    }
}