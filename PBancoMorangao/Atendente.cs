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
        //Método construtor ja define qual é o atendente conforme a agência informada
        public Atendente(string agencia)
        {
            if (agencia.Contains('1'))
            {
                Nome = "Louise";
                Cargo = "Atendente";
            }
            else if (agencia.Contains('2'))
            {
                Nome = "Thalya";
                Cargo = "Atendente";
            }
            else if (agencia.Contains('3'))
            {
                Nome = "Weslen";
                Cargo = "Atendente";
            }
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

            //Verifica caso não tenha solicitação no diretório ele sai do método
            if(solicitacoes.Count == 0)
            {
                Console.WriteLine("Não há solicitações no momento!");
                return;
            }
           
            else
                Console.WriteLine($"Há {solicitacoes.Count} solicitações  pendentes!");


            //Busca o arquivo no caminho definido
            string[] solicita = System.IO.File.ReadAllLines($"C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\Solicitações\\{solicitacoes.First()}");
            string[] solicitacao;

            List<string> solicitacaoList = new List<string>();

            Console.WriteLine($"\nDados da Solicitação: ");

            //Laço para mostrar na tela e inserir os dados do cliente na lista
            foreach (string cont in solicita)
            {
                solicitacao = cont.Split(';');
                
                for(int i = 0; i < solicitacao.Length; i++)
                {
                    Console.WriteLine(solicitacao[i]);
                    solicitacaoList.Add(solicitacao[i]);    
                } 

            }
            Console.WriteLine("Criar conta para o cliente?[S/N]: ");
            string ler = Console.ReadLine().ToLower().Trim();

            if (ler.Contains("s"))
            {
                Console.WriteLine("Digite o tipo de conta:\n\n1 - Para Conta Universitária\n2 - Para Conta Normal\n3 - Para conta VIP");
                int tipo = int.Parse(Console.ReadLine());

                //Swith pra inserir o tipo de conta que o atendente escolher e depois envia o arquivo para o diretório AguardAprv para ser aprovado pelo Gerente
                switch (tipo)
                {
                    case 1:
                        System.IO.StreamWriter arqPessoa = new StreamWriter($"C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\Solicitações\\{solicitacoes.First()}");
                        arqPessoa.WriteLine($"{solicita[0]}Tipo de conta: Conta Universitária;");
                        arqPessoa.Close();
                        File.Move($"C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\Solicitações\\{solicitacoes.First()}",
                                    $"C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\AguarAprov\\{solicitacoes.First()}Conta Universitária.txt");
                        break;
                        
                    case 2:
                        System.IO.StreamWriter arqPessoa1 = new StreamWriter($"C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\Solicitações\\{solicitacoes.First()}");
                        arqPessoa1.WriteLine($"{solicita[0]}Tipo de conta: Conta Normal;");
                        arqPessoa1.Close();
                        File.Move($"C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\Solicitações\\{solicitacoes.First()}",
                                    $"C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\AguarAprov\\Conta Normal.txt");
                        break;
                    
                    case 3:
                        System.IO.StreamWriter arqPessoa2 = new StreamWriter($"C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\Solicitações\\{solicitacoes.First()}");
                        arqPessoa2.WriteLine($"{solicita[0]}Tipo de conta: Conta VIP;");
                        arqPessoa2.Close();
                        File.Move($"C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\Solicitações\\{solicitacoes.First()}",
                                    $"C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\AguarAprov\\Conta VIP.txt");
                        break;



                }
            }
        }
    }
}
