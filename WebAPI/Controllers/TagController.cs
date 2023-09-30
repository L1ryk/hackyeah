using Microsoft.AspNetCore.Mvc;
using WebAPI.DataSource.Accessors.Interfaces;
using WebAPI.DataSource.Entities.Univerisites;
using WebAPI.Helpers;
using WebAPI.Models.Paginations;
using WebAPI.Models.Responses;

namespace WebAPI.Controllers;

[ Route( "api/tags" )]
public class TagController : ControllerBase
{
    private readonly ITagAccessor _tagAccessor;
    public TagController( ITagAccessor tagAccessor )
    {
        Guard.IsNotNull( tagAccessor );

        _tagAccessor = tagAccessor;
    }

    public async Task<ActionResult> Get( Pagination pagination ) =>
        await ErrorHandler.HandlerAsync( async () =>
        {
            var res = await _tagAccessor.GetAllTagsAsync( pagination );

            return Ok( new Response<PaginatedResult<Tag>>
            {
                IsSuccess = true,
                Result = new PaginatedResult<Tag> { Items = res.Items, ItemCount = res.ItemCount }
            } );
        } );
}