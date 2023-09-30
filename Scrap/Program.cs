using Microsoft.EntityFrameworkCore;
using Scrap.Scrappers;
using WebAPI.DataSource;

var dbConnectionString = Environment.GetEnvironmentVariable( "DbConnection" );
var dbConfigurationBuilder = new DbContextOptionsBuilder< ApiDbContext >();
dbConfigurationBuilder.UseNpgsql( dbConnectionString,
                                  optionsBuilder =>
                                      optionsBuilder.MigrationsAssembly( typeof( ApiDbContext ).Assembly.FullName ) );
var options = dbConfigurationBuilder.Options;
var db = new ApiDbContext( options );

var http = new HttpClient();

var sf = new SchoolFetch( http );

var universityList = await sf.GetUniversityList();
if ( universityList == null )
    return;

foreach ( var universityId in universityList )
{
    Console.WriteLine( universityId.ToString() );
    Console.Write( await sf.GetUniversityDetails( universityId )
    );
    return;
}