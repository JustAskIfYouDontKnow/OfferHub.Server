using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfferHub.Host.Services;

namespace OfferHub.Host.Controllers;

[ApiController]
[AllowAnonymous]
[ApiExplorerSettings(GroupName = "v1")]
[Produces("application/json")]
[Route("api/[controller]/[action]")]
public abstract class AbstractClientController : ControllerBase
{
    protected readonly IServiceFactory ServiceFactory;

    protected AbstractClientController(IServiceFactory serviceFactory)
    {
        ServiceFactory = serviceFactory;
    }
}