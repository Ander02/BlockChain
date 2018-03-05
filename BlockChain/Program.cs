using System;
using BlockChain.Structure;

namespace BlockChain
{
    public class Program
    {
        static void Main(string[] args)
        { 
            Console.WriteLine("Bem Vindo ao BlockChain Structure");

            int difficulty = 1;
            do
            {
                Console.WriteLine("Escolha uma dificuldade para sua blockchain entre 1 e 5: ");
                Console.Write(">");

                if (!int.TryParse(Console.ReadLine(), out difficulty)) difficulty = 0;

            } while (difficulty <= 0 || difficulty > 5);

            Console.WriteLine("Digite o valor do bloco Gênesis");
            Console.Write(">");

            var tInicio = DateTime.Now;
            var genesis = new Block<string>(Console.ReadLine(), difficulty);
            var chain = new BlockChain<string>(genesis);
            var tFim = DateTime.Now;

            Console.WriteLine("O bloco gênesis é: ");
            chain.GetGenesisBlock().PrintBlock();
            Console.WriteLine();
            Console.WriteLine("Esse bloco demorou {0} ms para ser criado: ", (tFim - tInicio).Milliseconds);
            Console.WriteLine();

            int opcao = 0;
            do
            {
                Console.WriteLine("Escolha dentre uma das opções abaixo");
                Console.WriteLine("1 - Adicionar Bloco");
                Console.WriteLine("2 - Ver último bloco");
                Console.WriteLine("3 - Ver primeiro bloco");
                Console.WriteLine("4 - Ver todos os blocos");
                Console.WriteLine("5 - Ver dificuldade");
                Console.WriteLine("9 - Limpar  Console");
                Console.WriteLine("0 - Sair");
                Console.Write(">");

                if (!Int32.TryParse(Console.ReadLine(), out opcao)) opcao = -1;

                switch (opcao)
                {
                    case 1:
                        Console.WriteLine("Digite o valor do bloco");
                        Console.Write(">");

                        tInicio = DateTime.Now;
                        chain.AddBlock(Console.ReadLine());
                        tFim = DateTime.Now;

                        Console.WriteLine();
                        Console.WriteLine("O bloco inserido foi: ");
                        chain.GetLastBlock().PrintBlock();
                        Console.WriteLine();
                        Console.WriteLine("Esse bloco demorou {0} ms para ser criado: " , (tFim - tInicio).Milliseconds);
                        Console.WriteLine();

                        break;
                    case 2:
                        Console.WriteLine("O último bloco é: ");
                        chain.GetLastBlock().PrintBlock();
                        Console.WriteLine();
                        break;
                    case 3:
                        Console.WriteLine("O primeiro bloco é: ");
                        chain.GetGenesisBlock().PrintBlock();
                        Console.WriteLine();
                        break;
                    case 4:
                        chain.PrintChain();
                        Console.WriteLine();
                        break;
                    case 5:
                        Console.WriteLine("A dificuldade dessa BlockChain é: {0}", difficulty);
                        Console.WriteLine();
                        break;
                    case 9:
                        Console.Clear();
                        break;
                }

            } while (opcao > 0);
            Console.WriteLine("Byeeee");
        }
    }
}

