using System;
using System.ComponentModel.DataAnnotations;

public class Attention
{
    [Key]
    public int AttentionId { get; set; }
    public int? Turn_TurnId { get; set; }
    public int? Client_ClientId { get; set; }
    public int? AttentionType_AttentionTypeId { get; set; }
    public string? AttentionStatus_StatusId { get; set; }
}
