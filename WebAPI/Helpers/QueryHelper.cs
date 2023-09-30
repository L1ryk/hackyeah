using Microsoft.EntityFrameworkCore;
using WebAPI.DataSource;
using WebAPI.DataSource.Entities;
using WebAPI.DataSource.Entities.Univerisites;
using WebAPI.Models.Paginations;
using WebAPI.Models.Queries;
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

    public static async Task<PaginationQuery<UniversityCourse>> PrepareCourseQueryAsync( GetUniversityCourses getUniversityCourses, ApiDbContext dbContext )
    {
        var query = dbContext.UniversityCourses.AsQueryable();

        if ( !Guid.Empty.Equals( getUniversityCourses.UniversityId ) )
            query = query.Where( q => q.University.Id == getUniversityCourses.UniversityId );

        if ( !Guid.Empty.Equals( getUniversityCourses.CourseId ) )
            query = query.Where( q => q.Course.Id == getUniversityCourses.CourseId );

        if ( !string.IsNullOrEmpty( getUniversityCourses.Language ) )
            query = query.Where( q => q.Language == null || q.Language.Equals( getUniversityCourses.Language ) );

        if ( !string.IsNullOrEmpty( getUniversityCourses.Profile ) )
            query = query.Where( q => q.Profile == null || q.Profile.Equals( getUniversityCourses.Profile ) );

        return await query.GetPaginatedQuery( getUniversityCourses, dbContext );
    }
}