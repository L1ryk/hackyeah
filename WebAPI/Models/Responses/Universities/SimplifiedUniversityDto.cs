using WebAPI.DataSource.Entities.Locations;
using WebAPI.DataSource.Entities.System;

namespace WebAPI.Models.Responses.Universities;

public class SimplifiedUniversityDto
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public City City { get; set; }

    public Voivodeship Voivodeship { get; set; }
}