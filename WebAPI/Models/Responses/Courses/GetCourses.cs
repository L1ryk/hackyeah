using WebAPI.DataSource.Entities.Univerisites;
using WebAPI.Models.Paginations;

namespace WebAPI.Models.Responses.Courses;

public class GetCourses : Pagination
{
    public List<Filter> Filters { get; set; }
}