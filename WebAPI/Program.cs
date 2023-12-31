using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using NLog;
using WebAPI.DataSource;
using WebAPI.DataSource.Accessors.Interfaces;
using WebAPI.DataSource.Accessors.LocationAccessors;
using WebAPI.DataSource.Accessors.UniversityAccessors;

var logger = LogManager.GetCurrentClassLogger();
var builder = WebApplication.CreateBuilder( args );

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson( options =>
{
    options.SerializerSettings.Converters.Add( new StringEnumConverter( new CamelCaseNamingStrategy() ) );
    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
} );

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var dbConnection = Environment.GetEnvironmentVariable( "DbConnection" );

builder.Services.AddDbContext<ApiDbContext>( options =>
{
    options.UseNpgsql( dbConnection,
        optionsBuilder => optionsBuilder.MigrationsAssembly( typeof(ApiDbContext).Assembly.FullName ) );
} );

// add services
builder.Services.AddScoped<ICityAccessor, CityAccessor>();
builder.Services.AddScoped<IVoivodeshipAccessor, VoivodeshipAccessor>();
builder.Services.AddScoped<IUniversityAccessor, UniversityAccessor>();
builder.Services.AddScoped<ICourseAccessor, CourseAccessor>();
builder.Services.AddScoped<IUniversityCourseAccessor, UniversityCourseAccessor>();
builder.Services.AddScoped<ITagAccessor, TagAccessor>();
builder.Services.AddScoped<IOccupationAccessor, OccupationAccessor>();

var app = builder.Build();

try
{
    using var services = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
    var dbc = services.ServiceProvider.GetService<ApiDbContext>();
    dbc?.Database.Migrate();
}
catch ( Exception ex )
{
    logger.Error( ex, "Problem with DB initialization" );
}


// Configure the HTTP request pipeline.
if ( app.Environment.IsDevelopment() )
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();