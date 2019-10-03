using System.Windows;
using UniHealth.Application.Applications;

namespace UniHealth
{
    /// <summary>
    /// Interaction logic for Usuario.xaml
    /// </summary>
    public partial class Usuario : Window
    {
        private readonly IUsuarioApplication _usuarioApplication;
        private readonly Application.Models.Usuario _usuario;

        public Usuario(IUsuarioApplication usuarioApplication, Application.Models.Usuario usuario)
        {
            _usuarioApplication = usuarioApplication;
            _usuario = usuario;

            InitializeComponent();

            if (usuario.PerfilUsuario.Tipo == "Comum")
                btnAlterarUsuarios.Visibility = Visibility.Hidden;

            lblNome.Content = $"Nome: {_usuario.Nome}";
            lblCPF.Content = $"CPF: {_usuario.CPF}";
            lblRG.Content = $"RG: {_usuario.RG}";
            lblPerfil.Content = $"Perfil: {_usuario.PerfilUsuario.Tipo}";
        }

        private void BtnAlterarUsuarios_Click(object sender, RoutedEventArgs e)
        {
            new AlterarUsuarios(_usuarioApplication, _usuario.CPF).Show();
        }

        private void BtnAlterarSenha_Click(object sender, RoutedEventArgs e)
        {
            new AlteraSenha(_usuarioApplication, _usuario.CPF).Show();
        }
    }
}
