using System;
using System.ComponentModel.DataAnnotations;

public class Rol
{
    [Key]
    public int RolId { get; set; }
    [StringLength(50)]
    public string? RolName { get; set; }
}
