using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UniHealth
{
    /// <summary>
    /// Lógica interna para AlteraSenha.xaml
    /// </summary>
    public partial class AlteraSenha : Window
    {       
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

        public AlteraSenha()
        {
            InitializeComponent();
        }     

        private void BtnAlterarSenha_Click(object sender, RoutedEventArgs e)
        {
            // transforma campos em variáveis
            String senhaAtual = txtSenhaAtual.Password.ToString();
            String senhaNova = txtSenhaNova.Password.ToString();
            String confSenhaNova = txtConfSenhaNova.Password.ToString();

            // limpa variáveis para validar
            lblMensagem.Content = "";
            lblMensagem.Foreground = Brushes.Red;

            CalculaPontuacaoSenha(senhaNova);
            senhaEhValida = ValidarRestricaoSenha(ModoVerificacaoSenha.Alterando, senhaNova, confSenhaNova, senhaAtual);

            if (senhaEhValida)
            {                
                lblMensagem.Foreground = Brushes.Green; 
                lblMensagem.Content = "Senha alterada com sucesso!";

                //alterar senha do usuario no bd
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

        public bool ValidarRestricaoSenha(ModoVerificacaoSenha modoVerificacaoSenha, String senhaNova, String confSenhaNova, String senhaAtual = null)
        {            
            if (modoVerificacaoSenha.Equals(ModoVerificacaoSenha.Alterando))
            {
                if (String.IsNullOrEmpty(senhaAtual))
                {
                    lblMensagem.Content = "A senha atual não pode ser nula!";
                    return false;
                }
                else
                if (senhaAtual.Equals(senhaNova))
                {
                    lblMensagem.Content = "A senha nova não pode ser igual a senha atual!";
                    return false;
                }  
                
                // #TODO: verificar se o campo senhaAtual realmente é a senha atual do usuário -> consulta SQL
            }            
            if (!senhaNova.Equals(confSenhaNova))
            {
                lblMensagem.Content = "A confirmação da senha nova não é igual a senha nova!";
                return false;
            }
            else
            if (senhaNova.Length < 7 || senhaNova.Length > 11)
            {
                lblMensagem.Content = "A senha nova deve conter entre 7 e 11 caracteres!";
                return false;
            }
            else
            if (!regexSenha.IsMatch(senhaNova))
            {
                lblMensagem.Content = "A senha nova não deve conter caracteres especiais nem caracteres matemáticos!";
                return false;
            }
            else
            if (getQtdDeLetras(senhaNova) < minQtdLetras)
            {
                lblMensagem.Content = $"A senha nova deve conter pelo menos {minQtdLetras} letras!";
                return false;
            }
            else
            if (getQtdDeNumeros(senhaNova) < minQtdNumeros)
            {
                lblMensagem.Content = $"A senha nova deve conter pelo menos {minQtdNumeros} números!";
                return false;
            }
            else
            if (temCaracteresRepetidos(senhaNova))
            {
                lblMensagem.Content = $"A senha nova não pode conter {maxCaracteresConsecutivosPermitidos+1} caracteres repetidos em sequência!";
                return false;
            }

            return true;
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

        private bool temCaracteresRepetidos(String texto)
        {
            char charAtual, charAnterior;
            int qtdCharsRepetidos = 1;      // inicializa com 1 para contar o char atual

            for (int i = 1; i < texto.Length; i++)
            {                                                                           
                charAnterior = texto[i-1];
                charAtual = texto[i]; 
                    
                if (charAtual == charAnterior)
                    qtdCharsRepetidos++;                    
                else
                    qtdCharsRepetidos = 1;

                if (qtdCharsRepetidos > maxCaracteresConsecutivosPermitidos)
                {
                    return true;
                }
            }
            return false;
        }        
    }
}
