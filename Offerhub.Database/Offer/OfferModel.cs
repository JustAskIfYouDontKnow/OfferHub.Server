using Offerhub.Database.Supplier;

namespace Offerhub.Database.Offer;

public class OfferModel : AbstractModel
{
    public int Id { get; set; }

    public string Brand { get; set; }

    public string Model { get; set; }

    public SupplierModel Supplier { get; set; }

    public int SupplierId { get; set; }

    public DateTime RegistrationDate { get; set; }
    
    
    public static OfferModel Create(string brand, string model, int supplierId)
    {
        return new OfferModel()
        {
            Brand = brand,
            Model = model,
            SupplierId = supplierId,
            RegistrationDate = DateTime.Now,
        };
    }
}