using System.Collections.Generic;
using System.Threading.Tasks;
using UniHealth.Application.Models;

namespace UniHealth.Application.Repositories
{
    public interface IUsuarioRepository
    {
        Usuario GetUsuarioByCPF(string cpf);
        Usuario GetUsuarioByRG(string rg);
        void AddUsuario(Usuario usuario);
        void UpdateUsuario(Usuario usuario);
        List<Usuario> GetAll();
    }
}
