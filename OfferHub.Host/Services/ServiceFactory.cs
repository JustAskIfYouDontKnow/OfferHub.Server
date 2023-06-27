using OfferHub.Host.Services.Offer;
using OfferHub.Host.Services.Supplier;

namespace OfferHub.Host.Services;

public class ServiceFactory : IServiceFactory
{
    public IOfferService OfferService { get; set; }

    public ISupplierService SupplierService { get; set; }
    
    
    public ServiceFactory(
        IOfferService offerService,
        ISupplierService supplierService)
    {
        OfferService = offerService;
        SupplierService = supplierService;
    }
}