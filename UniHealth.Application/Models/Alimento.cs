using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniHealth.Application.Models
{
    class Alimento
    {
        [Key]
        int Id;
        string Nome;
        string CaloriaUnidade;
    }
}
