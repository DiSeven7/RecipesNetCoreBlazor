using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PruebasAPIBlazor.Models
{
    [Table("Usuarios")]
    public class Usuario
    {
        public int Id { get; set; }

        public required string Email { get; set; }

        public required string Contraseña { get; set; }

        public bool Verificado { get; set; } = false;

    }
}
