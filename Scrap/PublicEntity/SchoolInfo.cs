using Newtonsoft.Json;

namespace Scrap.PublicEntity;

public class SchoolInfo
{
    [ JsonProperty( PropertyName = "schoolId" ) ]
    public int Id { get; set; }

    [ JsonProperty( PropertyName = "schoolName" ) ]
    public string Name { get; set; }

    [ JsonProperty( PropertyName = "schoolShortName" ) ]
    public string ShortName { get; set; }

    [ JsonProperty( PropertyName = "nip" ) ]
    public string TaxId { get; set; }

    [ JsonProperty( PropertyName = "regon" ) ]
    public string JudgeId { get; set; }

    [ JsonProperty( PropertyName = "rspoNumber" ) ]
    public string RspoNumber { get; set; }

    [ JsonProperty( PropertyName = "subjectTypeName" ) ]
    public string TypeName { get; set; }

    [ JsonProperty( PropertyName = "townName" ) ]
    public string City { get; set; }

    [ JsonProperty( PropertyName = "voivodeshipName" ) ]
    public string VoivodeshipName { get; set; }

    [ JsonProperty( PropertyName = "streetName" ) ]
    public string StreetName { get; set; }

    [ JsonProperty( PropertyName = "schoolBuildingNumber" ) ]
    public string BuildingNumber { get; set; }

    [ JsonProperty( PropertyName = "schoolApartmentNumber" ) ]
    public string ApartmentNumber { get; set; }

    [ JsonProperty( PropertyName = "schoolPostCode" ) ]
    public string PostalCode { get; set; }

    [ JsonProperty( PropertyName = "schoolPostTownName" ) ]
    public string PostalCity { get; set; }

    [ JsonProperty( PropertyName = "schoolEmail" ) ]
    public string Email { get; set; }

    [ JsonProperty( PropertyName = "schoolWebPage" ) ]
    public string Website { get; set; }

    [ JsonProperty( PropertyName = "geolocationLatitude" ) ]
    public float Latitude { get; set; }

    [ JsonProperty( PropertyName = "geolocationLongitude" ) ]
    public float Longitude { get; set; }

    [ JsonProperty( PropertyName = "creationDate" ) ]
    public DateTime CreationDate { get; set; }
}