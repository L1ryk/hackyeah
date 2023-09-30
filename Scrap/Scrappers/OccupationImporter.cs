using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebAPI.DataSource;
using WebAPI.DataSource.Entities.Univerisites;

namespace Scrap.Scrappers;

public class OccupationImporter
{
    private string _path;

    public OccupationImporter( string path )
    {
        if ( string.IsNullOrEmpty( path ) )
            throw new Exception( "Path is null" );

        _path = path;
    }

    public async Task Import( ApiDbContext db )
    {
        var items = new Dictionary<string, List<string>>();

        using ( StreamReader r = new StreamReader( _path ) )
        {
            string json = await r.ReadToEndAsync();
            items = JsonConvert.DeserializeObject<Dictionary<string, List<string>>>( json );
        }

        foreach ( var item in items )
        {
            var cs = await db.Courses.FirstOrDefaultAsync( c => c.Name.Equals( item.Key ) );

            if ( cs == null )
            {
                Console.WriteLine( $"Cannot find course [{item.Key}]" );
                continue;
            }

            foreach ( var val in item.Value )
            {
                var oc = await db.Occupations.FirstOrDefaultAsync( oc => oc.Name.Equals( val ) ) ??
                         ( await db.Occupations.AddAsync( new Occupation { Name = val } ) ).Entity;

                await db.SaveChangesAsync();

                if ( await db.CourseOccupations.AnyAsync( co => co.Occupation == oc && co.Course == cs ) )
                    continue;

                await db.CourseOccupations.AddAsync( new CourseOccupation
                {
                    Course = cs, Occupation = oc
                } );

                await db.SaveChangesAsync();
            }
        }
    }
}