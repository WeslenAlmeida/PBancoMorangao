using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBancoMorangao
{
    internal abstract class ContaCorrente
    {
        public float Saldo { get; set; }
        public PessoaPF Pessoa { get; set; }
        public PessoaPJ Empresa { get; set; }
        public Endereco Endereco { get; set; }


        public ContaCorrente()
        {
           
        }

        public virtual void Sacar(float valorSaque)
         {
            Saldo -= valorSaque;
        } 

    }
}
