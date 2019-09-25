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

        public async Task<Usuario> GetUsuarioByCPFAsync(string cpf)
        {
            return await _dbContext.Usuarios.FindAsync(cpf);
        }

        public async Task AddUsuarioAsync(Usuario usuario)
        {
            _dbContext.Usuarios.Add(usuario);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUsuarioAsync(Usuario usuario)
        {
            var usuarioAtualizado = await _dbContext.Usuarios.FindAsync(usuario.CPF);
            usuarioAtualizado = usuario;

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUsuarioByCPFAsync(string cpf)
        {
            _dbContext.Usuarios.Where(x => x.CPF == cpf).FirstOrDefault();
            await _dbContext.SaveChangesAsync();
        }
    }
}
