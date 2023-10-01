using WebAPI.DataSource.Accessors.Interfaces;
using WebAPI.Helpers;
using WebAPI.Models.Paginations;
using WebAPI.Models.Queries;
using WebAPI.Models.Responses.Occupations;

namespace WebAPI.DataSource.Accessors.UniversityAccessors;

public class OccupationAccessor : IOccupationAccessor
{
    private readonly ApiDbContext dbContext;

    public OccupationAccessor( ApiDbContext dbContext )
    {
        Guard.IsNotNull( dbContext );

        this.dbContext = dbContext;
    }

    public async Task< GetAllOccupationsResponse > GetAllOccupationAsync( Pagination pagination )
    {
        var occupationsQuery = dbContext.Occupations.OrderBy( t => t.Name );

        var res = await occupationsQuery.GetPaginatedQuery( pagination, dbContext );

        return new GetAllOccupationsResponse
        {
            Items = res.Result, ItemCount = res.ItemsCount
        };
    }

    public async Task< MeetOccupationsResponse > GetMeetOccupation( MeetOccupationQuery meetOccupationQuery )
    {
        var occupationsQuery = dbContext.Occupations.Where( t => t.Name.ToLower().Contains( meetOccupationQuery.Part.ToLower() ) );

        var res = await occupationsQuery.GetPaginatedQuery( meetOccupationQuery, dbContext );

        return new MeetOccupationsResponse
        {
            Items = res.Result, ItemCount = res.ItemsCount
        };
    }
}