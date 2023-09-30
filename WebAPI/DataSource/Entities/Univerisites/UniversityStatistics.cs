using System.ComponentModel.DataAnnotations;

namespace WebAPI.DataSource.Entities.Univerisites;

public class UniversityStatistics
{
    [Key]
    public Guid Id { get; set; }
    
    public University University { get; set; }
    
    public string Year { get; set; }

    public int NumberStudents { get; set; }

    public int NumberCourse { get; set; }

    public int NumberEmployees { get; set; }
}
