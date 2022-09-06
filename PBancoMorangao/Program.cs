using System;
using System.IO;

namespace PBancoMorangao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //PessoaPF pessoaPF = new PessoaPF();
            //pessoaPF.SolicitaAberturaPF();

            //Atendente atendente = new Atendente("01");
            //atendente.AbreConta();

            //Gerente gerente = new Gerente();
            //gerente.AprovaConta();

            //DirectoryInfo dir = new DirectoryInfo("C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\ContasBanco");
            //var dados = dir.GetFiles("33899767870.*");
            //Console.WriteLine(dados[0]);


            CCUniversitaria cc = new CCUniversitaria("33899767800");
         
            string cpf = Console.ReadLine();

            float valor =float.Parse(Console.ReadLine());
            cc.Transferir(cpf, valor);


            //Console.WriteLine(cc.Saldo);

            //string[] solicita = System.IO.File.ReadAllLines($"C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\ContasBanco\\29.txtConta Universitária.txt");
            //string[] dados = new string[16];


            //foreach(string dado in solicita)
            //    dados = dado.Split(';');




            //Console.WriteLine(dados[15]);




        }
    }
}
