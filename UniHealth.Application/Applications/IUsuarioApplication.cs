using System.Threading.Tasks;

namespace UniHealth.Application.Applications
{
    public interface IUsuarioApplication
    {
        bool CPFExiste(string cpf);
        Task CadastrarUsuario(string cpf, string rg, string nome, string senha);
        bool LogarUsuario(string cpf, string password);
        void AlterarSenhaUsuario(string cpf, string newPassword);
    }
}
