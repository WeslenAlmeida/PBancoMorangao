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
            return "\nID: " + IdPessoa + ";\nNome: " + Nome + ";\nTelefone: " + Telefone + ";\nData de Abertura CNPJ: " + Data + ";\nRazão Social: " + Razao +
                ";\nCNPJ: " + CNPJ + ";\nRenda: " + Renda + ";";
        }

        public string CadastraPJ(int id)
        {
            Console.WriteLine("***************************** BANCO MORANGÃO ********************************\n");
            Console.WriteLine("********** SOLICITAÇÃO DE ABERTURA DE CONTA PESSOA JURÍDICA **********\n");

            IdPessoa = id;

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

        public void SolicitarAberturaPJ()
        {

            int id = getID();

            string pessoaPJ = CadastraPJ(id);

            Endereco end = new();
            string endereco = end.CadastraEndereco(id);

            try
            {
                //Cria o arquivo com os dados da pessoa e incrementa o contador do id
                System.IO.StreamWriter arqPessoa = new StreamWriter($"C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\Solicitações\\Solicitação número {id}-PJ.txt");
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
