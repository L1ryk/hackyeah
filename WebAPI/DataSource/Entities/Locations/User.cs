using System.ComponentModel.DataAnnotations;

namespace WebAPI.DataSource.Entities.System;

public class User
{
    [Key]
    public Guid Id { get; set; }
}