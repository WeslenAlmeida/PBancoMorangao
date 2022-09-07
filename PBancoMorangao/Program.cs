using System;
using System.IO;
using System.Text;

namespace PBancoMorangao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuPrincipal();
        }
        static void MenuPrincipal()
        {
            int opcMenu;

            do
            {
                Console.Clear();
                Console.WriteLine("\n********************************** BANCO MORANGÃO **********************************");
                Console.WriteLine();
                Console.WriteLine("******************************** MENU PRINCIPAL **********************************\n");
                Console.WriteLine("\t\t\t\t1 - Não sou cliente ");
                Console.WriteLine("\t\t\t\t2 - Já sou cliente ");
                Console.WriteLine("\t\t\t\t3 - Acesso funcionários ");
                Console.WriteLine("\t\t\t\t0 - Sair");
                Console.Write("\t\t\t\tOpção: ");
                opcMenu = int.Parse(Console.ReadLine());
                switch (opcMenu)
                {
                    case 1:
                        char opc;
                        Console.WriteLine("Deseja se Cadastrar? Digite [s/n]");
                        opc = char.Parse(Console.ReadLine());
                        if (opc == 's')
                            NovoCliente();
                       
                        break;

                    case 2:
                        Console.WriteLine(" ♦ Digite [s] - Operações da Conta / [n] - Retornar para o Menu Principal");
                        opc = char.Parse(Console.ReadLine());

                        if (opc == 's')
                            Conta();
                       
                        break;

                    case 3:
                        int funcopc;
                        Console.WriteLine(" ♦ Digite [1] - Atendente / [2] - Gerente");
                        funcopc = int.Parse(Console.ReadLine());
                        Console.Clear();

                        Console.Write("Digite o Número da agência[1 - Zona Norte / 2 - Zona Leste / 3 - Zona Sul]: ");
                        string ag = Console.ReadLine();
                        new Agencia(ag, funcopc);
                        Console.WriteLine("Pressione Enter para continuar!!");
                        Console.ReadKey();

                        break;
                }
            } while (opcMenu != 0);
            Console.WriteLine("********** FIM **********");

            static void NovoCliente()
            {
                Console.Write("\nSOLICITAÇÃO DE CADASTRO:");
                Console.WriteLine();
                Console.Write("\nEscolha a opção: [Pessoa fisica: 1]  [Pessoa Juridica: 2]: ");
                int opc = int.Parse(Console.ReadLine());
                Console.WriteLine();
                if (opc == 1)
                {
                    Console.WriteLine("CADASTRO PESSOA FÍSICA: ");
                    PessoaPF pf1 = new();
                    pf1.SolicitaAberturaPF();
                    Console.WriteLine("CADASTRO REALIZADO COM SUCESSO! AGUARDANDO ANÁLISE DE APROVAÇÃO!");
                    Console.WriteLine("Pressione ENTER para retornar ao Menu Principal\n");
                    Console.ReadKey();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("CADASTRO PESSOA JURIDICA: ");
                    PessoaPJ pj1 = new();
                    pj1.SolicitarAberturaPJ();
                    Console.WriteLine("CADASTRO REALIZADO COM SUCESSO! AGUARDE ANÁLISE DE APROVAÇÃO");
                    Console.WriteLine("Pressione ENTER para retornar ao Menu Principal\n");
                    Console.ReadKey();
                    Console.Clear();

                    MenuPrincipal();
                }
            }
            static void Conta()
            {
                Console.WriteLine("Digite seu CPF ou CNPJ");
                string cpfCnpj = Console.ReadLine();
                string[] solicita = System.IO.File.ReadAllLines($"C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\ContasBanco\\{cpfCnpj}.txt");
                string[] dados = new string[18];

                foreach (string dado in solicita)
                    dados = dado.Split(';');

                if (dados[16].Contains("Conta Normal;"))
                {
                    ContaNormal conta = new(cpfCnpj);
                    conta.OperacoesCaixaEletr();
                    return;
                }
                else if (dados[16].Contains("Conta VIP;"))
                {
                    ContaVIP conta = new(cpfCnpj);
                    conta.OperacoesCaixaEletr();
                    return;
                }
                else
                {
                    CCUniversitaria conta = new(cpfCnpj);
                    conta.OperacoesCaixaEletr();
                    return;
                }
            }
        }
    }
}
