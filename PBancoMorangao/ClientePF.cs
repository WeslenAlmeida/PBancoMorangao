using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PBancoMorangao
{
    internal class ClientePF : Pessoa
    {
        private string CPF { get; set; }
        private float Renda { get; set; }
        private string Estudante { get; set; }

        public ClientePF()
        {

        }
        public ClientePF(int id, string nome, string agencia, string telefone, DateTime data, string cpf, float renda, string estudante)
        {
            IdPessoa = id;
            Agencia = agencia;  
            Nome = nome;
            Telefone = telefone;
            Data = data;
            CPF = cpf;
            Renda = renda;
            Estudante = estudante;
        }
        public override string ToString()
        {
            return IdPessoa + ";Conta Física;Agência: " + Agencia + ";Nome: " + Nome + ";Telefone: " + Telefone + ";Data de Nascimento: " + Data.ToShortDateString() + ";CPF: " + CPF +
                ";Renda: R$" + Renda + ";Estudante: " + Estudante + ";";
        }

        private string DadosClientePF()
        {
            return $"{IdPessoa};Conta Física;{Agencia};{Nome};{Telefone};{Data.ToShortDateString()};{CPF};{Renda};{Estudante};";
        }

        //Método para receber os dados do usuário
        private string CadastraPF(int id)
        {
            Console.WriteLine("***************************** BANCO MORANGÃO ********************************\n");
            Console.WriteLine("********** SOLICITAÇÃO DE ABERTURA DE CONTA CADASTRO PESSOA FÍSICA **********\n");

            IdPessoa = id;

            do
            {
                Console.WriteLine("Digite o Número da agência [1-Zona Norte / 2-Zona Leste / 3-Zona Sul]: ");
                Agencia = Console.ReadLine();
                if(Agencia != "1" && Agencia != "2" && Agencia != "3")
                {
                    Console.WriteLine("Agencia inválida!");
                    Thread.Sleep(2000);
                    Console.Clear();
                }
            } while(Agencia != "1" && Agencia != "2" && Agencia != "3" );    
           

            Console.Write("Digite seu nome: ");
            Nome = Console.ReadLine();

            Console.Write("Digite eu telefone: ");
            Telefone = Console.ReadLine();

            Console.Write("Digite sua data de nascimento: ");
            DateTime data;
            while (!DateTime.TryParse(Console.ReadLine(), out data))
                Console.WriteLine("Formato de data incorreto!");
            Data = data;

            Console.Write("Digite seu CPF: ");
            CPF = Console.ReadLine();

            Console.Write("Informe sua renda: R$");
            float renda;
            while (!float.TryParse(Console.ReadLine(), out renda))
                Console.WriteLine("Digite somente números!");
            Renda = renda;

            string estudante;
            do
            {
                Console.Write("Estudante? S/N: ");
                estudante = Console.ReadLine().ToLower().Trim();
            } while (estudante != "s" && estudante != "n");
            Estudante = estudante;

            return DadosClientePF();
        }

        //Solicita a abertura de conta
        public void SolicitaAberturaPF()
        {
            
            int id = GetID();

            string pessoaPF = CadastraPF(id);

            Endereco end = new();
            string endereco = end.CadastrarEndereco();

            try
            {
                //Cria o arquivo com os dados da pessoa e incrementa o contador do id
                StreamWriter arqPessoa = new StreamWriter($"C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\Solicitações\\{CPF}.txt");
                arqPessoa.WriteLine(pessoaPF + endereco);
                arqPessoa.Close();
                id++;
                SaveID(id);
                Console.WriteLine("SOLICITAÇÃO DE ABERTURA DE CONTA REALIZADA COM SUCESSO!!!");
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
        }
    }
}
