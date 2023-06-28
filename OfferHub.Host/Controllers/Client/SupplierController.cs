using Microsoft.AspNetCore.Mvc;
using OfferHub.API.Models.Supplier;
using OfferHub.Host.Services;

namespace OfferHub.Host.Controllers.Client;

public class SupplierController : AbstractClientController
{
    public SupplierController(IServiceFactory serviceFactory) : base(serviceFactory) { }
    
    [HttpPost]
    [ProducesResponseType(typeof(CreateSupplier.Response), 200)]
    public async Task<IActionResult> CreateSupplier([FromBody] CreateSupplier supplierRequest)
    {
        var supplier = await ServiceFactory.SupplierService.Create(supplierRequest.Name);

        return Ok(new CreateSupplier.Response(
                supplier.Id,
                supplier.Name,
                supplier.CreationDate));
    }
    
    
    [HttpGet]
    [ProducesResponseType(typeof(PopularitySupplierList.Response), 200)]
    public async Task<IActionResult> GetPopularitySupplier()
    {
        const int maxTakeSupplier = 3;
        var supplierList = await ServiceFactory.SupplierService.SupplierList(0, maxTakeSupplier);

        var response = supplierList
            .Select(s => new PopularitySupplierList.Response(
                    s.Name,
                    s.Offers.Count))
            .OrderByDescending(supplier => supplier.OfferCount)
            .ToList();
        
        return Ok(response);
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(SupplierList.Response), 200)]
    public async Task<IActionResult> SupplierList(int skip, int take)
    {
        var supplierList = await ServiceFactory.SupplierService.SupplierList(skip, take);

        var response = supplierList
            .Select(s => new SupplierList.Response(
                    s.Id,
                    s.Name,
                    s.CreationDate,
                    s.Offers.Select(o => o.Id).ToList()))
            .ToList();
        
        return Ok(response);
    }
}