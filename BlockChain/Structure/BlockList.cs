using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlockChain.Structure
{
    public class BlockList<T>
    {
        public Block<T> Genesis { get; set; }
        public Block<T> LastBlock { get; set; }

        public void AddBlock()
        {

        }
    }
}
