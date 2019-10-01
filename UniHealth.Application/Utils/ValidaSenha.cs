using System;
using System.Text.RegularExpressions;
using UniHealth.Application.Models;

namespace UniHealth.Application.Utils
{
    public class ValidaSenha
    {
        private bool senhaEhValida;

        private const int maxNumerosCrescentesConsecutivosPermitidos = 3;
        private const int maxNumerosDecrescentesConsecutivosPermitidos = 3;
        private int[] vetPontos = new int[] { -2, -2, -1, -1, -2, -2, -3, -4 };

        private Regex regexSenha = new Regex("^[a-zA-Z0-9]*$");
        private const int maxCaracteresConsecutivosPermitidos = 2;
        private const int minQtdLetras = 3;
        private const int minQtdNumeros = 2;

        private int qtdLetras;
        private int qtdNumeros;
        private int forcaSenha;

        public ValidaSenha() { }

        public bool ValidarRestricaoSenha(ModoVerificacaoSenha modoVerificacaoSenha, string senhaNova, string confSenhaNova, string senhaAtual = null)
        {
            if (modoVerificacaoSenha.Equals(ModoVerificacaoSenha.Alterando))
            {
                if (string.IsNullOrEmpty(senhaAtual))
                {
                    throw new Exception("A senha atual não pode ser nula!");
                }
                else
                if (senhaAtual.Equals(senhaNova))
                {
                    throw new Exception("A senha nova não pode ser igual a senha atual!");
                }
            }
            if (!senhaNova.Equals(confSenhaNova))
            {
                throw new Exception("A confirmação da senha nova não é igual a senha nova!");
            }
            else
            if (senhaNova.Length < 7 || senhaNova.Length > 11)
            {
                throw new Exception("A senha nova deve conter entre 7 e 11 caracteres!");
            }
            else
            if (!regexSenha.IsMatch(senhaNova))
            {
                throw new Exception("A senha nova não deve conter caracteres especiais nem caracteres matemáticos!");
            }
            else
            if (getQtdDeLetras(senhaNova) < minQtdLetras)
            {
                throw new Exception($"A senha nova deve conter pelo menos {minQtdLetras} letras!");
            }
            else
            if (getQtdDeNumeros(senhaNova) < minQtdNumeros)
            {
                throw new Exception($"A senha nova deve conter pelo menos {minQtdNumeros} números!");
            }
            else
            if (temCaracteresRepetidos(senhaNova))
            {
                throw new Exception($"A senha nova não pode conter {maxCaracteresConsecutivosPermitidos + 1} caracteres repetidos em sequência!");
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

        private int getQtdDeLetras(string texto)
        {
            qtdLetras = 0;

            for (int i = 0; i < texto.Length; i++)
            {
                if (char.IsLetter(texto, i))
                    qtdLetras++;
            }

            return qtdLetras;
        }

        private int getQtdDeNumeros(string texto)
        {
            qtdNumeros = 0;

            for (int i = 0; i < texto.Length; i++)
            {
                if (char.IsNumber(texto, i))
                    qtdNumeros++;
            }

            return qtdNumeros;
        }

        private bool temCaracteresRepetidos(string texto)
        {
            char charAtual, charAnterior;
            int qtdCharsRepetidos = 1;      // inicializa com 1 para contar o char atual

            for (int i = 1; i < texto.Length; i++)
            {
                charAnterior = texto[i - 1];
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