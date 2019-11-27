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
using UniHealth.Application.Utils;

namespace UniHealth
{
    /// <summary>
    /// Interaction logic for CalculoConsumorDiario.xaml
    /// </summary>
    public partial class CalculoConsumorDiario : Window
    {
        public CalculoConsumorDiario()
        {
            InitializeComponent();
        }

        private void BtnCalcular_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(txtAltura.Text, out var altura) || altura < 0)
            {
                MostrarMensagemErro(Title, "A altura deve ser um número!");
                txtAltura.Clear();
                txtAltura.Focus();
            }
            else if (!double.TryParse(txtPeso.Text, out var peso) || peso < 0)
            {
                MostrarMensagemErro(Title, "O peso deve ser um número!");
                txtPeso.Clear();
                txtPeso.Focus();
            }
            else if (!double.TryParse(txtIdade.Text, out var idade) || idade < 0)
            {
                MostrarMensagemErro(Title, "A idade deve ser um número!");
                txtIdade.Clear();
                txtIdade.Focus();
            }
            else
            {
                var consumo = ConsumoIdeal.CalcularConsumoIdeal(peso, altura, idade, cmbSexo.SelectedValue.ToString(), cmbAtividade.SelectedValue.ToString());

                MessageBox.Show($"{consumo} é a quantidade ideal de calorias que você deve consumir em um dia!", Title, MessageBoxButton.OK, MessageBoxImage.Information);

                Close();
            }
        }

        private void MostrarMensagemErro(string titulo, string mensagem)
        {
            MessageBox.Show(mensagem, titulo, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
