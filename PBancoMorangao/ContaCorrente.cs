using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBancoMorangao
{
    internal abstract class ContaCorrente
    {
        public int Numconta { get; set; }
        public float Saldo { get; set; }
        public PessoaPF Pessoa { get; set; }
        public PessoaPJ Empresa { get; set; }
        public Endereco Endereco { get; set; }
        public string DadoCliente { get; set; }


        public ContaCorrente()
        {
           
        }
       

        //Método para realizar depósito
        public void Depositar(float valor, string cpfCnpj)
        {
            //Busca o arquivo com os dados do solicitante
            DirectoryInfo dir = new DirectoryInfo("C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\ContasBanco");
            var arq = dir.GetFiles($"{cpfCnpj}.*");
            string[] conta = System.IO.File.ReadAllLines($"C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\ContasBanco\\{cpfCnpj}.txt");
            string[] dados = new string[18];
            foreach (string dado in conta)
                dados = dado.Split(';');

            //Altera o saldo conforme o valor de depósito
            float saldoContaDestino = float.Parse(dados[17]);
            saldoContaDestino += valor;
            dados[17] = saldoContaDestino.ToString();

            //Sobrescreve o mesmo arquivo com o saldo atualizado
            System.IO.StreamWriter arqPessoa = new StreamWriter($"C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\ContasBanco\\{cpfCnpj}.txt");
            arqPessoa.WriteLine($"{dados[0]};{dados[1]};{dados[2]};{dados[3]};{dados[4]};{dados[5]};{dados[6]};{dados[7]};{dados[8]};{dados[9]};{dados[10]};" +
                $"{dados[11]};{dados[12]};{dados[13]};{dados[14]};{dados[15]};{dados[16]};{dados[17]};");
            arqPessoa.Close();
        }

        protected void Sacar(float valor, string cpfCnpj)
        {
            //Busca o arquivo com os dados do solicitante
            DirectoryInfo dir = new DirectoryInfo("C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\ContasBanco");
            var arq = dir.GetFiles($"{cpfCnpj}.*");
            string[] conta = System.IO.File.ReadAllLines($"C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\ContasBanco\\{cpfCnpj}.txt");
            string[] dados = new string[18];
            foreach (string dado in conta)
                dados = dado.Split(';');

            //Altera o saldo conforme o valor de saque
            float saldoContaDestino = float.Parse(dados[17]);
            saldoContaDestino -= valor;
            dados[17] = saldoContaDestino.ToString();

            //Sobrescreve o mesmo arquivo com o saldo atualizado
            System.IO.StreamWriter arqPessoa = new StreamWriter($"C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\ContasBanco\\{cpfCnpj}.txt");
            arqPessoa.WriteLine($"{dados[0]};{dados[1]};{dados[2]};{dados[3]};{dados[4]};{dados[5]};{dados[6]};{dados[7]};{dados[8]};{dados[9]};{dados[10]};" +
                $"{dados[11]};{dados[12]};{dados[13]};{dados[14]};{dados[15]};{dados[16]};{dados[17]};");
            arqPessoa.Close();
        }

        public void SolicitaEmprestimo(string cpfCnpj, float valorEmprestimo)
        {
            Console.WriteLine("Digite o valor do");
            //Busca o arquivo com os dados do solicitante
            DirectoryInfo dir = new DirectoryInfo("C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\ContasBanco");
            var arq = dir.GetFiles($"{cpfCnpj}.*");
            string[] conta = System.IO.File.ReadAllLines($"C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\ContasBanco\\{cpfCnpj}.txt");
            string[] dados = new string[18];
            foreach (string dado in conta)
                dados = dado.Split(';');
        }


    }
}
