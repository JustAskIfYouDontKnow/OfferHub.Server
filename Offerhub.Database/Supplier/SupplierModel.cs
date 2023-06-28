using Offerhub.Database.Offer;

namespace Offerhub.Database.Supplier;

public class SupplierModel : AbstractModel
{
    
    public int Id { get; set; }

    public string Name { get; set; }

    public DateTime CreationDate { get; set; }

    public List<OfferModel> Offers { get; set; }
    
    
    
    public static SupplierModel Create(string name, DateTime creationDate)
    {
        return new SupplierModel()
        {
            Name = name,
            CreationDate = DateTime.Now,
        };
    }
}