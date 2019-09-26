using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UniHealth.Application.Applications;
using UniHealth.Application.Models;

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
            if (txtSenha.Password == txtConfSenha.Password)
            {
                if (!_usuarioApplication.CPFExists(txtCPF.Text))
                {
                    _usuarioApplication.CreateUsuario(txtCPF.Text, txtRG.Text, txtUsuario.Text, txtSenha.Password);

                    // USUARIO CADASTRADO COM SUCESSO
                }
                else
                {
                    // USUARIO COM ESSE CPF JÁ EXISTE
                }
            }
            else
            {
                // SENHA NÃO CONFIRMA
            }
        }
    }
}
