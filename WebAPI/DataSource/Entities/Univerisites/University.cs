using System.ComponentModel.DataAnnotations;

namespace WebAPI.DataSource.Entities.Univerisites;

public class University
{
    [Key]
    public Guid Id { get; set; }

    public string Name { get; set; }

    public UniversityDetails Details { get; set; }
}