using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBancoMorangao
{
    internal class Autenticacao
    {
        private int Senha { get; set; }

        public void setSenha(int senha)
        {
            this.Senha = senha; 
        }

        public bool Autentica(int senha)
        {
            if(this.Senha == senha) 
                return true;
            return false;   
        }
    }
}
