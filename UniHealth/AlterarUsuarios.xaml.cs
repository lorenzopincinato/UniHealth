using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using UniHealth.Application.Applications;
using UniHealth.Application.Utils;

namespace UniHealth
{
    /// <summary>
    /// Interaction logic for AlterarUsuarios.xaml
    /// </summary>
    public partial class AlterarUsuarios : Window
    {
        private readonly IUsuarioApplication _usuarioApplication;

        private readonly List<string> _cpfs;
        private readonly List<string> _estados;
        private readonly List<string> _perfis;

        private Application.Models.Usuario _usuario;
        private readonly string _cpf;

        private bool _handleCPF = true;

        public AlterarUsuarios(IUsuarioApplication usuarioApplication, string cpf)
        {
            _usuarioApplication = usuarioApplication;
            _cpfs = _usuarioApplication.GetCPFs().Where(x => x != cpf).ToList();

            _estados = _usuarioApplication.GetEstados();
            _perfis = _usuarioApplication.GetPerfis();

            InitializeComponent();

            _cpfs.ForEach(x => cmbCPFs.Items.Add(x));

            _estados.ForEach(x => cmbEstado.Items.Add(x));
            _perfis.ForEach(x => cmbPerfil.Items.Add(x));
        }

        private void CmbCPFs_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            _handleCPF = !cmb.IsDropDownOpen;
            HandleCPFChanged();
        }

        private void CmbCPFs_DropDownClosed(object sender, System.EventArgs e)
        {
            if (_handleCPF) HandleCPFChanged();
            _handleCPF = true;
        }

        private void HandleCPFChanged()
        {
            if (cmbCPFs.SelectedItem != null)
            {
                _usuario = _usuarioApplication.GetUsuario(cmbCPFs.SelectedItem.ToString());

                txtCPF.Text = _usuario.CPF;
                txtRG.Text = _usuario.RG;
                txtNome.Text = _usuario.Nome;
                cmbEstado.SelectedItem = _usuario.StatusUsuario.Estado;
                cmbPerfil.SelectedItem = _usuario.PerfilUsuario.Tipo;
            }
            else
            {
                txtCPF.Clear();
                txtRG.Clear();
                txtNome.Clear();
                cmbEstado.SelectedIndex = 0;
                cmbPerfil.SelectedIndex = 0;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cmbCPFs.SelectedItem == null)
            {
                MensagemUtils.MostrarMensagemErro(Title, "Nenhum usuário está selecionado!");
            }
            else
            {
                try
                {
                    _usuarioApplication.AlterarUsuario(_usuario.CPF, cmbEstado.SelectedItem.ToString(), cmbPerfil.SelectedItem.ToString());
                    MensagemUtils.MostrarMensagemSucesso(Title, "Usuário alterado com sucesso!");

                    Close();
                }
                catch (Exception)
                {
                    MensagemUtils.MostrarMensagemErro(Title, "Um erro aconteceu, tente novamente mais tarde!");
                }
                finally
                {

                }
            }
        }
    }
}
