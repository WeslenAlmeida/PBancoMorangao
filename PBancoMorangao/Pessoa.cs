using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBancoMorangao
{
    internal class Pessoa
    {
        protected int IdPessoa { get; set; }
        protected string Nome { get; set; }
        protected string Telefone { get; set; }
        protected DateTime Data { get; set; }
        public string Agencia { get; set; }

        //Método para pegar o valor do Id no arquivo
        protected int getID()
        {
            string[] contador = System.IO.File.ReadAllLines($"C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\IdsContr\\ProxId.txt");
            string[] num = new string[1];  

            foreach (string cont in contador)
                num[0] = cont;

            int id = int.Parse(num[0]);

            return id;
        }

        //Método para devolver o Id no arquivo 
        protected void SaveID(int id)
        {
            StreamWriter idPessoa = new StreamWriter($"C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\IdsContr\\ProxId.txt");
            idPessoa.WriteLine(id);
            idPessoa.Close();
        }

    }
}