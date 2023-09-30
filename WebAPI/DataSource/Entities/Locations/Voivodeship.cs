using System.ComponentModel.DataAnnotations;

namespace WebAPI.DataSource.Entities.System;

public class Voivodeship
{
    [Key]
    public Guid Id { get; set; }

    public string Name { get; set; }
}