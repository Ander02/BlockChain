using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public Block<T> GetGenesisBlock()
        {
            return Blocks.FirstOrDefault();
        }

        public Block<T> GetLastBlock()
        {
            return Blocks.LastOrDefault();
        }

        public void AddBlock(T data)
        {
            var lastBlock = this.GetLastBlock();

            var newBlock = new Block<T>(data, this.Difficulty)
            {
                PreviousBlock = lastBlock
            };

            Blocks.Add(newBlock);
        }

        public bool IsValid()
        {
            var currentBlock = this.GetLastBlock();

            while (currentBlock.PreviousBlock != null) currentBlock = currentBlock.PreviousBlock;

            if (currentBlock.Equals(this.GetGenesisBlock())) return true;

            else return false;
        }

        public void PrintChain()
        {
            foreach (var block in Blocks)
            {
                Console.WriteLine(JsonConvert.SerializeObject(new {
                    block.Difficulty,
                    block.Data,
                    block.Nonce,
                    block.Hash,
                    block.CreatedAt,
                    PreviousHash = block.PreviousBlock != null ? block.PreviousBlock.Hash : null
                }));
            }
        }
    }
}
