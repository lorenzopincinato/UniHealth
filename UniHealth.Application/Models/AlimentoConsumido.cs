using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniHealth.Application.Models
{
    class AlimentoConsumido
    {
        [Key]
        int Id;

        string CPFUsuario;
        Usuario Usuario;

        int IdRefeicao;
        Refeicao Refeicao;

        int IdAlimento;
        Alimento Alimento;

        int UnidadesConsumidas;
        DateTime Data;
    }

    //AlimentoConsumido.Alimento.CaloriaUnidade* AlimentoConsumido.UnidadesConsumidas

    //    alimentosConsumidos.Include("Refeicao").Include("Alimento")
}
