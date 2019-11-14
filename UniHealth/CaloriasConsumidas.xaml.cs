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
    /// Interaction logic for CaloriasConsumidas.xaml
    /// </summary>
    public partial class CaloriasConsumidas : Window
    {
        private AlimentoConsumidoApplication _alimentoConsumidoApplication = new AlimentoConsumidoApplication();
        private AlimentoApplication _alimentoApplication = new AlimentoApplication();

        private List<Application.Models.Alimento> _alimentos;

        private string _cpf;

        private bool _handleAlimento = true;

        public CaloriasConsumidas(string cpf)
        {
            _cpf = cpf;

            _alimentos = _alimentoApplication.GetAllAlimentos();

            InitializeComponent();

            _alimentos.ForEach(alimento => cmbAlimentos.Items.Add(alimento));

            lblManha.Content = "Café da Manhã: " + _alimentoConsumidoApplication.GetAlimentoConsumidos(_cpf, "Café da Manhã", DateTime.Today).Sum(x => x.CaloriasConsumidas) + " cal";
            lblAlmoco.Content = "Almoço: " + _alimentoConsumidoApplication.GetAlimentoConsumidos(_cpf, "Almoço", DateTime.Today).Sum(x => x.CaloriasConsumidas) + " cal";
            lblTarde.Content = "Café da Tarde: " + _alimentoConsumidoApplication.GetAlimentoConsumidos(_cpf, "Café da Tarde", DateTime.Today).Sum(x => x.CaloriasConsumidas) + " cal";
            lblJanta.Content = "Janta: " + _alimentoConsumidoApplication.GetAlimentoConsumidos(_cpf, "Janta", DateTime.Today).Sum(x => x.CaloriasConsumidas) + " cal";
        }

        private void BtnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            if (!double.TryParse(txtUnidadesConsumidas.Text, out var unidadesConumidas))
            {
                MostrarMensagemErro(Title, "Unidades consumidas deve ser um número!");
                txtUnidadesConsumidas.Clear();
                txtUnidadesConsumidas.Focus();
            }
            else
            {
                _alimentoConsumidoApplication.AddAlimentoConsumido(_cpf, ((Application.Models.Alimento)cmbAlimentos.SelectedItem).Nome, double.Parse(txtUnidadesConsumidas.Text), cmbRefeicao.SelectedValue.ToString());

                lblManha.Content = "Café da Manhã: " + _alimentoConsumidoApplication.GetAlimentoConsumidos(_cpf, "Café da Manhã", DateTime.Today).Sum(x => x.CaloriasConsumidas) + " cal";
                lblAlmoco.Content = "Almoço: " + _alimentoConsumidoApplication.GetAlimentoConsumidos(_cpf, "Almoço", DateTime.Today).Sum(x => x.CaloriasConsumidas) + " cal";
                lblTarde.Content = "Café da Tarde: " + _alimentoConsumidoApplication.GetAlimentoConsumidos(_cpf, "Café da Tarde", DateTime.Today).Sum(x => x.CaloriasConsumidas) + " cal";
                lblJanta.Content = "Janta: " + _alimentoConsumidoApplication.GetAlimentoConsumidos(_cpf, "Janta", DateTime.Today).Sum(x => x.CaloriasConsumidas) + " cal";

                MessageBox.Show($"Alimento consumido foi adicionado!", Title, MessageBoxButton.OK, MessageBoxImage.Information);

                txtUnidadesConsumidas.Clear();
            }
        }

        private void CmbAlimentos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            _handleAlimento = !cmb.IsDropDownOpen;
            HandleAlimentoChanged();
        }

        private void CmbAlimentos_DropDownClosed(object sender, EventArgs e)
        {
            if (_handleAlimento) HandleAlimentoChanged();
            _handleAlimento = true;
        }

        private void HandleAlimentoChanged()
        {
            if (cmbAlimentos.SelectedItem != null)
            {
                lblUnidade.Content = ((Application.Models.Alimento)cmbAlimentos.SelectedItem).Unidade;
            }
            else
            {
                lblUnidade.Content = "";
            }
        }

        private void MostrarMensagemErro(string titulo, string mensagem)
        {
            MessageBox.Show(mensagem, titulo, MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
