using Microsoft.EntityFrameworkCore;
using WebAPI.Helpers;
using WebAPI.Models.Paginations;
using WebAPI.Models.Responses.Courses;

namespace WebAPI.DataSource.Accessors.UniversityAccessors;

public class CourseAccessor : ICourseAccessor
{
    private readonly ApiDbContext _dbContext;
    public CourseAccessor( ApiDbContext dbContext )
    {
        Guard.IsNotNull( dbContext );

        _dbContext = dbContext;
    }

    public async Task<GetAllCoursesResponse> GetAllCoursesAsync( Pagination pagination )
    {
        var query = _dbContext.Courses;

        var itemsCount = await query.CountAsync();

        var Courses = await query.Skip( ( pagination.Page - 1 ) * pagination.Limit ).Take( pagination.Limit )
            .ToListAsync();

        return new GetAllCoursesResponse { Items = Courses, ItemCount = itemsCount };
    }

    
    /// <summary>
    /// Get courses by: id, tags, name (search if contains)
    /// </summary>
    public async Task<GetAllCoursesResponse> GetCoursesAsync( GetCourses getCourses )
    {
        Guard.IsNotNull( getCourses );

        var idPresent   = getCourses.Id != null;
        var tagsPresent = getCourses.Tags.Any();
        var namePresent = string.IsNullOrWhiteSpace( getCourses.Name );

        var query = _dbContext.Courses
            .Where( c => ( !idPresent || c.Id == getCourses.Id )
               && ( !namePresent || c.Name.Contains( getCourses.Name ) ) 
               && ( !tagsPresent || getCourses.Tags.All( t => c.Tags.Contains( t ) ) ) );

        var itemsCount = await query.CountAsync();

        var courses = await query.Skip( ( getCourses.Page - 1 ) * getCourses.Limit ).Take( getCourses.Limit )
            .ToListAsync();

        return new GetAllCoursesResponse { Items = courses, ItemCount = itemsCount };
    }
}