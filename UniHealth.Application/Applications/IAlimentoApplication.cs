using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniHealth.Application.Applications
{
    public interface IAlimentoApplication
    {
        void AddAlimento(string nome, double caloriaUnidade, string unidade);
    }
}
