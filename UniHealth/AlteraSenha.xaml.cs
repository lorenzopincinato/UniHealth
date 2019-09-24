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
        private String senhaAtual;
        private String senhaNova;
        private String confSenhaNova;
        private bool senhaEhValida;

        private Regex regexSenha = new Regex("^[a-zA-Z0-9]*$");
        private const int maxCaracteresRepetidosPermitidas = 2;
        private const int minQtdLetras = 3;
        private const int minQtdNumeros = 2;               

        public AlteraSenha()
        {
            InitializeComponent();
        }     

        private void BtnAlterarSenha_Click(object sender, RoutedEventArgs e)
        {
            // transforma campos em variáveis
            this.senhaAtual = txtSenhaAtual.Password.ToString();
            this.senhaNova = txtSenhaNova.Password.ToString();
            this.confSenhaNova = txtConfSenhaNova.Password.ToString();

            // limpa variáveis para validar
            lblMensagem.Content = "";
            lblMensagem.Foreground = Brushes.Red;

            senhaEhValida = ValidarRestricaoSenha(ModoVerificacaoSenha.Alterando);

            if (senhaEhValida)
            {                
                lblMensagem.Foreground = Brushes.Green; 
                lblMensagem.Content = "Senha alterada com sucesso!";

                //alterar senha do usuario no bd
            }
        }

        private bool ValidarRestricaoSenha(ModoVerificacaoSenha modoVerificacaoSenha)
        {
            if (modoVerificacaoSenha.Equals(ModoVerificacaoSenha.Alterando))
            {
                if (senhaAtual.Equals(senhaNova))
                {
                    lblMensagem.Content = "A senha nova não pode ser igual a senha atual!";
                    return false;
                }
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
            if (!temMinimoDeLetras(senhaNova))
            {
                lblMensagem.Content = $"A senha nova deve conter pelo menos {minQtdLetras} letras!";
                return false;
            }
            else
            if (!temMinimoDeNumeros(senhaNova))
            {
                lblMensagem.Content = $"A senha nova deve conter pelo menos {minQtdNumeros} números!";
                return false;
            }
            else
            if (temCaracteresRepetidos(senhaNova))
            {
                lblMensagem.Content = $"A senha nova não pode conter {maxCaracteresRepetidosPermitidas+1} caracteres repetidos em sequência!";
                return false;
            }

            return true;
        }

        private bool temMinimoDeLetras(String texto)
        {
            int qtdLetras = 0;

            for (int i=0; i<texto.Length; i++)
            {
                if (Char.IsLetter(texto, i))
                    qtdLetras++;
            }

            return qtdLetras < minQtdLetras ? false : true;
        }

        private bool temMinimoDeNumeros(String texto)
        {
            int qtdNumeros = 0;

            for (int i = 0; i < texto.Length; i++)
            {
                if (Char.IsNumber(texto, i))
                    qtdNumeros++;
            }

            return qtdNumeros < minQtdNumeros ? false : true;
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

                if (qtdCharsRepetidos > maxCaracteresRepetidosPermitidas)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
