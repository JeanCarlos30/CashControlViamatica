using System;
using System.ComponentModel.DataAnnotations;

namespace CashControl.Domain.Entities;
public class SystemUser
{
    [Key]
    public int UserId { get; set; }
    [Required, StringLength(50)]
    public string UserName { get; set; }
    [Required, StringLength(100)]
    public string Email { get; set; }
    [Required, StringLength(256)]
    public string Password { get; set; }
    public int? Rol_RolId { get; set; }
    public Rol? Rol { get; set; }
    public DateTime? CreationDate { get; set; }
    public int? UserCreate { get; set; }
    public int? UserApproval { get; set; }
    public DateTime? DateApproval { get; set; }
    public string? UserStatus_StatusId { get; set; }
}
