using System;
using System.ComponentModel.DataAnnotations;

public class Client
{
    [Key]
    public int ClientId { get; set; }
    [StringLength(50)]
    public string? Name { get; set; }
    [StringLength(50)]
    public string? LastName { get; set; }
    [Required, StringLength(13)]
    public string Identification { get; set; }
    [StringLength(120)]
    public string? Email { get; set; }
    [StringLength(13)]
    public string? PhoneNumber { get; set; }
    [StringLength(100)]
    public string? Address { get; set; }
    [StringLength(100)]
    public string? ReferenceAddress { get; set; }
}
