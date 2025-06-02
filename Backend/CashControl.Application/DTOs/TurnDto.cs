namespace CashControl.Application.DTOs
{
    public class TurnDto
    {
        public string Description { get; set; }
        public DateTime DateTurn { get; set; }
        public int CashId { get; set; }
        public int UserGestorId { get; set; }
    }
}