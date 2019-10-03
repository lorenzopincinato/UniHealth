using System.Collections.Generic;
using System.Threading.Tasks;
using UniHealth.Application.Models;

namespace UniHealth.Application.Applications
{
    public interface IUsuarioApplication
    {
        bool CPFExiste(string cpf);
        void CadastrarUsuario(string cpf, string rg, string nome, string senha, string confirmacaoSenha);
        bool LogarUsuario(string cpf, string password);
        void AlterarSenhaUsuario(string cpf, string newPassword);
        void AlterarUsuario(string cpf, string estado, string perfil);
        List<string> GetCPFs();
        List<string> GetEstados();
        List<string> GetPerfis();
        Usuario GetUsuario(string cpf);
    }
}
