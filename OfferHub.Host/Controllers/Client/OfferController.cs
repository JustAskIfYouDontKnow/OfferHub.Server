using Microsoft.AspNetCore.Mvc;
using OfferHub.API.Models.Offer;
using OfferHub.Host.Services;

namespace OfferHub.Host.Controllers.Client;

public class OfferController : AbstractClientController
{
    public OfferController(IServiceFactory serviceFactory) : base(serviceFactory) { }
    
    [HttpPost]
    [ProducesResponseType(typeof(GetOneOffer.Response), 200)]
    public async Task<IActionResult> GetOneOfferById([FromBody] GetOneOffer offerRequest)
    {
        var offer = await ServiceFactory.OfferService.GetOneById(offerRequest.Id);

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
    public async Task<IActionResult> Create([FromBody] CreateOffer offerRequest)
    {
        var offer = await ServiceFactory.OfferService.Create(offerRequest.Brand, offerRequest.Model, offerRequest.SupplierId);

        var response = new CreateOffer.Response(
            offer.Id,
            offer.Brand,
            offer.Model,
            offer.RegistrationDate,
            offer.SupplierId);
        
        return Ok(response);
    }


    [HttpGet]
    [ProducesResponseType(typeof(OfferList.Response), 200)]
    public async Task<IActionResult> SearchOffers(string searchTerm)
    {
        var fundedOffers = await ServiceFactory.OfferService.SearchOffers(searchTerm);
        
        var response = new OfferListWithTotalCount.Response
        {
            TotalCount = fundedOffers.Count,
            Offers = fundedOffers.Select(o => new OfferList.Response(
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
    [ProducesResponseType(typeof(OfferListWithTotalCount.Response), 200)]
    public async Task<IActionResult> ListOffers()
    {
        var offerList = await ServiceFactory.OfferService.OfferList();

        var response = new OfferListWithTotalCount.Response
        {
            TotalCount = offerList.Count,
            Offers = offerList.Select(o => new OfferList.Response(
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
