using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniHealth.Application.Utils
{
    public static class ConsumoIdeal
    {
        public static double CalcularConsumoIdeal(double peso, double altura, double idade, string sexo, string nivelAtividade)
        {
            double tmb = 0;

            if (sexo == "Masculino")
            {
                tmb = 88.362 + (13.397 * peso) + (4.799 * altura) - (5.677 * idade);
            }
            else
            {
                tmb = 447.593 + (9.247 * peso) + (3.098 * altura) - (4.330 * idade);
            }

            switch (nivelAtividade)
            {
                case "Pouco ou nenhum exercício":
                    return tmb * 1.2;

                case "Pouco exercício (1 a 3 dias por semana)":
                    return tmb * 1.375;

                case "Exercício moderado (3 a 5 dias por semana)":
                    return tmb * 1.55;

                case "Exercício intenso (6 a 7 dias por semana)":
                    return tmb * 1.725;

                case "Exercício muito intenso (2 vezes por dia ou treino pesado)":
                    return tmb * 1.9;
            }

            return 0;
        }
    }
}
