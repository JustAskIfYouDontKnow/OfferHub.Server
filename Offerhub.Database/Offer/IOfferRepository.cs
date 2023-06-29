namespace Offerhub.Database.Offer;

public interface IOfferRepository
{
    public Task<OfferModel> GetOneById(int id);
    
    public Task<OfferModel> CreateOffer(OfferModel offer);
    
    public Task<List<OfferModel>> OfferList();
    
    public Task<List<OfferModel>> SearchOffers(string searchTerm);
}