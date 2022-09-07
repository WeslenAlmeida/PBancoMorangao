using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBancoMorangao
{
    internal class Agencia
    {
        public int NumAgencia { get; set; }
        public Endereco End { get; set; }
        public Atendente Atendente { get; set; }
        public Gerente Gerente { get; set; }

        public Agencia(string numAgencia, int funcionario)
        {
            if (numAgencia == "1")
            {
                if(funcionario == 1)
                {
                    Atendente = new();
                    Atendente.Nome = "Weslen";
                    Console.WriteLine($"Bem vindo atendente {Atendente.Nome}!!!");
                    Atendente.AbreConta();
                }
                else
                {
                    Gerente = new();
                    Gerente.Nome = "Davi";
                    Gerente.Senha = 1;
                    Console.Write($"Gerente {Gerente.Nome} digite sua senha: ");
                    int senha = int.Parse(Console.ReadLine());
                    if (Gerente.Autentica(senha))
                    {
                        Console.WriteLine("Acesso liberado!!!");
                        Gerente.AprovaConta();
                    }
                }
            }

            if (numAgencia == "2")
            {
                if (funcionario == 1)
                {
                    Atendente = new();
                    Atendente.Nome = "Baratão";
                    Console.WriteLine($"Bem vindo atendente {Atendente.Nome}!!!");
                    Atendente.AbreConta();
                }
                else
                {
                    Gerente = new();
                    Gerente.Nome = "Pestana";
                    Gerente.Senha = 2;
                    Console.Write($"Gerente {Gerente.Nome} digite sua senha: ");
                    int senha = int.Parse(Console.ReadLine());
                    if (Gerente.Autentica(senha))
                    {
                        Console.WriteLine("Acesso liberado!!!");
                        Gerente.AprovaConta();
                    }
                }
            }

            if (numAgencia == "3")
            {
                if (funcionario == 1)
                {
                    Atendente = new();
                    Atendente.Nome = "Mussarela";
                    Console.WriteLine($"Bem vindo atendente {Atendente.Nome}!!!");
                    Atendente.AbreConta();
                }
                else
                {
                    Gerente = new();
                    Gerente.Nome = "Moranguinho";
                    Gerente.Senha = 3;
                    Console.Write($"Gerente {Gerente.Nome} digite sua senha: ");
                    int senha = int.Parse(Console.ReadLine());
                    if (Gerente.Autentica(senha))
                    {
                        Console.WriteLine("Acesso liberado!!!");
                        Gerente.AprovaConta();
                    }
                }
            }
        }
    }
}
