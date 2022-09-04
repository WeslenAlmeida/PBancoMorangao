using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBancoMorangao
{
    internal class PessoaPJ : Pessoa
    {
        private string Razao { get; set; }
        private string CNPJ { get; set; }
        private float Renda { get; set; }

        public PessoaPJ()
        {

        }

        public override string ToString()
        {
            return IdPessoa + ";Conta Jurídica;Agência: "+ Agencia + ";Nome: " + Nome + ";Telefone: " + Telefone + ";Data de Abertura CNPJ: " + Data.ToShortDateString() + ";Razão Social: " + Razao +
                ";CNPJ: " + CNPJ + ";Renda: " + Renda + ";";
        }

        //Método para receber os dados do usuário
        public string CadastraPJ(int id)
        {
            Console.WriteLine("***************************** BANCO MORANGÃO ********************************\n");
            Console.WriteLine("********** SOLICITAÇÃO DE ABERTURA DE CONTA PESSOA JURÍDICA **********\n");

            IdPessoa = id;

            Console.WriteLine("Digite o Número da agência [1-Zona Norte / 2-Zona Leste / 3-Zona Sul]: ");
            Agencia = Console.ReadLine();

            Console.Write("Digite o nome da empresa: ");
            Nome = Console.ReadLine();

            Console.Write("Digite o telefone: ");
            Telefone = Console.ReadLine();

            Console.Write("Digite sua data de abertura da empresa: ");
            Data = DateTime.Parse(Console.ReadLine());

            Console.Write("Digite a Razão Social: ");
            Razao = Console.ReadLine();

            Console.Write("Informe o CNPJ: ");
            CNPJ = Console.ReadLine();

            Console.Write("Informe sua renda: R$");
            Renda = float.Parse(Console.ReadLine());

            return ToString();
        }

        //Solicita a abertura de conta
        public void SolicitarAberturaPJ()
        {

            int id = getID();
            string pessoaPJ = CadastraPJ(id);

            Endereco end = new();
            string endereco = end.CadastraEndereco(id);

            try
            {
                //Cria o arquivo com os dados da pessoa e incrementa o contador do id
                System.IO.StreamWriter arqPessoa = new StreamWriter($"C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\Solicitações\\{id}.txt");
                arqPessoa.WriteLine(pessoaPJ + endereco);
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
