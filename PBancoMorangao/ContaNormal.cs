﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBancoMorangao
{
    internal class ContaNormal : ContaCorrente
    {
        public ContaNormal(string cpfCnpj)
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
                PessoaPF pessoa = new(int.Parse(dados[0]), dados[2], dados[3], dados[4], DateTime.Parse(dados[5]), dados[6], float.Parse(dados[7]), (dados[8]));
                Pessoa = pessoa;
                Numconta = int.Parse(dados[0]); 
            }
            //Senão cria um objeto do tipo PJ com os dados do arquivo
            else
            {
                PessoaPJ empresa = new(int.Parse(dados[0]), dados[2], dados[3], dados[4], DateTime.Parse(dados[5]), dados[6], dados[7], float.Parse((dados[8])));
                Empresa = empresa;
                Numconta = int.Parse(dados[0]);
            }
            //Cria o objeto do tipo endereço com os dados do arquivo
            Endereco end = new(dados[9], dados[10], dados[11], dados[12], dados[13], dados[14], dados[15]);
            Saldo = float.Parse(dados[17]);
            Endereco = end;
        }
        public void SacarContNorm(float valor)
        {   //Verifica se o saldo ficar mais que R$ -3000,00 não permite efetuar o método
            if (this.Saldo - valor < -3000)
            {
                Console.WriteLine("Você não possui limite para realizar essa transação!");
                return;
            }
            else
            {
                Sacar(valor, this.DadoCliente);
                Console.WriteLine("Débito/Pagamento realizado com sucesso!");
            }
        }
        //Método para realizar transferência 
        public void Transferir(string cpfCnpjDestino, float valorSolicitado)
        {
            SacarContNorm(valorSolicitado);
            Depositar(valorSolicitado, cpfCnpjDestino);
        }

        //Método para realizar pagamentos
        public void RealizaPagamento(float valor)
        {
            SacarContNorm(valor);
        }
    }
}
