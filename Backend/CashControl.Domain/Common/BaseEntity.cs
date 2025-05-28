namespace CashControl.Domain.Common;

public abstract class BaseEntity
{
    public DateTime CreationDate { get; set; }
    public int UserCreate { get; set; }
}