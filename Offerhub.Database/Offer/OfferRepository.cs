using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Offerhub.Database.Offer;

public class OfferRepository : AbstractRepository<OfferModel>, IOfferRepository
{

    public OfferRepository(PostgresContext context, ILoggerFactory loggerFactory) : base(context, loggerFactory) { }


    public async Task<OfferModel> GetOneById(int id)
    {
        var model = await DbModel
            .Include(x=> x.Supplier)
            .Where(x => x.Id == id)
            .FirstOrDefaultAsync();

        if (model is null)
        {
            throw new ArgumentException($"Offer with Id: {id} is not found");
        }

        return model;
    }


    public async Task<OfferModel> CreateOffer(OfferModel offer)
    {
        var result = await CreateModelAsync(offer);
        
        if(offer is null)
        {
            throw new ArgumentException("Offer is not created. Instantiate error");
        }
            
        return result;
    }


    public async Task<List<OfferModel>> OfferList()
    {
        return await DbModel
            .Include(x => x.Supplier)
            .OrderBy(x => x.Id)
            .Skip(0)
            .Take(100)
            .ToListAsync();
    }


    public async Task<List<OfferModel>> SearchOffers(string searchTerm)
    {
        var query = DbModel.Include(o => o.Supplier)
            .Where(o => 
                o.Brand.Equals(searchTerm) || 
                o.Model.Equals(searchTerm) || 
                o.Supplier.Name.Equals(searchTerm))
            .ToListAsync();

        return await query;
    }
}