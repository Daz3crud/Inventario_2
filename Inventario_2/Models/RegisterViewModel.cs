namespace Inventario_2.Models
{
    public class RegisterViewModel
    {
        public required string Username { get; set; }
        public required string Email { get; set; }
        public string Password { get; set; }
        public required string ConfirmPassword { get; set; }
    }
}
