using System;
using System.Text.RegularExpressions;
using UniHealth.Application.Exceptions;
using UniHealth.Application.Models;

namespace UniHealth.Application.Utils
{
    public static class ValidacaoUtils
    {
        public static bool CPFValido(string cpf)
        {
            try
            {
                int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                string tempCpf;
                string digito;
                int soma;
                int resto;
                cpf = cpf.Trim();
                cpf = cpf.Replace(".", "").Replace("-", "");
                if (cpf.Length != 11)
                    return false;
                tempCpf = cpf.Substring(0, 9);
                soma = 0;

                for (int i = 0; i < 9; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = resto.ToString();
                tempCpf = tempCpf + digito;
                soma = 0;
                for (int i = 0; i < 10; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
                resto = soma % 11;
                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;
                digito = digito + resto.ToString();
                if (cpf.EndsWith(digito))
                    return true;

                return false;
            }
            catch {
                return false;
            }
        }

        public static bool RGValido(string rg)
        {
            try
            {
                int n1 = int.Parse(rg.Substring(0, 1));
                int n2 = int.Parse(rg.Substring(1, 1));
                int n3 = int.Parse(rg.Substring(2, 1));
                int n4 = int.Parse(rg.Substring(3, 1));
                int n5 = int.Parse(rg.Substring(4, 1));
                int n6 = int.Parse(rg.Substring(5, 1));
                int n7 = int.Parse(rg.Substring(6, 1));
                int n8 = int.Parse(rg.Substring(7, 1));

                string DV = rg.Substring(8, 1);

                int Soma = n1 * 2 + n2 * 3 + n3 * 4 + n4 * 5 + n5 * 6 + n6 * 7 + n7 * 8 + n8 * 9;

                string digitoVerificador = (Soma % 11).ToString();

                if (digitoVerificador == "1")
                {
                    digitoVerificador = "X";
                }

                else if (digitoVerificador == "0")
                {
                    digitoVerificador = "0";
                }

                else
                {
                    digitoVerificador = (11 - int.Parse(digitoVerificador)).ToString();
                }

                if (digitoVerificador == DV)
                    return true;

                return false;
            }
            catch
            {
                return false;
            }
        }

        public static bool SenhaValida(ModoVerificacaoSenha modoVerificacaoSenha, string senhaNova, string confSenhaNova, string senhaAtual = null)
        {
            int minLetras = 3;
            int minNumeros = 2;
            int maxCharsConsecutivos = 2;

            var regexSenha = new Regex("^[a-zA-Z0-9 ]*$");

            if (modoVerificacaoSenha.Equals(ModoVerificacaoSenha.Alterando))
            {
                if (string.IsNullOrEmpty(senhaAtual))
                    throw new Exception("A senha atual não pode ser nula!");

                else
                if (senhaAtual.Equals(senhaNova))
                    throw new Exception("A nova senha não pode ser igual a senha atual!");
            }

            if (!senhaNova.Equals(confSenhaNova))
                throw new Exception("A confirmação da senha nova não é igual a senha nova!");

            else
            if (senhaNova.Length < 7 || senhaNova.Length > 11)
                throw new Exception("A senha nova deve conter entre 7 e 11 caracteres!");

            else
            if (!regexSenha.IsMatch(senhaNova))
                throw new Exception("A senha não deve conter caracteres especiais nem caracteres matemáticos!");

            else
            if (!TemMinLetras(senhaNova, minLetras))
                throw new Exception($"A senha deve conter pelo menos {minLetras} letras!");

            else
            if (!TemMinNumeros(senhaNova, minNumeros))
                throw new Exception($"A senha deve conter pelo menos {minNumeros} números!");

            else
            if (TemMaxCharsRepetidos(senhaNova, maxCharsConsecutivos))
                throw new Exception($"A senha não pode conter {maxCharsConsecutivos + 1} caracteres repetidos em sequência!");

            return true;
        }

        private static bool TemMinLetras(string texto, int minLetras = 0)
        {
            int quantasLetras = 0;

            for (int i = 0; i < texto.Length; i++)
            {
                if (char.IsLetter(texto, i))
                    quantasLetras++;
            }

            if (quantasLetras < minLetras)
                return false;

            return true;
        }

        private static bool TemMinNumeros(string texto, int minNumeros = 0)
        {
            var quantosNumeros = 0;

            for (int i = 0; i < texto.Length; i++)
            {
                if (char.IsNumber(texto, i))
                    quantosNumeros++;
            }

            if (quantosNumeros < minNumeros)
                return false;

            return true;
        }

        private static bool TemMaxCharsRepetidos(string texto, int maxCharsConsecutivos = 0)
        {
            char charAtual, charAnterior;
            int quantosCharsRepetidos = 1;

            for (int i = 1; i < texto.Length; i++)
            {
                charAnterior = texto[i - 1];
                charAtual = texto[i];

                if (charAtual == charAnterior)
                    quantosCharsRepetidos++;
                else
                    quantosCharsRepetidos = 1;

                if (quantosCharsRepetidos > maxCharsConsecutivos)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
