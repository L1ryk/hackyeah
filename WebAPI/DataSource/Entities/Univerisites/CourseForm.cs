namespace WebAPI.DataSource.Entities.Univerisites;

public class CourseForm : IEntity
{
    public Guid Id { get; set; }

    public string Name { get; set; }
}