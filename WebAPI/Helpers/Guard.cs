namespace WebAPI.Helpers;

/// <summary>
/// A set of guard utility methods.
/// </summary>
public class Guard
{
    /// <summary>
    /// Ensure that the given value isn't a null one.
    /// </summary>
    /// <param name="value">Value to check.</param>
    /// <exception cref="Exception">Given value turned out to be a null.</exception>
    public static void IsNotNull( object value )
    {
        if ( value == null )
            throw new Exception( $"Value cannot be null! [{nameof(value)}]" );
    }

    /// <summary>
    /// Ensure that the given string isn't null or empty.
    /// </summary>
    /// <param name="value">String to check.</param>
    /// <exception cref="Exception">Given string turned out to be null or empty.</exception>
    public static void IsNotNull( string value )
    {
        if ( string.IsNullOrEmpty( value ) )
            throw new Exception( $"Value cannot be null or empty! {nameof(value)}" );
    }
}