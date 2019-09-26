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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UniHealth.Application.Applications;

namespace UniHealth
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly IUsuarioApplication _usuarioApplication;

        public MainWindow(IUsuarioApplication usuarioApplication)
        {
            _usuarioApplication = usuarioApplication;

            InitializeComponent();
        }

        private void BtnCriarConta_Click(object sender, RoutedEventArgs e)
        {
            new CadastroUsuario(_usuarioApplication).Show();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (_usuarioApplication.LoginUser(txtUsuario.Text, txtSenha.Password))
            {
                new AlteraSenha(_usuarioApplication, txtUsuario.Text).Show();
            }
            else
            {
                lblErros.Content = "O usuário informado não existe ou a senha está inválida!";
                txtSenha.Clear();
            }
        }
    }
}
