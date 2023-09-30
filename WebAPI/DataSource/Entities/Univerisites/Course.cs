namespace WebAPI.DataSource.Entities.Univerisites;

public class Course : IEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public ICollection<CourseTag> Tags { get; set; }
}