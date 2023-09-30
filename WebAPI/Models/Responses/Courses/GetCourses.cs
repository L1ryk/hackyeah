using WebAPI.DataSource.Entities.Univerisites;
using WebAPI.Models.Paginations;

namespace WebAPI.Models.Responses.Courses;

public class GetCourses : Pagination
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public List<Guid> TagIds { get; set; }
}