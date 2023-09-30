namespace WebAPI.DataSource.Entities.Univerisites;

public class CourseTag : IEntity
{
    public Guid Id { get; set; }

    public Course Course { get; set; }

    public Tag Tag { get; set; }
}