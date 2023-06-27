using Offerhub.Database.Offer;

namespace OfferHub.Host.Services.Offer;

public interface IOfferService
{
    public Task<OfferModel> GetOneByBrand(string brandName);
    public Task<OfferModel> GetOneByModel(string modelName);
    public Task<OfferModel> GetOneBySupplier(int supplierId);
}