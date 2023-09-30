using System.ComponentModel.DataAnnotations;
using WebAPI.DataSource.Entities.System;

namespace WebAPI.DataSource.Entities.Locations;

public class City
{
    [Key]
    public Guid Id { get; set; }

    public string Name { get; set; }

    public Voivodeship Voivodeship { get; set; }
}