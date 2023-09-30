namespace Scrap.PublicEntity;

public class Course
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string FormLabel { get; set; }

    public string EducationLevel { get; set; }

    public string? Language { get; set; }

    public string? EducationProfile { get; set; }

    public List< string > RequiredSubjects { get; set; }

    public List< string > RequiredSubjectsToSelect { get; set; }
}