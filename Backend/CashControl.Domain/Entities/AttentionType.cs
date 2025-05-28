using System;
using System.ComponentModel.DataAnnotations;

public class AttentionType
{
    [Key]
    public int AttentionTypeId { get; set; }
    [StringLength(30)]
    public string? Description { get; set; }
    [StringLength(2)]
    public string? FormatoTurno { get; set; }
}
