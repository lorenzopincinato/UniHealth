using System.Threading.Tasks;
using UniHealth.Application.Models;

namespace UniHealth.Application.Repositories
{
    public interface IPerfilUsuarioRepository
    {
        PerfilUsuario GetPerfilUsuarioByTipoAsync(string tipo);
    }
}
