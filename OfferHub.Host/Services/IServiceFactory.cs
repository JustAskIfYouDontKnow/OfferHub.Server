using OfferHub.Host.Services.Offer;
using OfferHub.Host.Services.Supplier;

namespace OfferHub.Host.Services;

public interface IServiceFactory
{
    IOfferService OfferService { get; }
    
    ISupplierService SupplierService { get; }
}