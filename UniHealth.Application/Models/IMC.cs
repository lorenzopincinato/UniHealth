using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UniHealth.Application.Models
{
    public class IMC
    {
        [Key]
        public int Id { get; set; }
        public double Peso { get; set; }
        public double Altura { get; set; }
        public DateTime DataCalculo { get; set; }

        [NotMapped]
        public double IMCCalculado {
            get { return Peso / Math.Pow(Altura/100, 2);}
        }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public IMC() { }

        public IMC(double peso, double altura, int usuarioId)
        {
            Peso = peso;
            Altura = altura;
            DataCalculo = DateTime.Now;
            UsuarioId = usuarioId;
        }
    }
}
