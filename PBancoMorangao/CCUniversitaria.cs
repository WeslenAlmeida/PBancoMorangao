using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBancoMorangao
{
    internal class CCUniversitaria : ContaCorrente
    {
        public CCUniversitaria(string cpf)
        {
            DirectoryInfo dir = new DirectoryInfo("C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\ContasBanco");
            var arq = dir.GetFiles($"{cpf}.*");
            string[] solicita = System.IO.File.ReadAllLines($"C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\ContasBanco\\{cpf}.txt");
            string[] dados = new string[17];
            foreach (string dado in solicita)
                dados = dado.Split(';');

            PessoaPF pessoa = new(int.Parse(dados[0]), dados[1], dados[2], dados[3], DateTime.Parse(dados[4]), dados[5], float.Parse(dados[6]), (dados[7]));
            Endereco end = new(dados[8], dados[9], dados[10], dados[11], dados[12], dados[13], dados[14]);
            Saldo = float.Parse(dados[16]);

            Endereco = end;
            Pessoa = pessoa;

        }

        public override string ToString()
        {
            return $"{Pessoa.ToString()}{Endereco.ToString()}Saldo = {Saldo};";
        }
        public override void Sacar(float valor)
        {
            if (Saldo <  -1000)
                Console.WriteLine("Não foi possível pois o valor do saque é maior que o limite da conta!");
            else
                Saldo -= valor;
        }
    }
}
