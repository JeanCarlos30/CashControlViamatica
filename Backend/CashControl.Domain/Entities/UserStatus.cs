using System;
using System.ComponentModel.DataAnnotations;

public class UserStatus
{
    [Key]
    public string StatusId { get; set; }
    [StringLength(50)]
    public string? Description { get; set; }
}
