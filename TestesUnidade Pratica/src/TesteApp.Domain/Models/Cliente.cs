using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteApp.Domain.Models
{
    public class Cliente: Entity
    {
  
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string CPF { get; set; }
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Cep { get; set; }

    }
}
