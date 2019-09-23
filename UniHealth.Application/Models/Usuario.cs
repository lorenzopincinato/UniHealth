using System;

namespace UniHealth.Application.Models
{
    public class Usuario
    {
        public string CPF;
        public string RG;
        public string Nome;
        public string Senha;
        public DateTime Inclusao;
        public StatusUsuario Status;
        public PerfilUsuario Perfil; 

        public Usuario(string cpf, string rg, string nome, string senha, DateTime inclusao, StatusUsuario status, PerfilUsuario perfil)
        {
            CPF = cpf;
            RG = rg;
            Nome = nome;
            Senha = senha;
            Inclusao = inclusao;
            Status = status;
            Perfil = perfil;
        }
    }
}
