namespace WebAPI.DataSource.Entities.Univerisites;

public class UniversityCourse
{
    public Guid Id { get; set; }

    public University University { get; set; }

    public Course Course { get; set; }

    public string? Language { get; set; }

    public string? Profile { get; set; }
}