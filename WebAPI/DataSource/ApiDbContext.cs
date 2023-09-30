using Microsoft.EntityFrameworkCore;
using WebAPI.DataSource.Entities.System;

namespace WebAPI.DataSource;

public class ApiDbContext : DbContext
{
    #region System

    public DbSet< User > Users { get; set; }

    #endregion

    #region Locations

    public DbSet< Voivodeship > Voivodeships { get; set; }

    public DbSet< City > Cities { get; set; }

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