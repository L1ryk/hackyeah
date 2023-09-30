using Microsoft.EntityFrameworkCore;
using WebAPI.Helpers;
using WebAPI.Models.Paginations;
using WebAPI.Models.Responses.Voivodeships;

namespace WebAPI.DataSource.Accessors.LocationAccessors;

public class VoivodeshipAccessor : IVoivodeshipAccessor
{
    private readonly ApiDbContext _dbContext;
    public VoivodeshipAccessor( ApiDbContext dbContext )
    {
        Guard.IsNotNull( dbContext );

        _dbContext = dbContext;
    }

    public async Task<GetAllVoivodeshipsResponse> GetAllVoivodeshipsAsync( Pagination pagination )
    {
        var query = _dbContext.Voivodeships;

        var itemsCount = await query.CountAsync();

        var voivodeships = await query.Skip( ( pagination.Page - 1 ) * pagination.Limit ).Take( pagination.Limit )
            .ToListAsync();

        return new GetAllVoivodeshipsResponse { Items = voivodeships, ItemCount = itemsCount };
    }

    public async Task<GetAllVoivodeshipsResponse> GetAllVoivodeshipsAsync( GetVoivodeships getVoivodeships )
    {
        Guard.IsNotNull( getVoivodeships );

        var query = _dbContext.Voivodeships;

        var itemsCount = await query.CountAsync();

        var voivodeships = await query.Skip( ( getVoivodeships.Page - 1 ) * getVoivodeships.Limit ).Take( getVoivodeships.Limit )
            .ToListAsync();

        return new GetAllVoivodeshipsResponse { Items = voivodeships, ItemCount = itemsCount };
    }

}