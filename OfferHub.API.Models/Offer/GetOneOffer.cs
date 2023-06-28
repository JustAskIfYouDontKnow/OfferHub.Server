using System.ComponentModel.DataAnnotations;

namespace OfferHub.API.Models.Offer;

public class GetOneOffer
{
    public int Id { get; set; }
    
    public class Response
    {
        public Response(int id, string brand, string model, DateTime registrationDate, int supplierId, string supplierName)
        {
            Id = id;
            Brand = brand;
            Model = model;
            RegistrationDate = registrationDate;
            SupplierId = supplierId;
            SupplierName = supplierName;
        }
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public DateTime RegistrationDate { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
    }
}