using System;
using System.ComponentModel.DataAnnotations;

namespace CashControl.Domain.Entities;
public class Rol
{
    [Key]
    public int RolId { get; set; }
    [StringLength(50)]
    public string? RolName { get; set; }
}
