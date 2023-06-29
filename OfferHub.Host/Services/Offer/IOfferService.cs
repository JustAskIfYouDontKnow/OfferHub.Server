using Offerhub.Database.Offer;

namespace OfferHub.Host.Services.Offer;

public interface IOfferService
{
    public Task<OfferModel> Create(string brand, string model, int supplierId);
    
    public Task<OfferModel> GetOneById(int id);
    
    public Task<List<OfferModel>> OfferList();
    
    public Task<List<OfferModel>> SearchOffers(string searchTerm);
}