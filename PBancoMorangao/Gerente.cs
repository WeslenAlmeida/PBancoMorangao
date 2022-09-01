using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBancoMorangao
{
    internal class Gerente : Funcionario 
    {
        private Autenticacao autenticador;

        public Gerente()
        {
            autenticador = new Autenticacao();
            autenticador.setSenha(12345);
        }
        
        public bool Autentica(int senha)
        {
            return autenticador.Autentica(senha);
        }

    }
}
