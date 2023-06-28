using Offerhub.Database;
using Offerhub.Database.Offer;

namespace OfferHub.Host.Services.Offer;

public class OfferService : IOfferService
{
    private readonly IDatabaseContainer _databaseContainer;

    public OfferService(IDatabaseContainer databaseContainer)
    {
        _databaseContainer = databaseContainer;
    }


    public async Task<OfferModel> Create(string brand, string model, int supplierId)
    {
        var supplierModel = await _databaseContainer.Supplier.GetOneById(supplierId);
        var offerModel =  OfferModel.Create(brand, model, supplierModel.Id);
        return await _databaseContainer.Offer.CreateOffer(offerModel);
    }


    public async Task<OfferModel> GetOneById(int id)
    {
        return await _databaseContainer.Offer.GetOneById(id);
    }


    public async Task<List<OfferModel>> OfferList()
    {
        return await _databaseContainer.Offer.OfferList();
    }


    public async Task<List<OfferModel>> SearchOffers(string searchTerm)
    {
        var searchTermToLower = searchTerm.ToLower();
        return await _databaseContainer.Offer.SearchOffers(searchTermToLower);
    }



}