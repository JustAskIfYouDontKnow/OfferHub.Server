using OfferHub.Host.Services;

namespace OfferHub.Host.Controllers.Client;

public class SupplierController : AbstractClientController
{
    public SupplierController(IServiceFactory serviceFactory) : base(serviceFactory) { }
    
    
}