namespace OfferHub.API.Models.Supplier;

public class SupplierList
{
    public class Response
    {
        public Response(int id, string name, DateTime creationDate, List<int> offerIds)
        {
            Id = id;
            Name = name;
            CreationDate = creationDate;
            OfferIds = offerIds;
        }
        
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreationDate { get; set; }

        public List<int> OfferIds { get; set; }

    }
}