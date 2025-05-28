namespace CashControl.Application.DTOs
{
    public class CrearUsuarioDto
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int RolId { get; set; }
        public int UserCreate { get; set; }
    }
}