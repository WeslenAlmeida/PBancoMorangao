using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBancoMorangao
{
    internal class Endereco
    {
        public int IdPessoa { get; set; }
        protected string Logradouro { get; set; }
        protected string Numero { get; set; }
        public string Complemento { get; set; }
        protected string Bairro { get; set; }
        protected string CEP { get; set; }
        protected string Cidade { get; set; }
        protected string Estado { get; set; }

        public Endereco()
        {

        }

        public Endereco(string logradouro, string numero, string complemento, string bairro, string cep, string cidade, string estado)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            CEP = cep;
            Cidade = cidade;
            Estado = estado;
        }
    
        public override string ToString()
        {
            return "Logradouro: " + Logradouro + ";Número: " + Numero + ";Complemento: " + Complemento +
              ";Bairro: " + Bairro + ";CEP: " + CEP + ";Cidade: " + Cidade + ";Estado: " + Estado + ";";
        }

        public string DadosEnd()
        {
            return $"{Logradouro};{Numero};{Complemento};{Bairro};{CEP};{Cidade};{Estado};";
        }
        //Método para cadastrar os dados de endereço 
        public string CadastraEndereco(int idPessoa)
        {
            Console.Write("Digite seu logradouro: ");
            Logradouro = Console.ReadLine();

            Console.Write("Digite seu número: ");
            Numero = Console.ReadLine();
           
            Console.Write("Digite o complemento: ");
            Complemento = Console.ReadLine();

            Console.Write("Digite seu bairro: ");
            Bairro = Console.ReadLine();

            Console.Write("Digite seu CEP: ");
            CEP = Console.ReadLine();

            Console.Write("Digite sua cidade: ");
            Cidade = Console.ReadLine();

            Console.Write("Digite seu estado: ");
            Estado = Console.ReadLine();

            return DadosEnd();
        }
    }

}
