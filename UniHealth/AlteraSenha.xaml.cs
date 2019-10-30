using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media;
using UniHealth.Application.Applications;
using UniHealth.Application.Exceptions;
using UniHealth.Application.Models;
using UniHealth.Application.Utils;

namespace UniHealth
{
    /// <summary>
    /// Lógica interna para AlteraSenha.xaml
    /// </summary>
    public partial class AlteraSenha : Window
    {
        private readonly IUsuarioApplication _usuarioApplication;

        private readonly string _cpf;

        private bool senhaEhValida;

        private const int maxNumerosCrescentesConsecutivosPermitidos = 3;
        private const int maxNumerosDecrescentesConsecutivosPermitidos = 3;               
        private int[] vetPontos = new int[] { -2, -2, -1, -1, -2, -2, -3, -4};

        private Regex regexSenha = new Regex("^[a-zA-Z0-9]*$");
        private const int maxCaracteresConsecutivosPermitidos = 2;        
        private const int minQtdLetras = 3;
        private const int minQtdNumeros = 2;
        
        private int qtdLetras;
        private int qtdNumeros;
        private int forcaSenha;

        public AlteraSenha(IUsuarioApplication usuarioApplication, string cpf)
        {
            _usuarioApplication = usuarioApplication;
            _cpf = cpf;

            InitializeComponent();
        }

        private void BtnAlterarSenha_Click(object sender, RoutedEventArgs e)
        {
            String senhaAtual = txtSenhaAtual.Password.ToString();
            String senhaNova = txtSenhaNova.Password.ToString();
            String confSenhaNova = txtConfSenhaNova.Password.ToString();


            CalculaPontuacaoSenha(senhaNova);

            try
            {
                if (ValidacaoUtils.SenhaValida(ModoVerificacaoSenha.Alterando, senhaNova, confSenhaNova, senhaAtual))
                {
                    _usuarioApplication.AlterarSenhaUsuario(_cpf, senhaNova);

                    MensagemUtils.MostrarMensagemSucesso(Title, "Senha alterada com sucesso!");

                    Close();
                }
            }
            catch (Exception ex)
            {
                MensagemUtils.MostrarMensagemAlerta(Title, ex.Message);

                txtSenhaAtual.Clear();
                txtSenhaNova.Clear();
                txtConfSenhaNova.Clear();

                txtSenhaNova.Focus();
            }
        }

        private void TxtSenhaNova_PasswordChanged(object sender, RoutedEventArgs e)
        {            
            lblForcaSenhaNova.Content = CalculaPontuacaoSenha(sender.ToString());
        }

        private void TxtConfSenhaNova_PasswordChanged(object sender, RoutedEventArgs e)
        {
            lblForcaConfSenhaNova.Content = CalculaPontuacaoSenha(sender.ToString());                        
        }

        public int CalculaPontuacaoSenha(String senha)
        {
            forcaSenha = 10;

            if (temNumerosSequenciaisCrescentes())
            {
                forcaSenha -= vetPontos[0];
            }
            if (temNumerosSequenciaisDecrescentes())
            {
                forcaSenha -= vetPontos[1];
            }
            if (getQtdDeLetras(senha) == 3)
            {
                forcaSenha -= vetPontos[2];
            }
            if (getQtdDeNumeros(senha) == 2)
            {
                forcaSenha -= vetPontos[3];
            }
            /*
            if (senha.Contains(usuario.Nome)
            {
                forcaSenha -= vetPontos[4];
            }
            if (senha.Contains(primeiroNome)
            {
                forcaSenha -= vetPontos[5];
            }
            if (senha.Contains(iniciais)
            {
                forcaSenha -= vetPontos[6];
            }
            if (senha.Contains(data)
            {
                forcaSenha -= vetPontos[7];
            }
            */
            return forcaSenha;
        }
        
        private bool temNumerosSequenciaisCrescentes()
        {
            return false;
        }
        private bool temNumerosSequenciaisDecrescentes()
        {
            return false;
        }


        private int getQtdDeLetras(String texto)
        {
            qtdLetras = 0;

            for (int i=0; i<texto.Length; i++)
            {
                if (Char.IsLetter(texto, i))
                    qtdLetras++;
            }

            return qtdLetras;
        }

        private int getQtdDeNumeros(String texto)
        {
            qtdNumeros = 0;

            for (int i = 0; i < texto.Length; i++)
            {
                if (Char.IsNumber(texto, i))
                    qtdNumeros++;
            }

            return qtdNumeros;
        }
      
    }
}
