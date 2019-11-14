using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniHealth.Application.Repositories;

namespace UniHealth.Application.Applications
{
    public class AlimentoConsumidoApplication
    {
        private readonly AlimentoConsumidoRepository _alimentoConsumidoRepository = new AlimentoConsumidoRepository();
        private readonly AlimentoRepository _alimentoRepository = new AlimentoRepository();
        private readonly UsuarioRepository _usuarioRepository = new UsuarioRepository();

        public AlimentoConsumidoApplication() { }

        public void AddAlimentoConsumido(string cpf, string nome, double unidadesConsumidas, string refeicao)
        {
            var user = _usuarioRepository.GetUsuarioByCPF(cpf);
            var alimento = _alimentoRepository.GetAllAlimentos().Where(x => x.Nome == nome).FirstOrDefault();

            var alimentoConsumido = new Application.Models.AlimentoConsumido(user, refeicao, alimento.Id, unidadesConsumidas);

            _alimentoConsumidoRepository.AddAlimentoConsumido(alimentoConsumido);
        }

        public List<Models.AlimentoConsumido> GetAlimentoConsumidos(string cpf, string refeicao, DateTime date)
        {
            return _alimentoConsumidoRepository.GetAlimentosByUserDateAndRefeicao(cpf, date, refeicao);
        }
    }
}
