using System;
using System.ComponentModel.DataAnnotations;

namespace CashControl.Domain.Entities;
public class Contract
{
    [Key]
    public int ContractId { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? Service_ServiceId { get; set; }
    public string? StatusContrac_Statusid { get; set; }
    public int? Client_ClientId { get; set; }
    public int? MethodPayment_MethodPaymentId { get; set; }
}
