using System;

namespace UniHealth.Application.Exceptions
{
    public class UsuarioNaoCadastradoException : Exception
    {
        public UsuarioNaoCadastradoException(string cpf) : base($"O usuário {cpf} não está cadastrado!") { }
    }
}
