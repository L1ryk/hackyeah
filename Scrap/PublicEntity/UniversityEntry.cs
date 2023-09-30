using Newtonsoft.Json;

namespace Scrap.PublicEntity;

public class UniversityEntry
{
    [ JsonProperty( PropertyName = "id" ) ]
    public Guid Id { get; set; }


    [ JsonProperty( PropertyName = "name" ) ]
    public string Name { get; set; }
}