using Overstay.Domain.Entities.Users;

namespace Overstay.Domain.Entities.Countries;

public class Country : Entity
{
    public string Name { get; init; } = string.Empty;
    public string IsoCode { get; init; } = string.Empty;

    /// Navigation properties
    public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
}
