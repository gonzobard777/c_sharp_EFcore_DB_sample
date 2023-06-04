using Domain.Interfaces;

namespace Domain;

public class Company : IEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Contacts { get; set; }
    public bool IsActive { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public ICollection<User>? Users { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]
    public ICollection<License>? Licenses { get; set; }
}