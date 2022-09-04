using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBancoMorangao
{
    internal class PessoaPF : Pessoa
    {
        private string CPF { get; set; }
        private float Renda { get; set; }
        private string Estudante { get; set; }

        public PessoaPF()
        {

        }
        public PessoaPF(int id, string nome, string agencia, string telefone, DateTime data, string cpf, float renda, string estudante)
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

            Console.WriteLine("Digite o Número da agência [1-Zona Norte / 2-Zona Leste / 3-Zona Sul]: ");
            Agencia = Console.ReadLine();

            Console.Write("Digite seu nome: ");
            Nome = Console.ReadLine();

            Console.Write("Digite eu telefone: ");
            Telefone = Console.ReadLine();

            Console.Write("Digite sua data de nascimento: ");
            Data = DateTime.Parse(Console.ReadLine());

            Console.Write("Digite seu CPF: ");
            CPF = Console.ReadLine();

            Console.Write("Informe sua renda: R$");
            Renda = float.Parse(Console.ReadLine());

            Console.Write("Estudante? S/N: ");
            string estudante = Console.ReadLine().ToLower().Trim();
            if (estudante == "s")
                Estudante ="s";
            else
                Estudante = "s";

            return DadosClientePF();
        }

        //Solicita a abertura de conta
        public void SolicitaAberturaPF()
        {
            
            int id = getID();

            string pessoaPF = CadastraPF(id);

            Endereco end = new();
            string endereco = end.CadastraEndereco(id);

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
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
