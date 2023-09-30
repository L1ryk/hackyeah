﻿using Microsoft.EntityFrameworkCore;
using WebAPI.DataSource.Entities.Locations;
using WebAPI.Helpers;
using WebAPI.Models.Paginations;
using WebAPI.Models.Responses.Cities;

namespace WebAPI.DataSource.Accessors.LocationAccessors;

public class CityAccessor : ICityAccessor
{
    private readonly ApiDbContext _dbContext;
    public CityAccessor( ApiDbContext dbContext )
    {
        Guard.IsNotNull( dbContext );

        _dbContext = dbContext;
    }

    public async Task<GetAllCitiesResponse> GetAllCitiesAsync( Pagination pagination )
    {
        var query = await QueryHelper.GetPaginatedQuery<City>( pagination, _dbContext );

        return new GetAllCitiesResponse { Items = query.Result, ItemCount = query.ItemsCount };
    }

    public async Task<GetAllCitiesResponse> GetCitiesAsync( GetCities getCities )
    {
        Guard.IsNotNull( getCities );

        var query = _dbContext.Cities.Where( c => c.Voivodeship.Id == getCities.VoivodeshipId );

        var itemsCount = await query.CountAsync();

        var cities = await query.Skip( ( getCities.Page - 1 ) * getCities.Limit ).Take( getCities.Limit )
            .ToListAsync();

        return new GetAllCitiesResponse { Items = cities, ItemCount = itemsCount };
    }
}