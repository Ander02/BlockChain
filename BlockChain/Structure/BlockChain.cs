using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChain.Structure
{
    public class BlockChain<T>
    {
        public List<Block<T>> Blocks { get; set; }
        public int Difficulty { get; set; }

        public BlockChain(Block<T> block)
        {
            this.Blocks = new List<Block<T>>();
            this.Difficulty = block.Difficulty;
            this.Blocks.Add(block);
        }

        public Block<T> GetLastBlock()
        {
            return Blocks.LastOrDefault();
        }

        public void AddBlock(T data)
        {
            var lastBlock = this.GetLastBlock();

            var newBlock = new Block<T>(data, lastBlock.Difficulty)
            {
                PreviousHash = lastBlock.Hash
            };

            Blocks.Add(newBlock);
        }

        public bool IsValid()
        {
            for (int i = 1; i <= this.Blocks.Count-1 ; i++)
            {
                var currentBlock = this.Blocks.ElementAt(i);
                var previousBlock = this.Blocks.ElementAt(i - 1);

                if (currentBlock.PreviousHash != previousBlock.Hash) return false;
            }
            return true;
        }

        public void PrintChain()
        {
            foreach (var block in Blocks)
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(block));
            }
        }
    }
}
