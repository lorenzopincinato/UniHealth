using System.ComponentModel.DataAnnotations;

namespace UniHealth.Application.Models
{
    public class PerfilUsuario
    {
        [Key]
        public int Id { get; set; }

        public string Tipo { get; set; }
    }
}

