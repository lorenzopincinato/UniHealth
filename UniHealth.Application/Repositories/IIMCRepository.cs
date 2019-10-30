using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniHealth.Application.Models;

namespace UniHealth.Application.Repositories
{
    public interface IIMCRepository
    {
        IMC GetLastIMC(string cpf);
        void AddIMC(IMC imc);
    }
}
