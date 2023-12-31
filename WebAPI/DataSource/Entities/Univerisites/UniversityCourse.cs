﻿namespace WebAPI.DataSource.Entities.Univerisites;

public class UniversityCourse : IEntity
{
    public Guid Id { get; set; }

    public University University { get; set; }

    public Course Course { get; set; }

    public string? Language { get; set; }

    public string? Profile { get; set; }

    public CourseLevel CourseLevel { get; set; }

    public CourseForm CourseForm { get; set; }
}