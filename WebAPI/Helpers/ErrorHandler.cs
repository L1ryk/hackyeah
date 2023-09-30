using Microsoft.AspNetCore.Mvc;
using NLog;
using WebAPI.Models.Responses;

namespace WebAPI.Helpers;

public static class ErrorHandler
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    public static async Task< ActionResult > HandlerAsync( Func< Task< ActionResult > > caller )
    {
        try
        {
            return await caller();
        }
        catch( Exception ex )
        {
            _logger.Error( ex );

            return new JsonResult( new Response
            {
                IsSuccess = false,
                Error = ex.Message
            } );
        }
    }
}