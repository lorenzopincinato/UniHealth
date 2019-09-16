using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniHealth
{
    public class Usuario
    {
        private int cpfUsuario;
        private String rgUsuario;
        private String nomeUsuario;
        private String senhaUsuario;
        private DateTime dataInclusaoUsuario;
        private StatusUsuario statusUsuario;
        private PerfilUsuario perfilUsuario; 

        public Usuario(int cpfUsuario, string rgUsuario, string nomeUsuario, string senhaUsuario, DateTime dataInclusaoUsuario, StatusUsuario statusUsuario, PerfilUsuario perfilUsuario)
        {
            this.cpfUsuario = cpfUsuario;
            this.rgUsuario = rgUsuario;
            this.nomeUsuario = nomeUsuario;
            this.senhaUsuario = senhaUsuario;
            this.dataInclusaoUsuario = dataInclusaoUsuario;
            this.statusUsuario = statusUsuario;
            this.perfilUsuario = perfilUsuario;
        }

        public int CPFUsuario { get => cpfUsuario; set => cpfUsuario = value; }
        public string RGUsuario { get => rgUsuario; set => rgUsuario = value; }
        public string NomeUsuario { get => nomeUsuario; set => nomeUsuario = value; }
        public string SenhaUsuario { get => senhaUsuario; set => senhaUsuario = value; }
        public DateTime DataInclusaoUsuario { get => dataInclusaoUsuario; set => dataInclusaoUsuario = value; }
        public StatusUsuario StatusUsuario { get => statusUsuario; set => statusUsuario = value; }
        public PerfilUsuario PerfilUsuario { get => perfilUsuario; set => perfilUsuario = value; }

        public override bool Equals(object obj)
        {
            return obj is Usuario usuario &&
                   CPFUsuario == usuario.CPFUsuario &&
                   RGUsuario == usuario.RGUsuario &&
                   nomeUsuario == usuario.nomeUsuario &&
                   senhaUsuario == usuario.senhaUsuario &&
                   dataInclusaoUsuario == usuario.dataInclusaoUsuario &&
                   statusUsuario == usuario.statusUsuario &&
                   perfilUsuario == usuario.perfilUsuario;
        }
    }
}
