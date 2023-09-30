using System.ComponentModel.DataAnnotations;

namespace WebAPI.DataSource.Entities.Locations;

public class Country
{
    [ Key ]
    public Guid Id { get; set; }

    public string Name { get; set; }
}