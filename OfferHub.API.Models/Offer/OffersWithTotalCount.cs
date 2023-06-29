namespace OfferHub.API.Models.Offer;

public class OffersWithTotalCount
{
    public class Response
    {
        public int TotalCount { get; set; }
        public List<OfferList.ResponseItem> Offers { get; set; }
    }
}