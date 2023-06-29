using Microsoft.AspNetCore.Mvc;
using OfferHub.API.Models.Offer;
using OfferHub.Host.Services;

namespace OfferHub.Host.Controllers.Client;

public class OfferController : AbstractClientController
{
    public OfferController(IServiceFactory serviceFactory) : base(serviceFactory) { }
    
    [HttpPost]
    [ProducesResponseType(typeof(GetOneOffer.Response), 200)]
    public async Task<IActionResult> GetOneOfferById([FromBody] GetOneOffer request)
    {
        var offer = await ServiceFactory.OfferService.GetOneById(request.Id);

        var response = new GetOneOffer.Response(
            offer.Id,
            offer.Brand,
            offer.Model,
            offer.RegistrationDate,
            offer.SupplierId,
            offer.Supplier.Name);
        
        return Ok(response);
    }
    
    
    [HttpPost]
    [ProducesResponseType(typeof(CreateOffer.Response), 200)]
    public async Task<IActionResult> Create([FromBody] CreateOffer request)
    {
        var offer = await ServiceFactory.OfferService.Create(request.Brand, request.Model, request.SupplierId);

        var response = new CreateOffer.Response(
            offer.Id,
            offer.Brand,
            offer.Model,
            offer.RegistrationDate,
            offer.SupplierId);
        
        return Ok(response);
    }


    [HttpGet]
    [ProducesResponseType(typeof(OffersWithTotalCount.Response), 200)]
    public async Task<IActionResult> SearchOffers(string searchTerm)
    {
        var fundedOffers = await ServiceFactory.OfferService.SearchOffers(searchTerm);
        
        var response = new OffersWithTotalCount.Response
        {
            TotalCount = fundedOffers.Count,
            Offers = fundedOffers.Select(o => new OfferList.ResponseItem(
                o.Id,
                o.Brand,
                o.Model,
                o.Supplier.Name,
                o.RegistrationDate
            )).ToList()
        };
    
        return Ok(response);
    }
    
    
    [HttpGet]
    [ProducesResponseType(typeof(OffersWithTotalCount.Response), 200)]
    public async Task<IActionResult> ListOffers()
    {
        var offerList = await ServiceFactory.OfferService.OfferList();

        var response = new OffersWithTotalCount.Response
        {
            TotalCount = offerList.Count,
            Offers = offerList.Select(o => new OfferList.ResponseItem(
                o.Id,
                o.Brand,
                o.Model,
                o.Supplier.Name,
                o.RegistrationDate
            )).ToList()
        };
    
        return Ok(response);
    }
}
