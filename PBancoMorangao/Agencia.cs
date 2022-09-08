using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBancoMorangao
{
    internal class Agencia
    {
        public string NumAgencia { get; set; }
        public Endereco End { get; set; }
        public Atendente Atendente { get; set; }
        public Gerente Gerente { get; set; }

        /* O parâmetro recebido pelo método construtor
         * busca o Gerente e o Atendente da sua respectiva
         * agência
         */

        public Agencia(string numAgencia, int funcionario)
        {
            NumAgencia = numAgencia;

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
                        Console.WriteLine("Acesso liberado!!!\n");
                        string op;
                        do
                        {
                            Console.WriteLine("Digite [1] Para aprovação de conta / [2] Para aprovação de empréstimo");
                            op = Console.ReadLine();
                            if(op != "1" && op != "2")
                                Console.WriteLine("Opção inválida!");

                        } while (op != "1" && op != "2");
                       
                        if (op.Contains("1"))
                            Gerente.AprovaConta();
                        else
                            Gerente.AprovaEmprestimo();
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
                        Console.WriteLine("Acesso liberado!!!\n");
                        string op;
                        do
                        {
                            Console.WriteLine("Digite [1] Para aprovação de conta / [2] Para aprovação de empréstimo");
                            op = Console.ReadLine();
                            if (op != "1" && op != "2")
                                Console.WriteLine("Opção inválida!");

                        } while (op != "1" && op != "2");

                        if (op.Contains("s"))
                            Gerente.AprovaConta();
                        else
                            Gerente.AprovaEmprestimo();

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
                        Console.WriteLine("Acesso liberado!!!\n");
                        string op;
                        do
                        {
                            Console.WriteLine("Digite [1] Para aprovação de conta / [2] Para aprovação de empréstimo");
                            op = Console.ReadLine();
                            if (op != "1" && op != "2")
                                Console.WriteLine("Opção inválida!");

                        } while (op != "1" && op != "2");

                        if (op.Contains("s"))
                            Gerente.AprovaConta();
                        else
                            Gerente.AprovaEmprestimo();
                    }
                }
            }
        }
    }
}
