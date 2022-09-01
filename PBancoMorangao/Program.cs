using System;


namespace PBancoMorangao
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Gerente gerente = new Gerente();
            bool teste = gerente.Autentica(1235);
            
            Console.WriteLine(teste);

            Atendente atendente = new Atendente();
            atendente.AbreConta();
        }
    }
}
