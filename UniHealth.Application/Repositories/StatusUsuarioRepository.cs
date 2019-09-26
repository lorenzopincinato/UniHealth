using System.Linq;
using System.Threading.Tasks;
using UniHealth.Application.Models;

namespace UniHealth.Application.Repositories
{
    public class StatusUsuarioRepository : IStatusUsuarioRepository
    {
        protected DbUniHealthContext _dbContext;

        public StatusUsuarioRepository(DbUniHealthContext dataContext)
        {
            _dbContext = dataContext;
        }

        public StatusUsuario GetStatusUsuarioByEstadoAsync(string estado)
        {
            return _dbContext.StatusUsuarios.FirstOrDefault(x => x.Estado == estado);
        }
    }
}
