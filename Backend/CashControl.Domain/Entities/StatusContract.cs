using System;
using System.ComponentModel.DataAnnotations;

namespace CashControl.Domain.Entities;
public class StatusContract
{
    [Key]
    public string StatusId { get; set; }
    [StringLength(100)]
    public string? Description { get; set; }
}
