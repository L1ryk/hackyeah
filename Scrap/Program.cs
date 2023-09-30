using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Scrap.Scrappers;
using WebAPI.DataSource;

var db = new ApiDbContext( new DbContextOptions< ApiDbContext >() );

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