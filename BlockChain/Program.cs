using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using BlockChain.Structure;

namespace Blockchain
{
    public class Program
    {
        public static void Main(string[] args)
        {
            TestBlockChain();

            var host = BuildWebHost(args);

            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();


        public static void TestBlockChain()
        {
            Block<String> genesis = new Block<string>("Teste", 3);
            
            BlockChain<String> blockChain = new BlockChain<string>(genesis);

            blockChain.AddBlock("Teste2");
            blockChain.AddBlock("Teste3");
            blockChain.AddBlock("Teste4");
            blockChain.AddBlock("Teste5");
            blockChain.AddBlock("Teste6");
            blockChain.AddBlock("Teste7");
            blockChain.AddBlock("Teste8");

            if (blockChain.IsValid())
            {
                blockChain.PrintChain();
            }

        }

    }
}
