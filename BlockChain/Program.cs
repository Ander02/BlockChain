using System;
using BlockChain.Structure;

namespace BlockChain
{
    public static class Opcoes
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
                var genesis = new Block<string>(Console.ReadLine(), difficulty);
                var chain = new BlockChain<string>(genesis);

                int opcao = 0;
                do
                {
                    Console.WriteLine("Escolha dentre uma das opções abaixo");
                    Console.WriteLine("1 - Adicionar Bloco");
                    Console.WriteLine("2 - Ver último bloco");
                    Console.WriteLine("3 - Ver primeiro bloco");
                    Console.WriteLine("4 - Ver todos os blocos");
                    Console.WriteLine("5 - Ver dificuldade");
                    Console.WriteLine("0 - Sair");

                    if (!int.TryParse(Console.ReadLine(), out opcao)) opcao = -1;

                    switch (opcao)
                    {
                        case 0:
                            Console.WriteLine("Byeee");
                            return;

                        case 1:
                            Console.WriteLine();
                            break;
                        case 2:
                            Console.WriteLine("O último bloco é: ");
                            chain.GetLastBlock().PrintBlock();
                            break;
                        case 3:
                            Console.WriteLine("O primeiro bloco é: ");
                            chain.GetGenesisBlock().PrintBlock();
                            break;
                        case 4:
                            chain.PrintChain();
                            break;
                        case 5:
                            Console.WriteLine("A dificuldade dessa chain é de {0}", difficulty);
                            break;
                    }

                } while (opcao < 0);
            }
        }
    }
}
