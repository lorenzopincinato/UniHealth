using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniHealth.Application.Models;

namespace UniHealth.Application.Repositories
{
    public class AlimentoConsumidoRepository
    {
        public AlimentoConsumidoRepository()
        {
        }

        public List<AlimentoConsumido> GetAlimentosByUserDateAndRefeicao(string cpf, DateTime date, string refeicao)
        {
            using (var _dbContext = new DbUniHealthContext())
            {
                return _dbContext.AlimentoConsumidos
                    .Include("Usuario")
                    .Include("Alimento")
                    .ToList()
                    .Where(x => x.Usuario.CPF == cpf)
                    .Where(x => x.Data.Date == date.Date)
                    .Where(x => x.Refeicao == refeicao)
                    .ToList();
            }
        }

        public void AddAlimentoConsumido(AlimentoConsumido alimentoConsumido)
        {
            using (var _dbContext = new DbUniHealthContext())
            {
                _dbContext.AlimentoConsumidos.Add(alimentoConsumido);
                _dbContext.SaveChanges();
            }
        }

    }
}
