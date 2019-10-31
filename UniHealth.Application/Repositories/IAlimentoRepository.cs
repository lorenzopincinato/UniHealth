using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniHealth.Application.Models;

namespace UniHealth.Application.Repositories
{
    public interface IAlimentoRepository
    {
        void AddAlimento(Alimento alimento);
        List<Alimento> GetAllAlimentos();
    }
}
