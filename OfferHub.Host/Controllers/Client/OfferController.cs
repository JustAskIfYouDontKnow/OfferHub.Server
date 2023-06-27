using OfferHub.Host.Services;

namespace OfferHub.Host.Controllers.Client;

public class OfferController : AbstractClientController
{
    public OfferController(IServiceFactory serviceFactory) : base(serviceFactory) { }
    
    
}
