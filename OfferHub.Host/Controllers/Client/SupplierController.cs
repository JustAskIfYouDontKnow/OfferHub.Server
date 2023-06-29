using Microsoft.AspNetCore.Mvc;
using OfferHub.API.Models.Supplier;
using OfferHub.Host.Services;

namespace OfferHub.Host.Controllers.Client;

public class SupplierController : AbstractClientController
{
    public SupplierController(IServiceFactory serviceFactory) : base(serviceFactory) { }
    
    [HttpPost]
    [ProducesResponseType(typeof(CreateSupplier.Response), 200)]
    public async Task<IActionResult> CreateSupplier([FromBody] CreateSupplier request)
    {
        var supplier = await ServiceFactory.SupplierService.Create(request.Name);

        var response = new CreateSupplier.Response(
            supplier.Id,
            supplier.Name,
            supplier.CreationDate);
        
        return Ok(response);
    }
    
    
    [HttpGet]
    [ProducesResponseType(typeof(PopularSupplierList.Response), 200)]
    public async Task<IActionResult> GetPopularSupplier()
    {
        const int maxTakeSupplier = 3;
        var supplierList = await ServiceFactory.SupplierService.SupplierList(0, maxTakeSupplier);

        var responseItems = supplierList
            .Select(s => new PopularSupplierList.ResponseItem(
                s.Name,
                s.Offers.Count))
            .OrderByDescending(supplier => supplier.OfferCount)
            .ToList();
        
        var response = new PopularSupplierList.Response(responseItems);
    
        return Ok(response);
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(SupplierList.Response), 200)]
    public async Task<IActionResult> SupplierList(int skip, int take)
    {
        var supplierList = await ServiceFactory.SupplierService.SupplierList(skip, take);

        var responseItems = supplierList
            .Select(s => new SupplierList.ResponseItem(
                    s.Id,
                    s.Name,
                    s.CreationDate,
                    s.Offers.Select(o => o.Id).ToList()))
            .ToList();
        
        var response = new SupplierList.Response(responseItems);
        
        return Ok(response);
    }
}