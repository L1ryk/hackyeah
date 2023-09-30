using WebAPI.DataSource.Accessors.Interfaces;
using WebAPI.DataSource.Entities.Locations;
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
        var voivodeships = await QueryHelper.GetPaginatedQuery<Voivodeship>( pagination, _dbContext );

        return new GetAllVoivodeshipsResponse { Items = voivodeships.Result, ItemCount = voivodeships.ItemsCount };
    }

    public async Task<GetAllVoivodeshipsResponse> GetVoivodeshipsAsync( GetVoivodeships getVoivodeships )
    {
        Guard.IsNotNull( getVoivodeships );

        var query = _dbContext.Voivodeships.Where( v => v.Id == getVoivodeships.Id );

        var result = await query.GetPaginatedQuery( getVoivodeships, _dbContext );

        return new GetAllVoivodeshipsResponse { Items = result.Result, ItemCount = result.ItemsCount };
    }

}