namespace WebAPI.DataSource.Entities.Univerisites;

public class CourseOccupation
{
    public Guid Id { get; set; }

    public Course Course { get; set; }

    public Occupation Occupation { get; set; }
}