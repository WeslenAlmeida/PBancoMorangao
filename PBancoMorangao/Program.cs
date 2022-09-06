using System;
using System.IO;
using System.Text;

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
            //cc.Transferir("12345678910", 200);

            cc.GetExtrato("33899767800");

            //Gerente gerente = new Gerente();
            //gerente.AprovaEmprestimo();


            //Console.WriteLine(cc.Saldo);

            //string[] solicita = System.IO.File.ReadAllLines($"C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\ContasBanco\\29.txtConta Universitária.txt");
            //string[] dados = new string[16];


            //foreach(string dado in solicita)
            //    dados = dado.Split(';');

            //Console.WriteLine(dados[15]);


            //string caminho = "C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\Extratos\\texto.txt";

            //string texto = $"{DateTime.Now}teste\n";

            //File.AppendAllText(caminho, texto);


            //FileStream fs = File.OpenRead(caminho);

            //byte[] b = new byte[1024];
            //UTF8Encoding temp = new UTF8Encoding(true);

            //while (fs.Read(b, 0, b.Length) > 0)
            //{
            //    Console.WriteLine(temp.GetString(b));
            //}



        }
    }
}
