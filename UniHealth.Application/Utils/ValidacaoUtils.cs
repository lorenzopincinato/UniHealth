using System;
using UniHealth.Application.Exceptions;

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
    }
}
