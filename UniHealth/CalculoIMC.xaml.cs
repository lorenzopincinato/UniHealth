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
using UniHealth.Application.Utils;

namespace UniHealth
{
    /// <summary>
    /// Interaction logic for CalculoIMC.xaml
    /// </summary>
    public partial class CalculoIMC : Window
    {
        private readonly IUsuarioApplication _usuarioApplication;
        private readonly string _cpf;

        public CalculoIMC(IUsuarioApplication usuarioApplication, string cpf)
        {
            _usuarioApplication = usuarioApplication;
            _cpf = cpf;

            InitializeComponent();
        }

        private void BtnCalcularIMC_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(txtPeso.Text, out var peso) || peso <= 0)
            {
                MostrarMensagemErro(Title, "O peso deve ser um número e maior que zero!");
                txtPeso.Clear();
                txtPeso.Focus();
            }
            else
            {
                if (!double.TryParse(txtAltura.Text, out var altura) || altura <= 0)
                {
                    MostrarMensagemErro(Title, "A altura deve ser um número!");
                    txtAltura.Clear();
                    txtAltura.Focus();
                }
                else
                {
                    var imc = _usuarioApplication.CalcIMC(double.Parse(txtPeso.Text), double.Parse(txtAltura.Text), _cpf);

                    MessageBox.Show($"O IMC é {imc.IMCCalculado.ToString("#.##")}, {IMCUtils.GetFaixaDeIMC(imc.IMCCalculado)}", Title, MessageBoxButton.OK, MessageBoxImage.Information);

                    Close();
                }
            }
        }

        private void MostrarMensagemErro(string titulo, string mensagem)
        {
            MessageBox.Show(mensagem, titulo, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
