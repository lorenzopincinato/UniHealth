using System;
using System.Windows;
using System.Windows.Input;
using UniHealth.Application.Applications;

namespace UniHealth
{
    /// <summary>
    /// Interaction logic for Usuario.xaml
    /// </summary>
    public partial class Usuario : Window
    {
        private readonly IUsuarioApplication _usuarioApplication;
        private Application.Models.Usuario _usuario;
        private Application.Models.IMC _imc;

        public Usuario(IUsuarioApplication usuarioApplication, Application.Models.Usuario usuario, Application.Models.IMC imc)
        {
            _usuarioApplication = usuarioApplication;
            _usuario = usuario;
            _imc = imc;

            InitializeComponent();

            if (usuario.PerfilUsuario.Tipo == "Comum")
            {
                btnAlterarUsuarios.Visibility = Visibility.Hidden;
                btnAdicionarAlimentos.Visibility = Visibility.Hidden;
            }

            lblNome.Content = $"Nome: {_usuario.Nome}";
            lblCPF.Content = $"CPF: {_usuario.CPF}";
            lblRG.Content = $"RG: {_usuario.RG}";
            lblPerfil.Content = $"Perfil: {_usuario.PerfilUsuario.Tipo}";
            if (_imc != null)
            {
                lblIMC.Content = $"IMC: {_imc.IMCCalculado.ToString("#.##")} (Calculado em {_imc.DataCalculo.ToString("dd/MM/yyyy")})";
            }
            else
            {
                lblIMC.Content = $"IMC: Ainda não foi calculado";
            }
        }

        private void BtnAlterarUsuarios_Click(object sender, RoutedEventArgs e)
        {
            new AlterarUsuarios(_usuarioApplication, _usuario.CPF).Show();
        }

        private void BtnAlterarSenha_Click(object sender, RoutedEventArgs e)
        {
            new AlteraSenha(_usuarioApplication, _usuario.CPF).Show();
        }

        private void BtnCalcularIMC_Click(object sender, RoutedEventArgs e)
        {
            new CalculoIMC(_usuarioApplication, _usuario.CPF).Show();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            Mouse.OverrideCursor = Cursors.Wait;

            _usuario = _usuarioApplication.GetUsuario(_usuario.CPF);
            _imc = _usuarioApplication.GetIMC(_usuario.CPF);

            lblNome.Content = $"Nome: {_usuario.Nome}";
            lblCPF.Content = $"CPF: {_usuario.CPF}";
            lblRG.Content = $"RG: {_usuario.RG}";
            lblPerfil.Content = $"Perfil: {_usuario.PerfilUsuario.Tipo}";
            if (_imc != null)
            {
                lblIMC.Content = $"IMC: {_imc.IMCCalculado.ToString("#.##")} (Calculado em {_imc.DataCalculo.ToString("dd/MM/yyyy")})";
            }
            else
            {
                lblIMC.Content = $"IMC: Ainda não foi calculado";
            }

            Mouse.OverrideCursor = null;
        }

        private void BtnCalorias_Click(object sender, RoutedEventArgs e)
        {
            new CaloriasConsumidas(_usuario.CPF).Show();
        }

        private void BtnAdicionarAlimentos_Click(object sender, RoutedEventArgs e)
        {
            new AdicionarAlimento().Show();
        }
    }
}
