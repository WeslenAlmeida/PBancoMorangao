using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBancoMorangao
{
    internal class Funcionario : Pessoa
    {
        protected string CPF { get; set; }
        protected string Cargo { get; set; }
        protected string Salario { get; set; }

        public Funcionario()
        {

        }
    }
}
