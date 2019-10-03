using System;
using System.Windows;
using System.Windows.Input;
using UniHealth.Application.Applications;
using UniHealth.Application.Exceptions;

namespace UniHealth
{
    public partial class MainWindow : Window
    {
        private readonly IUsuarioApplication _usuarioApplication;

        public MainWindow(IUsuarioApplication usuarioApplication)
        {
            _usuarioApplication = usuarioApplication;

            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;

                if (_usuarioApplication.LogarUsuario(txtUsuario.Text, txtSenha.Password))
                    new Usuario(_usuarioApplication, _usuarioApplication.GetUsuario(txtUsuario.Text)).Show();
            }
            catch (CPFInvalidoException ex)
            {
                MostrarMensagemAlerta(Title, ex.Message);

                txtUsuario.Clear();
                txtSenha.Clear();

                txtUsuario.Focus();
            }
            catch (SenhaInvalidaException ex)
            {
                MostrarMensagemAlerta(Title, ex.Message);

                txtSenha.Clear();

                txtSenha.Focus();
            }
            catch (UsuarioNaoCadastradoException ex)
            {
                MostrarMensagemAlerta(Title, ex.Message);

                txtUsuario.Clear();
                txtSenha.Clear();

                txtUsuario.Focus();
            }
            catch (UsuarioImpossibilitadoException ex)
            {
                MostrarMensagemAlerta(Title, ex.Message);

                txtUsuario.Clear();
                txtSenha.Clear();

                txtUsuario.Focus();
            }
            catch (Exception ex)
            {
                MostrarMensagemErro(Title, "Um erro inesperado ocorreu, tente novamente mais tarde!");
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }

        private void LblCriarConta_PreviewMouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            new CadastroUsuario(_usuarioApplication).Show();
        }

        private void MostrarMensagemAlerta(string titulo, string mensagem)
        {
            MessageBox.Show(mensagem, titulo, MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        private void MostrarMensagemErro(string titulo, string mensagem)
        {
            MessageBox.Show(mensagem, titulo, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
