using System.ComponentModel.DataAnnotations;

namespace UniHealth.Application.Models
{
    public class Alimento
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public double CaloriaUnidade { get; set; }
        public string Unidade { get; set; }

        public Alimento() { }

        public Alimento(string nome, double caloriaUnidade, string unidade)
        {
            Nome = nome;
            CaloriaUnidade = caloriaUnidade;
            Unidade = unidade;
        }
    }
}
