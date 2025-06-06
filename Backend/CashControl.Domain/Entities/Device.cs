using System;
using System.ComponentModel.DataAnnotations;

namespace CashControl.Domain.Entities;
public class Device
{
    [Key]
    public int DeviceId { get; set; }
    [StringLength(50)]
    public string? DeviceName { get; set; }
    public int? Service_ServiceId { get; set; }
}
