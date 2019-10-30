using System.Linq;
using UniHealth.Application.Models;

namespace UniHealth.Application.Repositories
{
    public class IMCRepository : IIMCRepository
    {
        public IMCRepository()
        {
        }

        public void AddIMC(IMC imc)
        {
            using (var _dbContext = new DbUniHealthContext())
            {
                _dbContext.IMCs.Add(imc);
                _dbContext.SaveChanges();
            }
        }

        public IMC GetLastIMC(string cpf)
        {
            using (var _dbContext = new DbUniHealthContext())
            {
                return _dbContext.IMCs.Include("Usuario").ToList().Where(x => x.Usuario.CPF == cpf).OrderByDescending(x => x.DataCalculo).FirstOrDefault();
            }
        }
    }
}
