using Microsoft.EntityFrameworkCore;
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
        var query = _dbContext.UniversityCourses;

        var itemsCount = await query.CountAsync();

        var universityCourses = await query.Skip( ( pagination.Page - 1 ) * pagination.Limit ).Take( pagination.Limit )
            .ToListAsync();

        return new GetAllUniversityCoursesResponse { Items = universityCourses, ItemCount = itemsCount };
    }

    
    /// <summary>
    /// Get UniversityCourses by: id, university id, course id, language, profile
    /// </summary>
    public async Task<GetAllUniversityCoursesResponse> GetUniversityCoursesAsync( GetUniversityCourses getUniversityCourses )
    {
        Guard.IsNotNull( getUniversityCourses );

        var idPresent         = getUniversityCourses.Id             != null;
        var universityPresent = getUniversityCourses.University?.Id != null;
        var coursePresent     = getUniversityCourses.Course?.Id     != null;
        var languagePresent   = getUniversityCourses.Language       != null;
        var profilePresent    = getUniversityCourses.Profile        != null;
        
        var query = _dbContext.UniversityCourses
            .Where( uc => ( !idPresent || uc.Id            == getUniversityCourses.Id )
                          && ( !universityPresent   || uc.University.Id == getUniversityCourses.University.Id )
                          && ( !coursePresent       || uc.Course.Id     == getUniversityCourses.Course.Id )
                          && ( !languagePresent     || uc.Language      == getUniversityCourses.Language )
                          && ( !profilePresent      || uc.Profile       == getUniversityCourses.Profile ) );

        var itemsCount = await query.CountAsync();

        var universityCourses = await query.Skip( ( getUniversityCourses.Page - 1 ) * getUniversityCourses.Limit ).Take( getUniversityCourses.Limit )
            .ToListAsync();

        return new GetAllUniversityCoursesResponse { Items = universityCourses, ItemCount = itemsCount };
    }
}