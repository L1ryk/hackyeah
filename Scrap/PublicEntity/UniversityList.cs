using Newtonsoft.Json;

namespace Scrap.PublicEntity;

public class UniversityList
{
    [ JsonProperty( PropertyName = "list" ) ]
    public List< UniversityEntry > Entries { get; set; }
}