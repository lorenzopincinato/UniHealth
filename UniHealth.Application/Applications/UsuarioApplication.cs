using System;
using System.Threading.Tasks;
using UniHealth.Application.Models;
using UniHealth.Application.Repositories;

namespace UniHealth.Application.Applications
{
    public class UsuarioApplication : IUsuarioApplication
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IStatusUsuarioRepository _statusUsuarioRepository;
        private readonly IPerfilUsuarioRepository _perfilUsuarioRepository;

        public UsuarioApplication(IUsuarioRepository usuarioRepository, IStatusUsuarioRepository statusUsuarioRepository, IPerfilUsuarioRepository perfilUsuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
            _statusUsuarioRepository = statusUsuarioRepository;
            _perfilUsuarioRepository = perfilUsuarioRepository;
        }

        public async Task CreateUsuario(string cpf, string rg, string nome, string senha)
        {
            var statusUsuario = _statusUsuarioRepository.GetStatusUsuarioByEstadoAsync("Normal");
            var perfilUsuario = _perfilUsuarioRepository.GetPerfilUsuarioByTipoAsync("Comum");

            var usuario = new Usuario(cpf, rg, nome, senha, DateTime.Now, statusUsuario, perfilUsuario);

            await _usuarioRepository.AddUsuarioAsync(usuario);
        }

        public bool CPFExists(string cpf)
        {
            var usuario = _usuarioRepository.GetUsuarioByCPF(cpf);

            if (usuario != null)
                return true;

            return false;
        }

        public bool LoginUser(string cpf, string passowrd)
        {
            var usuario = _usuarioRepository.GetUsuarioByCPF(cpf);

            if (usuario == null)
                return false;

            if (usuario.Senha == passowrd)
            {
                return true;
            }

            return false;
        }

        public void UpdatePassword(string cpf, string newPassword)
        {
            var usuario = _usuarioRepository.GetUsuarioByCPF(cpf);

            usuario.Senha = newPassword;

            _usuarioRepository.UpdateUsuario(usuario);
        }
    }
}
