using WebAPI.Models.Paginations;
using WebAPI.Models.Responses.Voivodeships;

namespace WebAPI.DataSource.Accessors.Interfaces;

public interface IVoivodeshipAccessor
{
    Task<GetAllVoivodeshipsResponse> GetAllVoivodeshipsAsync( Pagination pagination );
    Task<GetAllVoivodeshipsResponse> GetVoivodeshipsAsync( GetVoivodeships getVoivodeships );
}