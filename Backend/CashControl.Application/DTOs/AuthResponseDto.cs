namespace CashControl.Application.DTOs
{
    public class AuthResponseDto
    {
        public string UserName { get; set; }
        public string Role { get; set; }
        public string Jwt { get; set; }
        public int ExpireDate { get; set; }
        public List<MenuOptionDto> Menu { get; set; } = new();
        public string? RoleDescripcion { get; set; }
    }
}