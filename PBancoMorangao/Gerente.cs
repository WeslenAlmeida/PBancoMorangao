﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBancoMorangao
{
    internal class Gerente : Funcionario 
    {
        private int Senha { get; set; }

        public Gerente()
        {
            this.Nome = "Baratão";
            this.Senha = 12345;
        }

        //Método para Verificar a senha do Gerente
        public bool Autentica(int senha)
        {
            if (this.Senha == senha)
                return true;
            return false;
        }

        public void AprovaConta()
        {
            //Verifica a quantidade de solicitações
            List<string> solicitacoes = new List<string>();
            System.IO.DirectoryInfo dir = new DirectoryInfo("C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\AguarAprov");
            foreach (var file in dir.GetFiles())
            {
                solicitacoes.Add(file.Name);
            }

            //Verifica caso não tenha solicitação no diretório ele sai do método
            if (solicitacoes.Count == 0)
            {
                Console.WriteLine("Não há solicitações no momento!");
                return;
            }

            else
                Console.WriteLine($"Há {solicitacoes.Count} solicitações  pendentes!");

            

            //Busca o arquivo no caminho definido
            string[] solicita = System.IO.File.ReadAllLines($"C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\AguarAprov\\{solicitacoes.First()}");
            string[] solicitacao;

            List<string> solicitacaoList = new();

            Console.WriteLine($"\nDados da Solicitação: ");

            //Laço para mostrar na tela e inserir os dados do cliente na lista
            foreach (string cont in solicita)
            {
                solicitacao = cont.Split(';');

                for (int i = 0; i < solicitacao.Length; i++)
                {
                    Console.WriteLine(solicitacao[i]);
                    solicitacaoList.Add(solicitacao[i]);
                }

            }
            Console.WriteLine(solicitacoes.First());
            Console.WriteLine("Aprovar conta?[S/N]: ");
            string ler = Console.ReadLine().ToLower().Trim();

            //Condição para aprovar a conta solicitada pelo atendente
            if (ler.Contains('s'))
            {
                System.IO.StreamWriter arqPessoa = new StreamWriter($"C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\AguarAprov\\{solicitacoes.First()}");
                arqPessoa.WriteLine($"{solicita[0]}0;");
                arqPessoa.Close();
                File.Move($"C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\AguarAprov\\{solicitacoes.First()}",
                            $"C:\\Users\\wessm\\source\\repos\\PBancoMorangao\\ContasBanco\\{solicitacoes.First()}");
            }
            else
                return;
        }
    }
}
