using Offerhub.Database.Offer;

namespace OfferHub.Host.Services.Offer;

public class OfferService : IOfferService
{

    public Task<OfferModel> GetOneByBrand(string brandName)
    {
        throw new NotImplementedException();
    }


    public Task<OfferModel> GetOneByModel(string modelName)
    {
        throw new NotImplementedException();
    }


    public Task<OfferModel> GetOneBySupplier(int supplierId)
    {
        throw new NotImplementedException();
    }
}