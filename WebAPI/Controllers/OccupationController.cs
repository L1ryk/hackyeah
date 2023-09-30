using Microsoft.AspNetCore.Mvc;
using WebAPI.DataSource.Accessors.Interfaces;
using WebAPI.DataSource.Entities.Univerisites;
using WebAPI.Helpers;
using WebAPI.Models.Paginations;
using WebAPI.Models.Queries;
using WebAPI.Models.Responses;

namespace WebAPI.Controllers;

[ Route( "api/occupations" ) ]
public class OccupationController : ControllerBase
{
    private readonly IOccupationAccessor occupationAccessor;

    public OccupationController( IOccupationAccessor occupationAccessor )
    {
        Guard.IsNotNull( occupationAccessor );

        this.occupationAccessor = occupationAccessor;
    }

    [ HttpGet ]
    public async Task< ActionResult > Get( [ FromQuery ] Pagination pagination ) =>
        await ErrorHandler.HandlerAsync( async () =>
        {
            var res = await occupationAccessor.GetAllOccupationAsync( pagination );

            return Ok( new Response< PaginatedResult< Occupation > >
            {
                IsSuccess = true,
                Result = new PaginatedResult< Occupation >
                {
                    Items = res.Items, ItemCount = res.ItemCount
                }
            } );
        } );

    [ HttpPost( "search" ) ]
    public async Task< ActionResult > MeetTags( [ FromBody ] MeetOccupationQuery meetOccupationQuery ) =>
        await ErrorHandler.HandlerAsync( async () =>
        {
            Guard.IsNotNull( meetOccupationQuery );

            if ( meetOccupationQuery.Part.Length < 3 )
                return NoContent();

            var res = await occupationAccessor.GetMeetOccupation( meetOccupationQuery );

            return Ok( new Response< PaginatedResult< Occupation > >
            {
                IsSuccess = true,
                Result = new PaginatedResult< Occupation >
                {
                    Items = res.Items, ItemCount = res.ItemCount
                }
            } );
        } );
}