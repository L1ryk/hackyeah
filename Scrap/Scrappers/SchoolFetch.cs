using Newtonsoft.Json;
using Scrap.PublicEntity;
using System.Text;

namespace Scrap.Scrappers;

public class SchoolFetch
{
    private readonly HttpClient client;
    private const    string urlSearch = "https://aplikacje.edukacja.gov.pl/api/education-unit-search/school";
    private const    string urlSchoolDetails = "https://aplikacje.edukacja.gov.pl/api/education-unit-search/school/{0}";

    private const string urlUniversityList =
        "https://aplikacje.edukacja.gov.pl/api/internal-data-hub/public/opi/university/dictionary/university";

    private const string urlUniversityDetails =
        "https://aplikacje.edukacja.gov.pl/api/internal-data-hub/public/opi/university/{0}";

    private const string urlCourses =
        "https://aplikacje.edukacja.gov.pl/api/internal-data-hub/public/opi/university/{0}/course";

    public SchoolFetch( HttpClient client )
    {
        this.client = client;
    }

    public async Task< int[]? > GetListOfSchoolIds()
    {
        using var response = await client.SendAsync( new HttpRequestMessage( HttpMethod.Post, urlSearch )
        {
            Content = new StringContent(
                "[{\"filterKey\":\"subjectTypeName\",\"value\":\"\",\"values\":[\"Szkoła ponadpodstawowa\",\"Zespół szkół i placówek oświatowych\"]}]",
                Encoding.UTF8,
                "application/json" )
        } );
        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        return JsonConvert.DeserializeObject< List< int > >( json )?.ToArray();
    }

    public async Task< SchoolInfo? > GetSchoolDetails( int id )
    {
        var url = string.Format( urlSchoolDetails, id.ToString() );
        using var response = await client.SendAsync( new HttpRequestMessage( HttpMethod.Get, url ) );
        return JsonConvert.DeserializeObject< SchoolInfo >( await response.Content.ReadAsStringAsync() );
    }

    public async Task< Guid[]? > GetUniversityList()
    {
        var response = await client.GetStringAsync( urlUniversityList );

        return JsonConvert.DeserializeObject< UniversityList >( response )?.Entries.Select( e => e.Id ).ToArray();
    }

    public async Task< University? > GetUniversityDetails( Guid id )
    {
        var url = string.Format( urlUniversityDetails, id.ToString() );

        var response = await client.GetStringAsync( url );

        return JsonConvert.DeserializeObject< University >( response );
    }

    public async Task< Course[]? > GetCourserForUniversity( Guid id )
    {
        var url = string.Format( urlCourses, id.ToString() );
        var response = await client.GetStringAsync( url );

        return JsonConvert.DeserializeObject< CourseList >( response )?.List.ToArray();
    }
}