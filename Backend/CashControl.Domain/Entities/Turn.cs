using System;
using System.ComponentModel.DataAnnotations;

public class Turn
{
    [Key]
    public int TurnId { get; set; }
    [Required, StringLength(7)]
    public string Description { get; set; }
    public DateTime? DateTurn { get; set; }
    public int? Cash_CashId { get; set; }
    public int? UserGestorId { get; set; }
}
