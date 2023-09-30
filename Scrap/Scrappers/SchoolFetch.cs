using WebAPI.DataSource;

namespace Scrap.Scrappers;

public class SchoolFetch
{
    private readonly ApiDbContext _db;
    private const    string       UrlSearch = "https://aplikacje.edukacja.gov.pl/api/education-unit-search/school";

    public SchoolFetch( ApiDbContext db )
    {
        _db = db;
    }
    
    public void a(){}
}