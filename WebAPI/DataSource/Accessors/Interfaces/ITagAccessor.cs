using WebAPI.Models.Paginations;
using WebAPI.Models.Queries;
using WebAPI.Models.Responses.Tags;

namespace WebAPI.DataSource.Accessors.Interfaces;

public interface ITagAccessor
{
    Task<GetAllTagsResponse> GetAllTagsAsync( Pagination pagination );

    Task<MeetTagsResponse> GetMeetTags( MeetTagQuery meetTagQuery );
}