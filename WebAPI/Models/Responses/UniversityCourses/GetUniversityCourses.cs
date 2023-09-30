using WebAPI.DataSource.Entities.Univerisites;
using WebAPI.Models.Paginations;

namespace WebAPI.Models.Responses.Courses;

public class GetUniversityCourses : Pagination
{
    public Guid? Id { get; set; }

    public University? University { get; set; }

    public Course? Course { get; set; }

    public string? Language { get; set; }

    public string? Profile { get; set; }
}