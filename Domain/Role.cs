using Domain.Interfaces;

namespace Domain;

public enum RoleKey
{
    admin = 1,
    companyAdmin = 2,
    meteorologist = 3,
    user = 4,
}

public class Role : IEntity
{
    public int Id { get; set; }
    public RoleKey Key { get; set; }
    public string Name { get; set; }
    public string? Description { get; set; }

    public ICollection<User> Users { get; set; }
}