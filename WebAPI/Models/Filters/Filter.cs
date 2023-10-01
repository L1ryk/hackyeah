namespace WebAPI.Models;

/// <summary>
/// Represents a single filter.
/// </summary>
public class Filter
{
    /// <summary>
    /// Filter property.
    /// </summary>
    public string Property { get; set; }

    /// <summary>
    /// Filter value.
    /// </summary>
    public object Value { get; set; }
}