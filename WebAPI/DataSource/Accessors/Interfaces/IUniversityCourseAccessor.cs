using WebAPI.Models.Paginations;
using WebAPI.Models.Responses.UniversityCourses;

namespace WebAPI.DataSource.Accessors.Interfaces;

public interface IUniversityCourseAccessor
{
    Task<GetAllUniversityCoursesResponse> GetAllUniversityCoursesAsync( Pagination pagination );
    Task<GetAllUniversityCoursesResponse> GetUniversityCoursesAsync( GetUniversityCourses getUniversityCourses );
}