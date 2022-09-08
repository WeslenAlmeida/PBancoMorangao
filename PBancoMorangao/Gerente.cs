using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBancoMorangao
{
    internal class Gerente : Funcionario
    {
        public int Senha { get; set; }

        public Gerente()
        {
            
        }

        //Método para Verificar a senha do Gerente
        public bool Autentica(int senha)
        {
            if (this.Senha == senha)
                return true;
            return false;
        }

        public void AprovarConta()
        {
            //Verifica a quantidade de solicitações
            List<string> solicitacoes = new List<string>();
            System.IO.DirectoryInfo dir = new DirectoryInfo("C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\AguarAprov");
            foreach (var file in dir.GetFiles())
            {
                solicitacoes.Add(file.Name);
            }

            //Verifica caso não tenha solicitação no diretório ele sai do método
            if (solicitacoes.Count == 0)
            {
                Console.WriteLine("Não há solicitações no momento!");
                return;
            }

            else
                Console.WriteLine($"Há {solicitacoes.Count} solicitações  pendentes!");



            //Busca o arquivo no caminho definido
            string[] solicita = System.IO.File.ReadAllLines($"C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\AguarAprov\\{solicitacoes.First()}");
            string[] solicitacao;

            List<string> solicitacaoList = new();

            Console.WriteLine($"\nDados da Solicitação: ");

            //Laço para mostrar na tela e inserir os dados do cliente na lista
            foreach (string cont in solicita)
            {
                solicitacao = cont.Split(';');

                for (int i = 0; i < solicitacao.Length; i++)
                {
                    Console.WriteLine(solicitacao[i]);
                    solicitacaoList.Add(solicitacao[i]);
                }

            }
            Console.WriteLine(solicitacoes.First());
            Console.WriteLine("Aprovar conta?[S/N]: ");
            string ler = Console.ReadLine().ToLower().Trim();

            //Condição para aprovar a conta solicitada pelo atendente
            if (ler.Contains('s'))
            {
                System.IO.StreamWriter arqPessoa = new StreamWriter($"C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\AguarAprov\\{solicitacoes.First()}");
                arqPessoa.WriteLine($"{solicita[0]}0;");
                arqPessoa.Close();
                File.Move($"C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\AguarAprov\\{solicitacoes.First()}",
                            $"C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\ContasBanco\\{solicitacoes.First()}");
            }
            else
                return;


        }
        public void AprovarEmprestimo()
        {
            //Verifica a quantidade de solicitações
            List<string> solicitacoes = new List<string>();
            System.IO.DirectoryInfo dir = new DirectoryInfo("C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\SolicitaçõesEmpréstimos");
            foreach (var file in dir.GetFiles())
            {
                solicitacoes.Add(file.Name);
            }

            //Verifica caso não tenha solicitação no diretório ele sai do método
            if (solicitacoes.Count == 0)
            {
                Console.WriteLine("Não há solicitações no momento!");
                return;
            }

            else
                Console.WriteLine($"Há {solicitacoes.Count} solicitações  pendentes!");

            //Busca o arquivo no caminho definido
            string[] solicita = System.IO.File.ReadAllLines($"C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\SolicitaçõesEmpréstimos\\{solicitacoes.First()}");
            string[] solicitacao = new string[19];

            List<string> solicitacaoList = new();

            Console.WriteLine($"\nDados da Solicitação: ");

            //Laço para mostrar na tela e inserir os dados do cliente na lista
            foreach (string cont in solicita)
            {
                solicitacao = cont.Split(';');

                for (int i = 0; i < solicitacao.Length; i++)
                {
                    Console.WriteLine(solicitacao[i]);
                    solicitacaoList.Add(solicitacao[i]);
                }

            }
            Console.WriteLine("Aprovar empréstimo?[S/N]: ");
            string ler = Console.ReadLine().ToLower().Trim();

            //Condição para aprovar o empréstimo
            if (ler.Contains('s'))
            {
                //Busca o arquivo com os dados do solicitante
                DirectoryInfo dirEmp = new DirectoryInfo("C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\ContasBanco");
                var arq = dir.GetFiles($"{solicitacao[6]}.*");
                string[] conta = System.IO.File.ReadAllLines($"C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\SolicitaçõesEmpréstimos\\{solicitacao[6]}.txt");
                string[] dados = new string[18];
                foreach (string dado in conta)
                    dados = dado.Split(';');

                //Altera o saldo conforme o valor do empréstimo
                float saldoContaDestino = float.Parse(dados[17]);
                float valor = float.Parse(dados[18]);   
                saldoContaDestino += valor;
                dados[17] = saldoContaDestino.ToString();

                //Sobrescreve o mesmo arquivo com o saldo atualizado
                System.IO.StreamWriter arqPessoa = new StreamWriter($"C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\ContasBanco\\{solicitacao[6]}.txt");
                arqPessoa.WriteLine($"{dados[0]};{dados[1]};{dados[2]};{dados[3]};{dados[4]};{dados[5]};{dados[6]};{dados[7]};{dados[8]};{dados[9]};{dados[10]};" +
                    $"{dados[11]};{dados[12]};{dados[13]};{dados[14]};{dados[15]};{dados[16]};{dados[17]};");
                arqPessoa.Close();

                Console.WriteLine("\nTRANSAÇÃO CONCLUÍDA!!\nPressione Enter para continuar...");
                Console.ReadKey();
            }
            else
                return;

        }
    }
}
