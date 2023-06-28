namespace OfferHub.API.Models.Offer;

public class OfferListWithTotalCount
{
    public class Response
    {
        public int TotalCount { get; set; }
        public List<OfferList.Response> Offers { get; set; }
    }
}