using System;
using BlockChain.Structure;

namespace BlockChain
{
    class Program
    {
        static void Main(string[] args)
        {
            Block<String> genesis = new Block<string>("Genesis", 2);

            BlockChain<String> chain = new BlockChain<string>(genesis);

            for (int i = 0; i < 100; i++)
            {
                chain.AddBlock("Block " + i);
            }

            if (chain.IsValid()) chain.PrintChain();

            else Console.WriteLine("Invalid Chain");

            Console.ReadLine();
        }
    }
}
