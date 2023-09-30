using WebAPI.DataSource.Entities.Univerisites;
using WebAPI.Models.Paginations;

namespace WebAPI.Models.Responses.UniversityCourses;

public class GetUniversityCourses : Pagination
{
    public Guid Id { get; set; }

    public Guid UniversityId { get; set; }

    public Guid CourseId { get; set; }

    public Guid CourseLevelId { get; set; }

    public Guid CourseFormId { get; set; }

    public string? Language { get; set; }

    public string? Profile { get; set; }
}