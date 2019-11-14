using System.Collections.Generic;
using System.Linq;
using UniHealth.Application.Models;

namespace UniHealth.Application.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        protected DbUniHealthContext _dbContext = new DbUniHealthContext();

        public UsuarioRepository()
        {
        }

        public Usuario GetUsuarioByCPF(string cpf)
        {
            return _dbContext.Usuarios.Include("StatusUsuario").Include("PerfilUsuario").FirstOrDefault(x => x.CPF == cpf);
        }

        public Usuario GetUsuarioByRG(string rg)
        {
            return _dbContext.Usuarios.FirstOrDefault(x => x.RG == rg);
        }

        public void AddUsuario(Usuario usuario)
        {
            _dbContext.Usuarios.Add(usuario);
            _dbContext.SaveChanges();
        }

        public void UpdateUsuario(Usuario usuario)
        {
            var usuarioAtualizado = _dbContext.Usuarios.FirstOrDefault(x => x.CPF == usuario.CPF);
            usuarioAtualizado = usuario;

            _dbContext.SaveChanges();
        }

        public List<Usuario> GetAll()
        {
            return _dbContext.Usuarios.ToList();
        }
    }
}
