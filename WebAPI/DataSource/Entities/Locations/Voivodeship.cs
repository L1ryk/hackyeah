using System.ComponentModel.DataAnnotations;
using WebAPI.DataSource.Entities.Locations;

namespace WebAPI.DataSource.Entities.System;

public class Voivodeship
{
    [ Key ]
    public Guid Id { get; set; }

    public Country Country { get; set; }

    public string Name { get; set; }
}