using Newtonsoft.Json;
using Scrap.PublicEntity;

namespace Scrap.Scrappers;

public class LocationFetch
{
    private readonly HttpClient client;
    private const    string     urlGetVoivodeships = "https://aplikacje.edukacja.gov.pl/api/teryt/v1/terc/voivodeships";

    public LocationFetch( HttpClient client )
    {
        this.client = client;
    }

    public async Task< string[]? > GetVoivodeships()
    {
        using var response =
            await client.GetAsync( "https://aplikacje.edukacja.gov.pl/api/teryt/v1/terc/voivodeships" );

        response.EnsureSuccessStatusCode();


        var content = JsonConvert.DeserializeObject< VoivodeshipList >( await response.Content.ReadAsStringAsync() );
        return content?.Items.Select( i => i.Name ).ToArray();
    }
}