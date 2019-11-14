using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniHealth.Application.Models
{
    public class AlimentoConsumido
    {
        [Key]
        public int Id { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public string Refeicao { get; set; }

        public int AlimentoId { get; set; }
        public Alimento Alimento { get; set; }

        public double UnidadesConsumidas { get; set; }
        public DateTime Data { get; set; }

        [NotMapped]
        public double CaloriasConsumidas { get {return Alimento.CaloriaUnidade * UnidadesConsumidas; } }

        public AlimentoConsumido() { }

        public AlimentoConsumido(Usuario usuario, string refeicao, int alimentoId, double unidadesConsumidas)
        {
            Usuario = usuario;
            Refeicao = refeicao;
            AlimentoId = alimentoId;
            UnidadesConsumidas = unidadesConsumidas;
            Data = DateTime.Today;
        }
    }



    //AlimentoConsumido.Alimento.CaloriaUnidade* AlimentoConsumido.UnidadesConsumidas

    //    alimentosConsumidos.Include("Refeicao").Include("Alimento")
}
