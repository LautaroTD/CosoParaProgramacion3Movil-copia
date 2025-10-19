namespace CosoParaProgramacion3Movil.Models
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;
        public string Imagen { get; set; } = string.Empty;
    }
}

