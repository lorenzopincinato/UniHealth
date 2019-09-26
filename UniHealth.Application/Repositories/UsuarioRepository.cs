using System.Linq;
using System.Threading.Tasks;
using UniHealth.Application.Models;

namespace UniHealth.Application.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        protected DbUniHealthContext _dbContext;

        public UsuarioRepository(DbUniHealthContext dataContext)
        {
            _dbContext = dataContext;
        }

        public Usuario GetUsuarioByCPF(string cpf)
        {
            return _dbContext.Usuarios.FirstOrDefault(x => x.CPF == cpf);
        }

        public async Task AddUsuarioAsync(Usuario usuario)
        {
            _dbContext.Usuarios.Add(usuario);
            await _dbContext.SaveChangesAsync();
        }

        public void UpdateUsuario(Usuario usuario)
        {
            var usuarioAtualizado = _dbContext.Usuarios.FirstOrDefault(x => x.CPF == usuario.CPF);
            usuarioAtualizado = usuario;

            _dbContext.SaveChanges();
        }

        public async Task DeleteUsuarioByCPFAsync(string cpf)
        {
            _dbContext.Usuarios.Where(x => x.CPF == cpf).FirstOrDefault();
            await _dbContext.SaveChangesAsync();
        }
    }
}
