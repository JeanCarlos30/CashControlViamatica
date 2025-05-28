using System;
using System.ComponentModel.DataAnnotations;

public class Service
{
    [Key]
    public int ServiceId { get; set; }
    [StringLength(100)]
    public string? ServiceName { get; set; }
    [StringLength(150)]
    public string? ServiceDescription { get; set; }
    public decimal? Price { get; set; }
}
