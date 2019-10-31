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

namespace UniHealth
{
    /// <summary>
    /// Interaction logic for AdicionarAlimento.xaml
    /// </summary>
    public partial class AdicionarAlimento : Window
    {
        private readonly IAlimentoApplication _usuarioApplication = new AlimentoApplication();

        public AdicionarAlimento()
        {
            InitializeComponent();
        }

        private void BtnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNome.Text == "")
            {
                MostrarMensagemErro(Title, "O nome do alimento não pode ser vazio!");
                txtNome.Clear();
                txtNome.Focus();
            }
            else
            {
                if (!double.TryParse(txtCaloriaUnidade.Text, out var caloriaUnidade))
                {
                    MostrarMensagemErro(Title, "A quantidade de calorias por unidade deve ser um número!");
                    txtCaloriaUnidade.Clear();
                    txtCaloriaUnidade.Focus();
                }
                else
                {
                    _usuarioApplication.AddAlimento(txtNome.Text, double.Parse(txtCaloriaUnidade.Text), cmbUnidade.SelectedValue.ToString());

                    MessageBox.Show($"{txtNome.Text} foi adicionado(a) com sucesso!", Title, MessageBoxButton.OK, MessageBoxImage.Information);

                    txtNome.Clear();
                    txtCaloriaUnidade.Clear();

                    txtNome.Focus();
                }
            }
        }

        private void MostrarMensagemErro(string titulo, string mensagem)
        {
            MessageBox.Show(mensagem, titulo, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
