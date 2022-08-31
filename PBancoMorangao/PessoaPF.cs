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
        private DateTime DataNasc { get; set; }
        private string CPF { get; set; }
        private float Renda { get; set; }
        private char Estudante { get; set; }
      
        public PessoaPF()
        {

        }

        public override string ToString()
        {
            return "\nID: " +IdPessoa + ";\nNome: " + Nome + ";\nTelefone: " + Telefone + ";\nData de Nascimento: " + DataNasc + ";\nCPF: " + CPF +
                ";\nRenda: R$" + Renda + ";\nEstudante: " + Estudante + ",";
        }

        private string CadastraPF(int id)
        {
            IdPessoa = id;

            Console.Write("Digite seu nome: ");
            Nome = Console.ReadLine();

            Console.Write("Digite eu telefone: ");
            Telefone = Console.ReadLine();

            Console.Write("Digite sua data de nascimento: ");
            DataNasc = DateTime.Parse(Console.ReadLine());

            Console.Write("Digite seu CPF: ");
            CPF = Console.ReadLine();

            Console.Write("Informe sua renda: R$");
            Renda = float.Parse(Console.ReadLine());

            Console.Write("Estudante? S/N: ");
            string estudante = Console.ReadLine().ToLower().Trim();
            if (estudante == "s")
                Estudante = 's';
            else
                Estudante = 'n';

            return ToString();
        }

        public void SolicitarAberturaPF()
        {
            
            int id = getID();

            string pessoaPF = CadastraPF(id);

            Endereco end = new();
            string endereco = end.CadastraEndereco(id);

            try
            {
                //Cria o arquivo com os dados da pessoa e incrementa o contador do id
                StreamWriter arqPessoa = new StreamWriter($"C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\Solicitações\\Solicitação número {id}-PF.txt");
                arqPessoa.WriteLine(pessoaPF + endereco);
                arqPessoa.Close();
                id++;
                SaveID(id);
               

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
        }
    }
}
