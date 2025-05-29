using System;
using System.ComponentModel.DataAnnotations;

namespace CashControl.Domain.Entities;
public class UserCash
{
    [Key]
    public int SystemUser_UserId { get; set; }
    [Key]
    public int Cash_CashId { get; set; }
}
