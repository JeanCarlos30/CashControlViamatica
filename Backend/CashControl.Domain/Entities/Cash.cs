using System;
using System.ComponentModel.DataAnnotations;

namespace CashControl.Domain.Entities;
public class Cash
{
    [Key]
    public int CashId { get; set; }
    [StringLength(50)]
    public string? CashDescription { get; set; }
    [StringLength(1)]
    public string? Active { get; set; }
}
