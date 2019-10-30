using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UniHealth.Application.Exceptions;
using UniHealth.Application.Models;
using UniHealth.Application.Repositories;
using UniHealth.Application.Utils;

namespace UniHealth.Application.Applications
{
    public class UsuarioApplication : IUsuarioApplication
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IStatusUsuarioRepository _statusUsuarioRepository;
        private readonly IPerfilUsuarioRepository _perfilUsuarioRepository;
        private readonly IIMCRepository _imcRepository;

        public UsuarioApplication(IUsuarioRepository usuarioRepository, IStatusUsuarioRepository statusUsuarioRepository, IPerfilUsuarioRepository perfilUsuarioRepository, IIMCRepository imcRepository)
        {
            _usuarioRepository = usuarioRepository;
            _statusUsuarioRepository = statusUsuarioRepository;
            _perfilUsuarioRepository = perfilUsuarioRepository;
            _imcRepository = imcRepository;
        }

        public void CadastrarUsuario(string cpf, string rg, string nome, string senha, string confirmacaoSenha)
        {
            try { ValidacaoUtils.SenhaValida(ModoVerificacaoSenha.Adicionando, senha, confirmacaoSenha); }
            catch (Exception ex) { throw new SenhaInvalidaException(ex.Message); }

            if (!ValidacaoUtils.CPFValido(cpf))
                throw new CPFInvalidoException();

            if (!ValidacaoUtils.RGValido(rg))
                throw new RGInvalidoException();

            if (_usuarioRepository.GetUsuarioByCPF(cpf) != null)
                throw new CPFInvalidoException("O CPF já está cadastrado!");

            if (_usuarioRepository.GetUsuarioByRG(rg) != null)
                throw new RGInvalidoException("O RG já está cadastrado!");

            var statusUsuario = _statusUsuarioRepository.GetStatusUsuarioByEstadoAsync("Normal");
            var perfilUsuario = _perfilUsuarioRepository.GetPerfilUsuarioByTipoAsync("Comum");

            // AQUI
            var senhaCriptografadaParcial = CriptografiaUtils.CriptografiaEmCifra(senha);
            var senhaCriptografadaFinal = CriptografiaUtils.CriptografaEmCodigo(senhaCriptografadaParcial);

            var usuario = new Usuario(cpf, rg, nome, senhaCriptografadaFinal, DateTime.Now, statusUsuario, perfilUsuario);

            _usuarioRepository.AddUsuario(usuario);
        }

        public bool CPFExiste(string cpf)
        {
            var usuario = _usuarioRepository.GetUsuarioByCPF(cpf);

            if (usuario != null)
                return true;

            return false;
        }

        public bool LogarUsuario(string cpf, string passowrd)
        {
            if (!ValidacaoUtils.CPFValido(cpf))
                throw new CPFInvalidoException();

            var usuario = _usuarioRepository.GetUsuarioByCPF(cpf);

            if (usuario == null)
                throw new UsuarioNaoCadastradoException(cpf);

            if (usuario.StatusUsuario.Estado == "Excluido")
                throw new UsuarioImpossibilitadoException("Esse usuário foi exclúido!");

            if (usuario.StatusUsuario.Estado == "Bloqueado")
                throw new UsuarioImpossibilitadoException("Esse usuário está bloqueado!");

            var senhaDecriptadaParcial = CriptografiaUtils.DecriptografiaEmCodigo(usuario.Senha);
            var senhaDecriptadaFinal = CriptografiaUtils.DecriptografiaEmCifra(senhaDecriptadaParcial);

            if (senhaDecriptadaFinal != passowrd.ToUpper())
                throw new SenhaInvalidaException(cpf);

            return true;
        }

        public void AlterarSenhaUsuario(string cpf, string newPassword)
        {
            var usuario = _usuarioRepository.GetUsuarioByCPF(cpf);

            var senhaCriptografadaParcial = CriptografiaUtils.CriptografiaEmCifra(newPassword);
            var senhaCriptografadaFinal = CriptografiaUtils.CriptografaEmCodigo(senhaCriptografadaParcial);

            usuario.Senha = senhaCriptografadaFinal;

            _usuarioRepository.UpdateUsuario(usuario);
        }

        public List<string> GetCPFs()
        {
            return _usuarioRepository.GetAll().Select(x => x.CPF).ToList();
        }

        public Usuario GetUsuario(string cpf)
        {
            return _usuarioRepository.GetUsuarioByCPF(cpf);
        }

        public List<string> GetEstados()
        {
            return _statusUsuarioRepository.GetAll().Select(x => x.Estado).ToList();
        }

        public List<string> GetPerfis()
        {
            return _perfilUsuarioRepository.GetAll().Select(x => x.Tipo).ToList();
        }

        public IMC CalcIMC(double peso, double altura, string cpf)
        {
            var usuario = _usuarioRepository.GetUsuarioByCPF(cpf);

            var imc = new IMC(peso, altura, usuario.Id);

            _imcRepository.AddIMC(imc);

            return imc;
        }

        public IMC GetIMC(string cpf)
        {
            return _imcRepository.GetLastIMC(cpf);
        }

        public void AlterarUsuario(string cpf, string estado, string perfil)
        {
            var usuario = _usuarioRepository.GetUsuarioByCPF(cpf);

            var novoEstado = _statusUsuarioRepository.GetStatusUsuarioByEstadoAsync(estado);
            var novoPerfil = _perfilUsuarioRepository.GetPerfilUsuarioByTipoAsync(perfil);

            usuario.StatusUsuario = novoEstado;
            usuario.PerfilUsuario = novoPerfil;

            _usuarioRepository.UpdateUsuario(usuario);
        }
    }
}
