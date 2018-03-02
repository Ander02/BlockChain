﻿using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;
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

            var newBlock = new Block<T>(data, 2)
            {
                PreviousBlock = lastBlock
            };

            Blocks.Add(newBlock);
        }

        public bool IsValid()
        {
            var genesis = this.GetGenesisBlock();
            var currentBlock = this.GetLastBlock();

            while (currentBlock != null) currentBlock = currentBlock.PreviousBlock;

            if (currentBlock.Equals(genesis)) return true;

            else return false;
        }

        public void PrintChain()
        {
            foreach (var block in Blocks)
            {
                Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(t))
            }
        }
    }
}
