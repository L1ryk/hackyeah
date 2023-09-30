﻿using WebAPI.DataSource.Accessors.Interfaces;
using WebAPI.Helpers;
using WebAPI.Models.Paginations;
using WebAPI.Models.Responses.Tags;

namespace WebAPI.DataSource.Accessors.UniversityAccessors;

public class TagAccessor : ITagAccessor
{
    private readonly ApiDbContext _dbContext;

    public TagAccessor( ApiDbContext dbContext )
    {
        Guard.IsNotNull( dbContext );

        _dbContext = dbContext;
    }

    public async Task<GetAllTagsResponse> GetAllTagsAsync( Pagination pagination )
    {
        var tagsQuery = _dbContext.Tags.OrderBy( t => t.Name );

        var res = await tagsQuery.GetPaginatedQuery( pagination, _dbContext );

        return new GetAllTagsResponse { Items = res.Result, ItemCount = res.ItemsCount };
    }
}