using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebAPI.DataSource;
using WebAPI.DataSource.Entities;
using WebAPI.DataSource.Entities.Univerisites;
using WebAPI.Models.Paginations;
using WebAPI.Models.Queries;
using WebAPI.Models.Responses.Courses;
using WebAPI.Models.Responses.UniversityCourses;

namespace WebAPI.Helpers;

public static class QueryHelper
{
    public static async Task<PaginationQuery<T>> GetPaginatedQuery<T>( Pagination pagination, ApiDbContext dbContext ) where T : class, IEntity
    {
        Guard.IsNotNull( pagination );
        Guard.IsNotNull( dbContext );

        var dbSet = dbContext.Set<T>();

        var itemsCount = await dbSet.CountAsync();

        var query = dbSet.Skip( ( pagination.Page - 1 ) * pagination.Limit ).Take( pagination.Limit );

        return new PaginationQuery<T>
        {
            Result = await query.ToListAsync(),
            ItemsCount = itemsCount
        };
    }

    public static async Task<PaginationQuery<T>> GetPaginatedQuery<T>( this IQueryable<T> queryable, Pagination pagination, ApiDbContext dbContext ) where T : class, IEntity
    {
        Guard.IsNotNull( pagination );
        Guard.IsNotNull( dbContext );

        var itemsCount = await queryable.CountAsync();

        var query = queryable.Skip( ( pagination.Page - 1 ) * pagination.Limit ).Take( pagination.Limit );

        return new PaginationQuery<T>
        {
            Result = await query.ToListAsync(),
            ItemsCount = itemsCount
        };
    }

    public static async Task<PaginationQuery<UniversityCourse>> PrepareUniversityCourseQueryAsync( GetUniversityCourses getUniversityCourses, ApiDbContext dbContext )
    {
        var query = dbContext.UniversityCourses.AsQueryable();

        if ( !Guid.Empty.Equals( getUniversityCourses.UniversityId ) )
            query = query.Where( q => q.University.Id == getUniversityCourses.UniversityId );

        if ( !Guid.Empty.Equals( getUniversityCourses.CourseId ) )
            query = query.Where( q => q.Course.Id == getUniversityCourses.CourseId );

        if ( !Guid.Empty.Equals( getUniversityCourses.CourseLevelId ) )
            query = query.Where( q => q.CourseLevel.Id == getUniversityCourses.CourseLevelId );

        if ( !Guid.Empty.Equals( getUniversityCourses.CourseFormId ) )
            query = query.Where( q => q.CourseForm.Id == getUniversityCourses.CourseFormId );

        if ( !string.IsNullOrEmpty( getUniversityCourses.Language ) )
            query = query.Where( q => q.Language == null || q.Language.Equals( getUniversityCourses.Language ) );

        if ( !string.IsNullOrEmpty( getUniversityCourses.Profile ) )
            query = query.Where( q => q.Profile == null || q.Profile.Equals( getUniversityCourses.Profile ) );

        return await query.GetPaginatedQuery( getUniversityCourses, dbContext );
    }

    public static async Task<PaginationQuery<UniversityCourse>> PrepareCourseQueryAsync( GetCourses getCourses, ApiDbContext dbContext )
    {
        var query = dbContext.UniversityCourses
            .Include( uc => uc.University )
            .Include( uc => uc.Course )
            .Include( uc => uc.Course ).ThenInclude( c => c.Tags )
            .Include( uc => uc.CourseForm )
            .Include( uc => uc.CourseLevel )
            .AsQueryable();

        var isStationaryFilter = getCourses.Filters.FirstOrDefault( f => f.Property.Equals( "IsStationary" ) );

        var occupationFilter = getCourses.Filters.FirstOrDefault( f => f.Property.Equals( "Occupation" ) );
        var tagsFilter = getCourses.Filters.FirstOrDefault( f => f.Property.Equals( "Tags" ) );

        if ( isStationaryFilter != null )
        {
            var isStationary = Convert.ToBoolean( isStationaryFilter.Value );

            var suggestion = isStationary ? "Stacjonarne" : "Niestacjonarne";

            query = query.Where( q => q.CourseForm.Name.Equals( suggestion ) );
        }

        if ( occupationFilter != null )
        {
            var occupations = await dbContext.CourseOccupations
                .Where( o => o.Course.Name.Equals( occupationFilter.Value.ToString() ) ).ToListAsync();

            query = query.Where( q => occupations.Select( o => o.Course.Id ).Contains( q.Course.Id ) );
        }

        if ( tagsFilter is { Value: List< Guid > tags } )
            query = query.Where( uc => uc.Course.Tags.Any( t => tags.Contains( t.Tag.Id ) ) );

        return await query.GetPaginatedQuery( getCourses, dbContext );
    }
}