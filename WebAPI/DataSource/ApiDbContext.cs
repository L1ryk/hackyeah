﻿using Microsoft.EntityFrameworkCore;
using WebAPI.DataSource.Entities.Locations;
using WebAPI.DataSource.Entities.System;
using WebAPI.DataSource.Entities.Univerisites;

namespace WebAPI.DataSource;

public class ApiDbContext : DbContext
{
    #region System

    public DbSet< User > Users { get; set; }

    #endregion

    #region Locations

    public DbSet< Voivodeship > Voivodeships { get; set; }

    public DbSet< City > Cities { get; set; }

    public DbSet< Country > Countries { get; set; }

    #endregion

    #region Universities

    public DbSet< University > Universities { get; set; }

    public DbSet< UniversityStatistics > UniversityStatistics { get; set; }

    public DbSet< Course > Courses { get; set; }

    public DbSet< CourseTag > CourseTags { get; set; }

    public DbSet< CourseForm > CourseForms { get; set; }

    public DbSet< CourseLevel > CourseLevels { get; set; }

    public DbSet< UniversityCourse > UniversityCourses { get; set; }

    public DbSet< Tag > Tags { get; set; }

    public DbSet< Occupation > Occupations { get; set; }

    public DbSet< CourseOccupation > CourseOccupations { get; set; }

    #endregion

    #region constructors and boilerplate

    public ApiDbContext( DbContextOptions< ApiDbContext > options )
        : base( options )
    {
    }

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        base.OnModelCreating( modelBuilder );
    }

    protected override void OnConfiguring( DbContextOptionsBuilder options )
    {
    }

    #endregion
}