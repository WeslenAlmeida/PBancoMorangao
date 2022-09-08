﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBancoMorangao
{
    internal class ContaVIP : ContaCorrente
    {
       
        public ContaVIP(string cpfCnpj)
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
        public bool SacarCVIP(float valor)
        {   //Verifica se o saldo ficar mais que R$ -5000,00 não permite efetuar o método
            if (this.Saldo - valor < -5000)
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
            if (SacarCVIP(valorSolicitado))
            {
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
            if (SacarCVIP(valor))
            {
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
                        if (SacarCVIP(saque))
                            AddExtrato(DadoCliente, $"SAQUE REALIZADO: {DateTime.Now} ---------- R${saque:N2}");
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
                            Console.WriteLine("\nDepósito realizado com sucesso!!!");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Não foi possível realizar o depósito na conta CPF/CNPJ: {DadoCliente}\nErro: {e.Message}");
                        }
                        Console.WriteLine("Tecle Enter para continuar...");
                        Console.ReadKey();
                        break;

                    case 3:
                        Console.Write("Digite o CPF/CNPJ do Destinatário: ");
                        string cpf = Console.ReadLine();
                        float transfere;
                        Console.Write("Digite o valor que deseja transferir: R$");
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
