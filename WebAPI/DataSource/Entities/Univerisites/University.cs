using System.ComponentModel.DataAnnotations;
using WebAPI.DataSource.Entities.Locations;
using WebAPI.DataSource.Entities.System;

namespace WebAPI.DataSource.Entities.Univerisites;

public class University
{
    [Key]
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string PersonManaging { get; set; }

    public string SupervisoryAuthority { get; set; }

    public string Brand { get; set; }

    public string Type { get; set; }

    public string Status { get; set; }

    public string Regon { get; set; }

    public string TaxId { get; set; }

    public string JudgeRegisterId { get; set; }

    public string Website { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public Country Country { get; set; }

    public Voivodeship Voivodeship { get; set; }

    public City City { get; set; }

    public string PostCode { get; set; }

    public string Street { get; set; }

    public string BuildingNumber { get; set; }

    public string ApartmentNumber { get; set; }

    public string RecruitmentLink { get; set; }

    public string IconId { get; set; }

    public string PdfLink { get; set; }

    public string TercCity { get; set; }

    public string TercDistrict { get; set; }

    public string TercVoivodeship { get; set; }

    public string Epuap { get; set; }

    public DateTime CreatedDate { get; set; }

    public string AvailabilityFormUrl { get; set; }

    public string RecruitmentPageUrl { get; set; }

    public string PromotionalFilmUrl { get; set; }

    public ICollection<UniversityStatistics> Statistics { get; set; }
}
