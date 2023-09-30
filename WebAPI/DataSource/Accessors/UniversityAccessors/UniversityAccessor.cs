using WebAPI.DataSource.Accessors.Interfaces;
using WebAPI.Helpers;
using WebAPI.Models.Paginations;
using WebAPI.Models.Responses.Universities;

namespace WebAPI.DataSource.Accessors.UniversityAccessors;

public class UniversityAccessor : IUniversityAccessor
{
    private readonly ApiDbContext _dbContext;

    public UniversityAccessor( ApiDbContext dbContext )
    {
        Guard.IsNotNull( dbContext );

        _dbContext = dbContext;
    }

    public async Task<GetAllUniversityResponse> GetAllUniversitiesAsync( Pagination pagination )
    {
        var query = _dbContext.Universities;

        var universities = await query
            .OrderBy( u => u.Name )
            .GetPaginatedQuery( pagination, _dbContext );

        return new GetAllUniversityResponse
        {
            Items = universities.Result.Select( u => new SimplifiedUniversityDto
            {
                Id = u.Id, Name = u.Name, City = u.City, Voivodeship = u.Voivodeship,
            } ),
            ItemCount = universities.ItemsCount
        };
    }
}