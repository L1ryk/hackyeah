using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WebAPI.DataSource;
using WebAPI.DataSource.Entities.Univerisites;

namespace Scrap.Scrappers;

public class TagImporter
{
    private readonly string path;

    public TagImporter( string path )
    {
        this.path = path;
        if ( !File.Exists( this.path ) )
            throw new Exception( "File not exists" );
    }

    public async Task Import( ApiDbContext db )
    {
        var lines = await File.ReadAllLinesAsync( this.path );
        foreach ( string line in lines )
        {
            try
            {
                var fixedLine = line.TrimEnd( ',' );
                var courseName = fixedLine[ ..( line.IndexOf( '[' ) - 2 ) ].Trim();
                var tags = JsonConvert.DeserializeObject< string[] >( fixedLine[ fixedLine.IndexOf( '[' ).. ] );
                var course = await db.Courses.FirstOrDefaultAsync( c => c.Name.ToLower() == courseName.ToLower() );
                if ( course == null )
                    throw new Exception( $"Course {courseName} not found" );

                foreach ( string tagName in tags )
                {
                    var tag = await db.Tags.FirstOrDefaultAsync( t => t.Name == tagName );
                    if ( tag == null )
                    {
                        tag = new Tag
                        {
                            Name = tagName
                        };
                        await db.Tags.AddAsync( tag );
                    }

                    if ( !await db.CourseTags.AnyAsync( ct => ct.Tag == tag && ct.Course == course ) )
                    {
                        await db.CourseTags.AddAsync( new CourseTag
                        {
                            Course = course, Tag = tag
                        } );
                    }
                }

                await db.SaveChangesAsync();
            }
            catch ( Exception e )
            {
                Console.WriteLine( e.Message );
                Console.WriteLine( $"ERROR: {line}" );
            }
        }
    }
}