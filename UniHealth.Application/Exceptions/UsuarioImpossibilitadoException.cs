using System;

namespace UniHealth.Application.Exceptions
{
    public class UsuarioImpossibilitadoException : Exception
    {
        public UsuarioImpossibilitadoException(string message) : base(message) { }
    }
}
