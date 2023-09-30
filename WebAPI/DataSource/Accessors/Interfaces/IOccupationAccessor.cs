using WebAPI.Models.Paginations;
using WebAPI.Models.Queries;
using WebAPI.Models.Responses.Occupations;

namespace WebAPI.DataSource.Accessors.Interfaces;

public interface IOccupationAccessor
{
    Task< GetAllOccupationsResponse > GetAllOccupationAsync( Pagination pagination );

    Task<MeetOccupationsResponse> GetMeetOccupation( MeetOccupationQuery meetOccupationQuery );
}