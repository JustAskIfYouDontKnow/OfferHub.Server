namespace OfferHub.API.Models.Offer;

public class OfferList
{
    public class Response
    {
        public Response(int id, string brand, string model, string supplierName, DateTime registrationDate)
        {
            Id = id;
            Brand = brand;
            Model = model;
            SupplierName = supplierName;
            RegistrationDate = registrationDate;
        }
        
        public int Id { get; set; }

        public string Brand { get; set; }

        public string Model { get; set; }

        public string SupplierName { get; set; }

        public DateTime RegistrationDate { get; set; }
    }
}