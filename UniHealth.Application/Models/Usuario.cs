using System;
using System.ComponentModel.DataAnnotations;

namespace UniHealth.Application.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public DateTime Inclusao { get; set; }

        public int StatusUsuarioId { get; set; }
        public StatusUsuario StatusUsuario { get; set; }

        public int PerfilUsuarioId { get; set; }
        public PerfilUsuario PerfilUsuario { get; set; }

        public Usuario(string cpf, string rg, string nome, string senha, DateTime inclusao, StatusUsuario statusUsuario, PerfilUsuario perfilUsuario)
        {
            CPF = cpf;
            RG = rg;
            Nome = nome;
            Senha = senha;
            Inclusao = inclusao;
            StatusUsuario = statusUsuario;
            PerfilUsuario = perfilUsuario;
        }
    }
}
