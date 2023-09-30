using System.ComponentModel.DataAnnotations;

namespace WebAPI.DataSource.Entities.Locations;

public class Voivodeship : IEntity
{
    [ Key ]
    public Guid Id { get; set; }

    public Country Country { get; set; }

    public string Name { get; set; }
}