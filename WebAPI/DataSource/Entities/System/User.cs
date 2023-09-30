using System.ComponentModel.DataAnnotations;

namespace WebAPI.DataSource.Entities.System;

public class User : IEntity
{
    [Key]
    public Guid Id { get; set; }
}