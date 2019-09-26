using System.Threading.Tasks;
using UniHealth.Application.Models;

namespace UniHealth.Application.Repositories
{
    public interface IUsuarioRepository
    {
        Usuario GetUsuarioByCPF(string cpf);

        Task AddUsuarioAsync(Usuario usuario);

        void UpdateUsuario(Usuario usuario);

        Task DeleteUsuarioByCPFAsync(string cpf);
    }
}
