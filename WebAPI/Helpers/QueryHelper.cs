using Microsoft.EntityFrameworkCore;
using WebAPI.DataSource;
using WebAPI.DataSource.Entities;
using WebAPI.DataSource.Entities.Univerisites;
using WebAPI.Models;
using WebAPI.Models.Paginations;
using WebAPI.Models.Queries;
using WebAPI.Models.Responses.Courses;
using WebAPI.Models.Responses.UniversityCourses;

namespace WebAPI.Helpers;

public static class QueryHelper
{
    public static async Task< PaginationQuery< T > > GetPaginatedQuery< T >( Pagination   pagination,
                                                                             ApiDbContext dbContext )
        where T : class, IEntity
    {
        Guard.IsNotNull( pagination );
        Guard.IsNotNull( dbContext );

        var dbSet = dbContext.Set< T >();

        var itemsCount = await dbSet.CountAsync();

        var query = dbSet.Skip( ( pagination.Page - 1 ) * pagination.Limit ).Take( pagination.Limit );

        return new PaginationQuery< T >
        {
            Result = await query.ToListAsync(), ItemsCount = itemsCount
        };
    }

    public static async Task< PaginationQuery< T > > GetPaginatedQuery< T >( this IQueryable< T > queryable,
                                                                             Pagination           pagination,
                                                                             ApiDbContext         dbContext )
        where T : class, IEntity
    {
        Guard.IsNotNull( pagination );
        Guard.IsNotNull( dbContext );

        var itemsCount = await queryable.CountAsync();

        var query = queryable.Skip( ( pagination.Page - 1 ) * pagination.Limit ).Take( pagination.Limit );

        return new PaginationQuery< T >
        {
            Result = await query.ToListAsync(), ItemsCount = itemsCount
        };
    }

    public static async Task< PaginationQuery< UniversityCourse > > PrepareUniversityCourseQueryAsync(
        GetUniversityCourses getUniversityCourses,
        ApiDbContext         dbContext )
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

    public static async Task< PaginationQuery< UniversityCourse > > PrepareCourseQueryAsync( GetCourses getCourses,
        ApiDbContext                                                                                    dbContext )
    {
        var query = dbContext.UniversityCourses
            .Include( uc => uc.University )
            .Include( uc => uc.Course )
            .Include( uc => uc.Course ).ThenInclude( c => c.Tags )
            .Include( uc => uc.CourseForm )
            .Include( uc => uc.CourseLevel )
            .AsQueryable();

        query = await query.executeFilters( getCourses.Filters, dbContext );

        return await query.GetPaginatedQuery( getCourses, dbContext );
    }

    private static async Task< IQueryable< UniversityCourse > > executeFilters(
        this IQueryable< UniversityCourse > query,
        IReadOnlyCollection< Filter >       filters,
        ApiDbContext                        dbContext )
    {
        var isStationaryFilter = filters.FirstOrDefault( f => f.Property.ToLower().Equals( "isstationary" ) );

        var occupationFilter = filters.FirstOrDefault( f => f.Property.ToLower().Equals( "occupation" ) );

        var tagsFilter = filters.FirstOrDefault( f => f.Property.ToLower().Equals( "tags" ) );

        var voivodeshipFilter = filters.FirstOrDefault( f => f.Property.ToLower().Equals( "voivodeship" ) );

        var cityFilter = filters.FirstOrDefault( f => f.Property.ToLower().Equals( "city" ) );

        var levelFilter = filters.FirstOrDefault( f => f.Property.ToLower().Equals( "level" ) );

        var brandFilter = filters.FirstOrDefault( f => f.Property.ToLower().Equals( "brand" ) );

        if ( isStationaryFilter != null )
        {
            var isStationary = Convert.ToBoolean( isStationaryFilter.Value );

            var suggestion = isStationary ? "Stacjonarne" : "Niestacjonarne";

            query = query.Where( q => q.CourseForm.Name.Equals( suggestion ) );
        }

        if ( occupationFilter != null )
        {
            var filter = ( occupationFilter.Value.ToString() ?? String.Empty ).ToLower();

            if ( !string.IsNullOrEmpty( filter ) )
            {
                var occupations = await dbContext.CourseOccupations
                    .Include( co => co.Course )
                    .Where( o => o.Occupation.Name.ToLower().Equals( filter ) ).ToListAsync();

                query = query.Where( q => occupations.Select( o => o.Course.Id ).Contains( q.Course.Id ) );
            }
        }

        if ( tagsFilter is { Value: List< Guid > tags } )
            query = query.Where( uc => uc.Course.Tags.Any( t => tags.Contains( t.Tag.Id ) ) );

        if ( voivodeshipFilter != null )
            query = query.Where( q => q.University.Voivodeship.Id == ( Guid )voivodeshipFilter.Value );

        if ( cityFilter != null && Guid.TryParse( cityFilter.Value.ToString(), out Guid guid ) )
            query = query.Where( q => q.University.City.Id == guid );

        if ( levelFilter is { Value: List< string > levels } )
        {
            var level = levels
                .Select( l => l.ToLower() )
                .Where( validateLevel )
                .ToList();

            if ( levels.Any() )
                query = query.Where( q => level.Contains( q.CourseLevel.Name.ToLower() ) );
        }

        if ( brandFilter is { Value: List< string > brands } )
        {
            // var brands = ( brandFilter.Value.ToString() ?? String.Empty ).ToLower();
            var collegeKind = brands
                .Select( l => l.ToString().ToLower() )
                .Where( string.IsNullOrEmpty )
                .ToList();

            if ( collegeKind.Any() )
                query = query.Where( q => collegeKind.Contains( q.University.Brand.ToLower() ) );
        }

        return query;
    }

    private static bool validateLevel( string level )
    {
        if ( string.IsNullOrEmpty( level ) )
            return false;

        return level switch
        {
            "i stopnia" => true,
            "jednolite magisterskie" => true,
            _ => false
        };
    }
}