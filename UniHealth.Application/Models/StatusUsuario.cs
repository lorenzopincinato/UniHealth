using System.ComponentModel.DataAnnotations;

namespace UniHealth.Application.Models
{
    public class StatusUsuario
    {
        [Key]
        public int Id { get; set; }
        public string Estado { get; set; }

        public StatusUsuario() { }
    }
}
