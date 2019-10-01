using System;
using System.Windows;
using UniHealth.Application.Applications;
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
        private readonly ValidaSenha _validaSenha;

        public CadastroUsuario(IUsuarioApplication usuarioApplication)
        {
            InitializeComponent();

            _usuarioApplication = usuarioApplication;
            _validaSenha = new ValidaSenha();
        }

        private void BtnCadastrar_Click_1(object sender, RoutedEventArgs e)
        {
            if (ValidacaoUtils.CPFValido(txtCPF.Text))
            {
                if (txtRG.Text != "")
                {
                    if (txtUsuario.Text != "")
                    {
                        try
                        {
                            if (_validaSenha.ValidarRestricaoSenha(ModoVerificacaoSenha.Adicionando, txtSenha.Password, txtConfSenha.Password))
                            {
                                if (!_usuarioApplication.CPFExiste(txtCPF.Text))
                                {
                                    _usuarioApplication.CadastrarUsuario(txtCPF.Text, txtRG.Text, txtUsuario.Text, txtSenha.Password);

                                    lblErro.Content = "Usuário cadastrado com sucesso!";

                                    txtCPF.Clear();
                                    txtRG.Clear();
                                    txtUsuario.Clear();
                                    txtSenha.Clear();
                                    txtConfSenha.Clear();
                                }
                                else
                                {
                                    lblErro.Content = "CPF inválido, já existe um usuário cadastrado com esse CPF!";
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            lblErro.Content = ex.Message;
                        }
                    }
                    else
                    {
                        lblErro.Content = "Nome do usuário não pode estar vazio!";
                    }
                }
                else
                {
                    lblErro.Content = "RG não pode estar vazio!";
                }
            }
            else
            {
                lblErro.Content = "CPF não é válido!";
            }
        }
    }
}
