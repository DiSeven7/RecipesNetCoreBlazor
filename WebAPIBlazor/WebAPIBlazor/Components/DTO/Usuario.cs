namespace WebAPIBlazor.Components.DTO
{
    public class Usuario
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Contraseña { get; set; }

        public bool Verificado { get; set; } = false;

        public Usuario() { }

        public Usuario(int id, string email, string contraseña, bool verificado)
        {
            Id = id;
            Email = email;
            Contraseña = contraseña;
            Verificado = verificado;
        }
    }
}
