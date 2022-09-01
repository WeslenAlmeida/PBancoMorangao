using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBancoMorangao
{
    internal class Atendente : Funcionario
    {
        public string Agencia { get; set; } 

        public Atendente()
        {

        }

        public void AbreConta()
        {
            //Verifica a quantidade de solicitações
            List<string> solicitacoes = new List<string>(); 
            DirectoryInfo dir = new DirectoryInfo("C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\Solicitações");
            foreach (var file in dir.GetFiles())
            {
                solicitacoes.Add(file.Name);    
            }

            if(solicitacoes.Count == 0)
                Console.WriteLine("Não há solicitações no momento!");
            else
                Console.WriteLine($"Há {solicitacoes.Count} solicitações  pendentes!");


            //Mostra na tela os dados da solicitações
            string[] solicita = System.IO.File.ReadAllLines($"C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\Solicitações\\{solicitacoes.First()}");
            string[] solicitacao;
            List<string> solicitacaoList = new List<string>();

            Console.WriteLine($"\nDados da Solicitação: ");

            foreach(string cont in solicita)
            {
                solicitacao = cont.Split(';');
                Console.WriteLine(cont);
            }
        }
    }
}
