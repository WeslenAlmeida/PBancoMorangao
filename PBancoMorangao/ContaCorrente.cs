using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBancoMorangao
{
    internal abstract class ContaCorrente
    {
        public int Numconta { get; set; }
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
        public virtual void Depositar(float valorDeposito)
        {
            Saldo += valorDeposito;
        }
        public virtual void Transferir(float valor, int contaDestino)
        {
            Sacar(valor);
            Depositar(valor);
        }



    }
}
