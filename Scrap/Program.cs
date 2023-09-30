using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Scrap.Scrappers;
using WebAPI.DataSource;

var db = new ApiDbContext( new DbContextOptions< ApiDbContext >() );

var http = new HttpClient();

/*var sf = new SchoolFetch( http );

var ids = await sf.GetListOfSchoolIds();
if ( ids == null )
    return;

foreach ( var schoolId in ids )
{
    var school = await sf.GetSchoolDetails( schoolId );
    Console.WriteLine( JsonConvert.SerializeObject( school ) );
    return;
}*/

var locationFetch = new LocationFetch( http );
var voivodeships = await locationFetch.GetVoivodeships();

foreach ( var x in voivodeships )
{
    Console.WriteLine( x );
}