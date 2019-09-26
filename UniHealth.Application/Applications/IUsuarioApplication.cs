using System.Threading.Tasks;

namespace UniHealth.Application.Applications
{
    public interface IUsuarioApplication
    {
        bool CPFExists(string cpf);
        Task CreateUsuario(string cpf, string rg, string nome, string senha);
        bool LoginUser(string cpf, string password);
        void UpdatePassword(string cpf, string newPassword);
    }
}
