using Microsoft.EntityFrameworkCore;
using Scrap.Scrappers;
using WebAPI.DataSource;
using WebAPI.DataSource.Entities.Locations;
using WebAPI.DataSource.Entities.System;
using WebAPI.DataSource.Entities.Univerisites;

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
            Name = university.Country
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
            Country = country,
            Name = university.Voivodeship
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
            Voivodeship = voivodeship, Name = university.City
        };
        await db.Cities.AddAsync( city );
        await db.SaveChangesAsync();
    }

    await db.Universities.AddAsync( new University
    {
        Name = university.Name,
        City = city,
        Voivodeship = voivodeship,
        Brand = university.Brand,
        Country = country,
        Email = university.Email,
        Regon = university.Regon,
        Status = university.Status,
        Street = university.Street,
        JudgeRegisterId = university.JudgeId,
        ApartmentNumber = university.ApartmentNumber,
        TaxId = university.TaxId,
        Type = university.Type,
        Website = university.Website,
        CreatedAt = university.CreatedAt,
        BuildingNumber = university.BuildingNumber,
        PostCode = university.PostalCode,
        RecruitmentLink = university.RecruitmentLink,
        Id = university.Id
    } );
    await db.SaveChangesAsync();
}