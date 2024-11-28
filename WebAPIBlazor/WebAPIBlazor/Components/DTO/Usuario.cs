using System.ComponentModel.DataAnnotations;

namespace WebAPIBlazor.Components.DTO
{
    public class Usuario
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo email es obligatorio")]
        [EmailAddress(ErrorMessage = "El email indicado no es válido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo contraseña es obligatorio")]
        [Length(6, 500, ErrorMessage = "La contraseña debe tener entre 6 y 50 caracteres")]
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
