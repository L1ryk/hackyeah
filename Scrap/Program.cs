using Microsoft.EntityFrameworkCore;
using Scrap.Scrappers;
using WebAPI.DataSource;

using WebAPI.DataSource;
using WebAPI.DataSource.Entities.Locations;
using WebAPI.DataSource.Entities.System;
using WebAPI.DataSource.Entities.Univerisites;

var dbConnectionString = Environment.GetEnvironmentVariable( "DbConnection" );
dbConnectionString = "Host=127.0.0.1;Database=HackYeah;Username=postgres;Password=StrongPassword";
var dbConfigurationBuilder = new DbContextOptionsBuilder< ApiDbContext >();
dbConfigurationBuilder.UseNpgsql( dbConnectionString,
                                  optionsBuilder =>
                                      optionsBuilder.MigrationsAssembly( typeof( ApiDbContext ).Assembly.FullName ) );
var options = dbConfigurationBuilder.Options;
var db = new ApiDbContext( options );

db.Database.Migrate();

var http = new HttpClient();

var sf = new SchoolFetch( http );

var universityList = await sf.GetUniversityList();
if ( universityList == null )
    return;

foreach ( var universityId in universityList )
{
    // university already exists, skipping
    if ( await db.Universities.AnyAsync( u => u.Id == universityId ) )
        continue;

    Console.WriteLine( universityId.ToString() );
    var university = await sf.GetUniversityDetails( universityId );
    if ( university == null )
    {
        Console.WriteLine( $"Unable to read university with id {universityId}" );
        continue;
    }

    var country = await db.Countries.FirstOrDefaultAsync( c => c.Name == university.Country );
    if ( country == null )
    {
        country = new Country
        {
            Name = university.Country ?? string.Empty
        };
        await db.Countries.AddAsync( country );
        await db.SaveChangesAsync();
    }

    // check if voivodeship exists
    var voivodeship = await db.Voivodeships.FirstOrDefaultAsync( v => v.Name == university.Voivodeship );
    if ( voivodeship == null )
    {
        voivodeship = new Voivodeship
        {
            Country = country, Name = university.Voivodeship ?? string.Empty
        };
        await db.Voivodeships.AddAsync( voivodeship );
        await db.SaveChangesAsync();
    }

    // check if city exists
    var city = await db.Cities.FirstOrDefaultAsync( c => c.Voivodeship == voivodeship && c.Name == university.City );
    if ( city == null )
    {
        city = new City
        {
            Voivodeship = voivodeship, Name = university.City ?? string.Empty
        };
        await db.Cities.AddAsync( city );
        await db.SaveChangesAsync();
    }

    await db.Database.BeginTransactionAsync();
    try
    {
        var record = new University
        {
            Name = university.Name ?? string.Empty,
            City = city,
            Voivodeship = voivodeship,
            Brand = university.Brand ?? string.Empty,
            Country = country,
            Email = university.Email ?? string.Empty,
            Regon = university.Regon ?? string.Empty,
            Status = university.Status ?? string.Empty,
            Street = university.Street ?? string.Empty,
            JudgeRegisterId = university.JudgeId ?? String.Empty,
            ApartmentNumber = university.ApartmentNumber ?? String.Empty,
            TaxId = university.TaxId ?? string.Empty,
            Type = university.Type ?? string.Empty,
            Website = university.Website ?? string.Empty,
            CreatedAt = university.CreatedAt.ToUniversalTime(),
            BuildingNumber = university.BuildingNumber ?? string.Empty,
            PostCode = university.PostalCode ?? string.Empty,
            RecruitmentLink = university.RecruitmentLink ?? string.Empty,
            Id = university.Id,
            SupervisoryAuthority = university.Supervisor ?? string.Empty,
            Epuap = string.Empty,
            Phone = String.Empty,
            IconId = string.Empty,
            PdfLink = string.Empty,
            PersonManaging = string.Empty,
            TercCity = string.Empty,
            TercDistrict = string.Empty,
            TercVoivodeship = string.Empty,
            AvailabilityFormUrl = string.Empty,
            RecruitmentPageUrl = string.Empty,
            PromotionalFilmUrl = string.Empty,
        };
        await db.Universities.AddAsync( record );

        // create stats
        foreach ( var stat in university.Statistics )
        {
            await db.UniversityStatistics.AddAsync( new UniversityStatistics
            {
                University = record,
                Year = stat.Year,
                NumberCourse = stat.NumberCourse,
                NumberEmployees = stat.NumberEmployees,
                NumberStudents = stat.NumberStudents
            } );
        }

        // get list of curses
        var courses = await sf.GetCourserForUniversity( universityId );
        if ( courses == null )
            throw new Exception( "Unable to get list of courses" );

        foreach ( var courseItem in courses )
        {
            // skip item if already exists
            if ( await db.UniversityCourses.AnyAsync( uc => uc.Id == courseItem.Id ) )
                continue;

            // get course item
            var course = await db.Courses.FirstOrDefaultAsync( c => c.Name == courseItem.Name );
            if ( course == null )
            {
                course = new Course
                {
                    Name = courseItem.Name
                };
                await db.Courses.AddAsync( course );
            }

            // get course form
            var form = await db.CourseForms.FirstOrDefaultAsync( cf => cf.Name == courseItem.FormLabel );
            if ( form == null )
            {
                form = new CourseForm
                {
                    Name = courseItem.FormLabel
                };
                await db.CourseForms.AddAsync( form );
            }

            // get course level
            var level = await db.CourseLevels.FirstOrDefaultAsync( cl => cl.Name == courseItem.EducationLevel );
            if ( level == null )
            {
                level = new CourseLevel
                {
                    Name = courseItem.EducationLevel
                };
                await db.CourseLevels.AddAsync( level );
            }

            await db.SaveChangesAsync();

            // create relation between course and university
            await db.UniversityCourses.AddAsync( new UniversityCourse
            {
                Id = courseItem.Id,
                Course = course,
                University = record,
                Language = courseItem.Language,
                Profile = courseItem.EducationProfile,
                CourseLevel = level,
                CourseForm = form
            } );

            await db.SaveChangesAsync();
        }

        await db.SaveChangesAsync();

        await db.Database.CommitTransactionAsync();
    }
    catch
    {
        await db.Database.RollbackTransactionAsync();
    }
}

var path = "Z:\\zbiory.txt";
var ti = new TagImporter( path );
await ti.Import( db );