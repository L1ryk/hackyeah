using Newtonsoft.Json;

namespace Scrap.PublicEntity;

public class University
{
    public Guid Id { get; set; }

    [ JsonProperty( PropertyName = "universityName" ) ]
    public string Name { get; set; }

    [ JsonProperty( PropertyName = "supervisoryAuthority" ) ]
    public string Supervisor { get; set; }

    [ JsonProperty( PropertyName = "brand" ) ]
    public string Brand { get; set; }

    [ JsonProperty( PropertyName = "typ" ) ]
    public string Type { get; set; }

    [ JsonProperty( PropertyName = "status" ) ]
    public string Status { get; set; }

    [ JsonProperty( PropertyName = "regon" ) ]
    public string Regon { get; set; }

    [ JsonProperty( PropertyName = "nip" ) ]
    public string TaxId { get; set; }

    [ JsonProperty( PropertyName = "krs" ) ]
    public string JudgeId { get; set; }

    [ JsonProperty( PropertyName = "www" ) ]
    public string Website { get; set; }

    [ JsonProperty( PropertyName = "email" ) ]
    public string Email { get; set; }

    [ JsonProperty( PropertyName = "country" ) ]
    public string Country { get; set; }

    [ JsonProperty( PropertyName = "voivodeship" ) ]
    public string Voivodeship { get; set; }

    [ JsonProperty( PropertyName = "city" ) ]
    public string City { get; set; }

    [ JsonProperty( PropertyName = "postCode" ) ]
    public string PostalCode { get; set; }

    [ JsonProperty( PropertyName = "street" ) ]
    public string Street { get; set; }

    [ JsonProperty( PropertyName = "number" ) ]
    public string BuildingNumber { get; set; }

    [ JsonProperty( PropertyName = "apartmentNumber" ) ]
    public string ApartmentNumber { get; set; }

    [ JsonProperty( PropertyName = "recruitmentLink" ) ]
    public string RecruitmentLink { get; set; }

    [ JsonProperty( PropertyName = "createdDate" ) ]
    public DateTime CreatedAt { get; set; }

    [ JsonProperty( PropertyName = "statistics" ) ]
    public List<UniversityStatistics> Statistics { get; set; }
}