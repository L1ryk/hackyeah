using Microsoft.AspNetCore.Mvc;
using NLog;
using WebAPI.Models.Responses;

namespace WebAPI.Helpers;

/// <summary>
/// Basic request method error handler.
/// </summary>
public static class ErrorHandler
{
    private static readonly Logger _logger = LogManager.GetCurrentClassLogger();
    
    /// <summary>
    /// Get the error handler.
    /// If any error occurs inside the caller a new json result with error message will be returned. 
    /// </summary>
    /// <param name="caller">Caller method.</param>
    /// <returns>Returns an action result.</returns>
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