using System;
using System.Windows;
using System.Windows.Input;
using UniHealth.Application.Applications;
using UniHealth.Application.Exceptions;
using UniHealth.Application.Models;
using UniHealth.Application.Utils;

namespace UniHealth
{
    /// <summary>
    /// Lógica interna para CadastroUsuario.xaml
    /// </summary>
    public partial class CadastroUsuario : Window
    {
        private readonly IUsuarioApplication _usuarioApplication;

        public CadastroUsuario(IUsuarioApplication usuarioApplication)
        {
            InitializeComponent();

            _usuarioApplication = usuarioApplication;
        }

        private void BtnCadastrar_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                Mouse.OverrideCursor = Cursors.Wait;

                _usuarioApplication.CadastrarUsuario(txtCPF.Text, txtRG.Text, txtUsuario.Text, txtSenha.Password, txtConfSenha.Password);

                MensagemUtils.MostrarMensagemSucesso(Title, "Usuário cadastrado com sucesso!");

                Close();
            }
            catch (CPFInvalidoException ex)
            {
                MensagemUtils.MostrarMensagemAlerta(Title, ex.Message);

                txtCPF.Clear();
                txtCPF.Focus();
            }
            catch (RGInvalidoException ex)
            {
                MensagemUtils.MostrarMensagemAlerta(Title, ex.Message);

                txtRG.Clear();
                txtRG.Focus();
            }
            catch (SenhaInvalidaException ex)
            {
                MensagemUtils.MostrarMensagemAlerta(Title, ex.Message);

                txtSenha.Clear();
                txtConfSenha.Clear();

                txtSenha.Focus();
            }
            catch (Exception)
            {
                MensagemUtils.MostrarMensagemErro(Title, "Um erro inesperado ocorreu, tente novamente mais tarde!");
            }
            finally
            {
                Mouse.OverrideCursor = null;
            }
        }
    }
}
