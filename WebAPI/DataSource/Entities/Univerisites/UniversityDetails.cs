namespace WebAPI.DataSource.Entities.Univerisites;

public class UniversityDetails
{
    public string Id { get; set; }

    public string UniversityName { get; set; }

    public string PersonManaging { get; set; }
    
    public string SupervisoryAuthority { get; set; }
    
    public string Brand { get; set; }
    
    public string Typ { get; set; }
    
    public string Status { get; set; }
    
    public string Regon { get; set; }
    
    public string Nip { get; set; }
    
    public object Krs { get; set; }
    
    public string Www { get; set; }
    
    public string Email { get; set; }
    
    public string Phone { get; set; }
    
    public string Country { get; set; }
    
    public string Voivodeship { get; set; }
    
    public string City { get; set; }
    
    public string PostCode { get; set; }
    
    public string Street { get; set; }
    
    public string Number { get; set; }
    
    public object ApartmentNumber { get; set; }
    
    public string RecruitmentLink { get; set; }
    
    public string IconId { get; set; }
    
    public object PdfLink { get; set; }
    
    public string TercCity { get; set; }
    
    public string TercDistrict { get; set; }
    
    public string TercVoivodeship { get; set; }
    
    public string Epuap { get; set; }
    
    public string CreatedDate { get; set; }
    
    public object AvailabilityFormUrl { get; set; }
    
    public string RecruitmentPageUrl { get; set; }
    
    public string PromotionalFilmUrl { get; set; }
    
    public List<UniversityStatistics> Statistics { get; set; }
}
