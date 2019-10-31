using UniHealth.Application.Repositories;

namespace UniHealth.Application.Applications
{
    public class AlimentoApplication : IAlimentoApplication
    {
        private readonly IAlimentoRepository _alimentoRepository = new AlimentoRepository();

        public AlimentoApplication() { }

        public void AddAlimento(string nome, double caloriaUnidade, string unidade)
        {
            _alimentoRepository.AddAlimento(new Models.Alimento(nome, caloriaUnidade, unidade));
        }
    }
}
