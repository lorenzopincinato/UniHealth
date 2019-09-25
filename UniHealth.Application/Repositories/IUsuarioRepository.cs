using System.Threading.Tasks;
using UniHealth.Application.Models;

namespace UniHealth.Application.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetUsuarioByCPFAsync(string cpf);

        Task AddUsuarioAsync(Usuario usuario);

        Task UpdateUsuarioAsync(Usuario usuario);

        Task DeleteUsuarioByCPFAsync(string cpf);
    }
}
