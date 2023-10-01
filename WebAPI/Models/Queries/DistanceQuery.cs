namespace WebAPI.Models.Queries;

/// <summary>
/// Represents a distance request data structure.
/// </summary>
public class DistanceQuery
{
    /// <summary>
    /// Starting location.
    /// </summary>
    public GeoPosition First { get; set; }
    
    /// <summary>
    /// Ending location.
    /// </summary>
    public GeoPosition Second { get; set; }
}
