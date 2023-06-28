namespace OfferHub.API.Models.Supplier;

public class CreateSupplier
{
    public string Name { get; set; }

    public class Response
    {
        public Response(int id, string name, DateTime creationDate)
        {
            Id = id;
            Name = name;
            CreationDate = creationDate;
          
        }
        
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreationDate { get; set; }
    }
}