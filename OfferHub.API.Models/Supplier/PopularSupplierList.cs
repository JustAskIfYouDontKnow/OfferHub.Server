namespace OfferHub.API.Models.Supplier;

public class PopularSupplierList
{
    public class Response
    {
        public Response(List<ResponseItem> suppliers)
        {
            Suppliers = suppliers;
        }
            
        public List<ResponseItem> Suppliers { get; set; }
    }
        
    public class ResponseItem
    {
        public ResponseItem(string name, int offerCount)
        {
            Name = name;
            OfferCount = offerCount;
        }
            
        public string Name { get; set; }
            
        public int OfferCount { get; set; }
    }
}