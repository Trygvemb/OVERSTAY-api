using Overstay.Domain.Entities.Bases;

namespace Overstay.Domain.Entities.Countries;

public class Country : EntityBase
{
    public string Name { get; set; }
    public string IsoCode { get; set; }
}
