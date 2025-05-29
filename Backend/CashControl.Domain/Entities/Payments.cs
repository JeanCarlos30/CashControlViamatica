using System;
using System.ComponentModel.DataAnnotations;

namespace CashControl.Domain.Entities;
public class Payments
{
    [Key]
    public int PaymentId { get; set; }
    public DateTime? PaymentDate { get; set; }
    public int? Client_ClientId { get; set; }
}
