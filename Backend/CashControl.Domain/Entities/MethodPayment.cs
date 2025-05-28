using System;
using System.ComponentModel.DataAnnotations;

public class MethodPayment
{
    [Key]
    public int MethodPaymentId { get; set; }
    [StringLength(50)]
    public string? Description { get; set; }
}
