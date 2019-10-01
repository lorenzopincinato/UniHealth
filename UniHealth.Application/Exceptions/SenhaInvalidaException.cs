using System;

namespace UniHealth.Application.Exceptions
{
    public class SenhaInvalidaException : Exception
    {
        public SenhaInvalidaException(string cpf) : base($"A senha é inválida para o CPF {cpf}!") { }
    }
}
