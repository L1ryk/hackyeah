using System.ComponentModel.DataAnnotations;

namespace WebAPI.DataSource.Entities.System;

public class City
{
    [Key]
    public Guid Id { get; set; }

    public string Name { get; set; }

    public Voivodeship Voivodeship { get; set; }
}