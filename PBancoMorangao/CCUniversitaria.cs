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

        public CCUniversitaria(string cpfCnpj)
        {
            //Busca o arquivo que tem o CPF/CNPJ recebido como parâmetro
            DirectoryInfo dir = new DirectoryInfo("C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\ContasBanco");
            var arq = dir.GetFiles($"{cpfCnpj}.*");
            string[] solicita = System.IO.File.ReadAllLines($"C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\ContasBanco\\{cpfCnpj}.txt");
            string[] dados = new string[18];
            foreach (string dado in solicita)
                dados = dado.Split(';');

            //Verifica se o arquivo é do tipo PF, caso seja ela cria um objeto PF com os dados do arquivo
            if (solicita[0].Contains("Física"))
            {
                ClientePF pessoa = new(int.Parse(dados[0]), dados[2], dados[3], dados[4], DateTime.Parse(dados[5]), dados[6], float.Parse(dados[7]), (dados[8]));
                Pessoa = pessoa;
                Numconta = int.Parse(dados[0]);
                DadoCliente = dados[6];
            }
            //Senão cria um objeto do tipo PJ com os dados do arquivo
            else
            {
                ClientePJ empresa = new(int.Parse(dados[0]), dados[2], dados[3], dados[4], DateTime.Parse(dados[5]), dados[6], dados[7], float.Parse((dados[8])));
                Empresa = empresa;
                Numconta = int.Parse(dados[0]);
                DadoCliente = dados[6];
            }
            //Cria o objeto do tipo endereço com os dados do arquivo
            Endereco end = new(dados[9], dados[10], dados[11], dados[12], dados[13], dados[14], dados[15]);
            Saldo = float.Parse(dados[17]);
            Endereco = end;


        }
        
        public override string ToString()
        {
            return $"{Pessoa.ToString()}{Endereco.ToString()}Saldo = {Saldo};";
        }

        //Método para realizar o saque
        public bool SacarCUniver(float valor)
        {   //Verifica se o saldo ficar mais que R$ -1000,00 não permite efetuar o método
            if (this.Saldo - valor < -1000)
            {
                Console.WriteLine("Você não possui limite para realizar essa transação!");
                return false;
            }
            else
            {
                Sacar(valor, this.DadoCliente);
                Console.WriteLine("Débito/Pagamento realizado com sucesso!");
                return true;
            }
        }
        //Método para realizar transferência 
        public void Transferir(string cpfCnpjDestino, float valorSolicitado)
        {
            if (SacarCUniver(valorSolicitado))
            {
                Depositar(valorSolicitado, cpfCnpjDestino);
                Console.WriteLine("Transferência Realizada com sucesso!");
                AddExtrato(DadoCliente, $"TRANSFERÊNCIA PARA O CPF/CNPJ {cpfCnpjDestino}: {DateTime.Now} ---------- R${valorSolicitado:N2}");
                AddExtrato(cpfCnpjDestino, $"TRANSFERÊNCIA RECEBIDA DO CPF/CNPJ {DadoCliente}: {DateTime.Now} ---------- R${valorSolicitado:N2}");
                Console.WriteLine("\n Tecle Enter para continuar... ");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Não foi possível realizar a transação!");
                Console.WriteLine("\n Tecle Enter para continuar... ");
                Console.ReadKey();
            }
        }

        //Método para realizar pagamentos
        public void RealizarPagamento(float valor)
        {
            if (SacarCUniver(valor))
            {
                AddExtrato(DadoCliente, $"PAGAMENTO DE CONTA: {DateTime.Now} ---------- R${valor:N2}");
                Console.WriteLine("Pagamento realizado com sucesso!");
                Console.WriteLine("\n Tecle Enter para continuar... ");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Não foi possível realizar a transação!");
                Console.WriteLine("\n Tecle Enter para continuar... ");
                Console.ReadKey();
            }
        }

        //Método para realizar as operações da conta
        public void OperarCaixaEletro()
        {
            int operacao;
            do
            {
                operacao = MenuCaixaEletronico();
                switch (operacao)
                {
                    case 1:
                       
                        Console.Write("Digite o valor do saque desejado: R$");
                        float saque;
                        while (!float.TryParse(Console.ReadLine(), out saque))
                            Console.WriteLine("Digite somente números!");
                        if (SacarCUniver(saque))
                            AddExtrato(DadoCliente, $"SAQUE REALIZADO: {DateTime.Now} ---------- R${saque:N2}");

                        Console.WriteLine("\n Tecle Enter para continuar... ");
                        Console.ReadKey();
                        break;

                    case 2:

                        Console.Write("digite o valor que deseja depositar: R$");
                        float deposito;
                        while (!float.TryParse(Console.ReadLine(), out deposito))
                            Console.WriteLine("Digite somente números!");
                        try
                        {
                            Depositar(deposito, DadoCliente);
                            AddExtrato(DadoCliente, $"DEPÓSITO EM CONTA: {DateTime.Now} ---------- R${deposito:N2}");
                            Console.WriteLine("\nDepósito realizado com sucesso!!!\n Tecle Enter para continuar... ");
                            Console.ReadKey();
                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Não foi possível realizar o depósito na conta CPF/CNPJ: {DadoCliente}");
                            Console.WriteLine("\n Tecle Enter para continuar... ");
                            Console.ReadKey();
                        }
                        break;

                    case 3:
                        Console.Write("Digite o CPF do Destinatário: ");
                        string cpf = Console.ReadLine();
                        Console.Write("Digite o valor que deseja transferir: R$");
                        float transfere;
                        while (!float.TryParse(Console.ReadLine(), out transfere))
                            Console.WriteLine("Digite somente números!");
                        Transferir(cpf, transfere);
                        break;

                    case 4:
                        Console.WriteLine("Digite o valor do Boleto para pagamento: R$");
                        float pagamento;
                        while (!float.TryParse(Console.ReadLine(), out pagamento))
                            Console.WriteLine("Digite somente números!");
                        RealizarPagamento(pagamento);
                        break;

                    case 5:
                        GetExtrato(DadoCliente);
                        break;

                    case 6:
                        SolicitarEmprestimo(DadoCliente);
                        break;
                }
            } while (operacao != 0);
        }
    }
}
