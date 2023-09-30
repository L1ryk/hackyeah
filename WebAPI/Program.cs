using Microsoft.EntityFrameworkCore;
using NLog;
using WebAPI.DataSource;
using WebAPI.DataSource.Accessors.LocationAccessors;

var logger = LogManager.GetCurrentClassLogger();
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var dbConnection = Environment.GetEnvironmentVariable("DbConnection");

builder.Services.AddDbContext<ApiDbContext>(options =>
{
    options.UseNpgsql(dbConnection,
        optionsBuilder => optionsBuilder.MigrationsAssembly(typeof(ApiDbContext).Assembly.FullName));
});

// add services
builder.Services.AddScoped<ICityAccessor, CityAccessor>();

var app = builder.Build();

try
{
    using var services = app.Services.GetRequiredService<IServiceScopeFactory>().CreateScope();
    var dbc = services.ServiceProvider.GetService<ApiDbContext>();
    dbc?.Database.Migrate();
}
catch (Exception ex)
{
    logger.Error(ex, "Problem with DB initialization");
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();