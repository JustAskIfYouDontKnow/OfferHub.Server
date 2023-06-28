namespace OfferHub.API.Models.Supplier;

public class PopularitySupplierList
{
    public class Response
    {
        public Response(string name, int offerCount)
        {
            Name = name;
            OfferCount = offerCount;
        }
        public string Name { get; set; }
        public int OfferCount { get; set; }
    }
}