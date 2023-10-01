namespace WebAPI.Models.Queries;

public class DistanceQuery
{
    public GeoPosition First { get; set; }
    
    public GeoPosition Second { get; set; }
}
