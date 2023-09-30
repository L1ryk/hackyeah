using Microsoft.EntityFrameworkCore;
using WebAPI.DataSource.Accessors.Interfaces;
using WebAPI.DataSource.Entities.Univerisites;
using WebAPI.Helpers;
using WebAPI.Models.Paginations;
using WebAPI.Models.Responses.Courses;
using WebAPI.Models.Responses.UniversityCourses;

namespace WebAPI.DataSource.Accessors.UniversityAccessors;

public class UniversityCourseAccessor : IUniversityCourseAccessor
{
    private readonly ApiDbContext _dbContext;
    public UniversityCourseAccessor( ApiDbContext dbContext )
    {
        Guard.IsNotNull( dbContext );

        _dbContext = dbContext;
    }

    public async Task<GetAllUniversityCoursesResponse> GetAllUniversityCoursesAsync( Pagination pagination )
    {
        var res = await QueryHelper.GetPaginatedQuery<UniversityCourse>( pagination, _dbContext );

        return new GetAllUniversityCoursesResponse { Items = res.Result, ItemCount = res.ItemsCount };
    }

    public async Task<GetAllUniversityCoursesResponse> GetUniversityCoursesAsync( GetUniversityCourses getUniversityCourses )
    {
        Guard.IsNotNull( getUniversityCourses );

        var res = await QueryHelper.PrepareUniversityCourseQueryAsync( getUniversityCourses, _dbContext );

        return new GetAllUniversityCoursesResponse { Items = res.Result, ItemCount = res.ItemsCount };
    }
}