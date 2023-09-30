using WebAPI.DataSource.Entities.Locations;
using WebAPI.DataSource.Entities.System;
using WebAPI.Models.Paginations;

namespace WebAPI.Models.Responses.Cities;

public class GetAllCitiesResponse : PaginatedResult<City>
{
}