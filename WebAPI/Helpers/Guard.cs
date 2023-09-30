namespace WebAPI.Helpers;

public class Guard
{
    public static void IsNotNull( object value )
    {
        if ( value == null )
            throw new Exception( $"Value cannot be null! [{nameof(value)}]" );
    }

    public static void IsNotNull( string value )
    {
        if ( string.IsNullOrEmpty( value ) )
            throw new Exception( $"Value cannot be null or empty! {nameof(value)}" );
    }
}