using UniHealth.Application.Repositories;

namespace UniHealth.Application.Applications
{
    public class UsuarioApplication : IUsuarioApplication
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioApplication(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
    }
}
