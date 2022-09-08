using System;
using System.IO;
using System.Text;
using System.Threading;

namespace PBancoMorangao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MenuPrincipal();
        }

        //Menu principal do banco
        static void MenuPrincipal()
        {
            string opcMenu;

            do
            {
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
                    opcMenu = Console.ReadLine();
                    if(opcMenu != "0" && opcMenu != "1" && opcMenu != "2" && opcMenu != "3")
                    {
                        Console.WriteLine("\n\t\t\t\tOpção inválida!");
                        Thread.Sleep(2000);
                    }

                } while (opcMenu != "0" && opcMenu != "1" && opcMenu != "2" && opcMenu != "3");
                
                switch (opcMenu)
                {
                    case "1":
                        char opc;
                        Console.WriteLine("Deseja se Cadastrar? Digite [s/n]");
                        while (!char.TryParse(Console.ReadLine(), out opc) && opc != 's' && opc != 'n')
                            Console.WriteLine("Opção inválida!");
                        if (opc == 's')
                            NovoCliente();
                       
                        break;

                    case "2":
                        Console.WriteLine("Operações da Conta");
                        Conta();
                       
                        break;

                    case "3":
                        int funcopc;
                        Console.WriteLine("Digite [1] - Atendente / [2] - Gerente");
                        while (!int.TryParse(Console.ReadLine(), out funcopc) && funcopc != 1 && funcopc != 2)
                            Console.WriteLine("Opção inválida!");
                        Console.Clear();

                        string ag;
                        do
                        {
                            Console.Write("Digite o Número da agência[1 - Zona Norte / 2 - Zona Leste / 3 - Zona Sul]: ");
                            ag = Console.ReadLine();
                            if (ag != "1" && ag != "2" && ag != "3")
                            {
                                Console.WriteLine("Opção inválida!");
                                Thread.Sleep(2000);
                                Console.Clear() ;   
                            }

                        } while (ag != "1" && ag != "2" && ag != "3");

                        new Agencia(ag, funcopc);
                        Console.WriteLine("Pressione Enter para continuar!!");
                        Console.ReadKey();
                        break;
                }
            } while (opcMenu != "0");
            Console.WriteLine("********** FIM **********");

            //Cria um novo cliente
            static void NovoCliente()
            {
                Console.Write("\nSOLICITAÇÃO DE CADASTRO:");
                Console.WriteLine();
                Console.Write("\nEscolha a opção: [Pessoa fisica: 1]  [Pessoa Juridica: 2]: ");
                int opc;
                while (!int.TryParse(Console.ReadLine(), out opc) && opc != 1 && opc != 2)
                    Console.WriteLine("Opção inválida!");
                Console.WriteLine();

                //Cadastra a pessoa física
                if (opc == 1)
                {
                    Console.WriteLine("CADASTRO PESSOA FÍSICA: ");
                    ClientePF pf1 = new();
                    pf1.SolicitaAberturaPF();
                    Console.WriteLine("CADASTRO REALIZADO COM SUCESSO! AGUARDANDO ANÁLISE DE APROVAÇÃO!");
                    Console.WriteLine("Pressione ENTER para retornar ao Menu Principal\n");
                    Console.ReadKey();
                    Console.Clear();
                }
                //Cadastra a pessoa jurídica
                else
                {
                    Console.WriteLine("CADASTRO PESSOA JURIDICA: ");
                    ClientePJ pj1 = new();
                    pj1.SolicitarAberturaPJ();
                    Console.WriteLine("CADASTRO REALIZADO COM SUCESSO! AGUARDE ANÁLISE DE APROVAÇÃO");
                    Console.WriteLine("Pressione ENTER para retornar ao Menu Principal\n");
                    Console.ReadKey();
                    Console.Clear();

                    MenuPrincipal();
                }
            }
            //Acessa a conta já existente
            static void Conta()
            {
                try
                {
                    Console.WriteLine("Digite seu CPF ou CNPJ: ");
                    string cpfCnpj = Console.ReadLine();
                    string[] solicita = System.IO.File.ReadAllLines($"C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\ContasBanco\\{cpfCnpj}.txt");
                    string[] dados = new string[18];

                    foreach (string dado in solicita)
                        dados = dado.Split(';');

                    //Acessa a conta normal
                    if (dados[16].Contains("Normal"))
                    {
                        ContaNormal conta = new(cpfCnpj);
                        conta.OperarCaixaEletro();
                        return;
                    }
                    //Acessa a conta VIP
                    else if (dados[16].Contains("VIP"))
                    {
                        ContaVIP conta = new(cpfCnpj);
                        conta.OperarCaixaEletro();
                        return;
                    }
                    //Acessa a conta Universitária
                    else if (dados[16].Contains("Universitária"))
                    {
                        CCUniversitaria conta = new(cpfCnpj);
                        conta.OperarCaixaEletro();
                        return;
                    }
                }catch(Exception e)
                {
                    Console.WriteLine($"Nao foi possível encontrar a conta solicitada!!!!\nErro: {e.Message}");
                    Console.WriteLine("\n Tecle Enter para continuar... ");
                    Console.ReadKey();
                }
            }
        }
    }
}
