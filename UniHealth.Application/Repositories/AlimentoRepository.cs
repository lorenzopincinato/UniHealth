using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniHealth.Application.Models;

namespace UniHealth.Application.Repositories
{
    public class AlimentoRepository : IAlimentoRepository
    {
        public void AddAlimento(Alimento alimento)
        {
            using (var _dbContext = new DbUniHealthContext())
            {
                _dbContext.Alimentos.Add(alimento);
                _dbContext.SaveChanges();
            }
        }

        public List<Alimento> GetAllAlimentos()
        {
            using (var _dbContext = new DbUniHealthContext())
            {
                return _dbContext.Alimentos.ToList();
            }
        }
    }
}
