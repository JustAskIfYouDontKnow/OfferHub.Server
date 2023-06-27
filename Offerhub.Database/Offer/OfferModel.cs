using Offerhub.Database.Supplier;

namespace Offerhub.Database.Offer;

public class OfferModel : AbstractModel
{
    public int Id { get; set; }

    public string Brand { get; set; }

    public string Model { get; set; }

    public int SupplierId { get; set; }

    public DateTime RegistrationDate { get; set; }

    public SupplierModel Supplier { get; set; }
    
    
    
    public static OfferModel Create(int id, string brand, string model, int supplierId, DateTime registrationDate, SupplierModel supplier)
    {
        return new OfferModel()
        {
            Id = id,
            Brand = brand,
            Model = model,
            SupplierId = supplierId,
            RegistrationDate = DateTime.Now,
            Supplier = supplier,
        };
    }
}