using BlockChain.Util;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace BlockChain.Structure
{
    public class Block<T>
    {
        public String Hash { get; set; }
        public Block<T> PreviousBlock { get; set; }
        public T Data { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Difficulty { get; set; }
        public int Nonce { get; set; }

        public Block(T data, int difficulty = 1)
        {
            this.Data = data;
            this.CreatedAt = DateTime.Now;
            this.Difficulty = difficulty;
            this.Nonce = 0;
            this.PreviousBlock = null;

            this.Mine();
        }

        public String GenerateSHA256()
        {
            var stringBlock = JsonConvert.SerializeObject(this.Data) + this.CreatedAt + this.Difficulty + this.Nonce;
            var bytes = new SHA256Managed().ComputeHash(Encoding.ASCII.GetBytes(stringBlock));

            return bytes.ToBase64();
        }

        private bool Mine()
        {
            this.Hash = this.GenerateSHA256();

            while (!Regex.IsMatch(this.Hash, "^(0){" + this.Difficulty + "}"))
            {
                try
                {
                    this.Nonce++;
                    this.Hash = this.GenerateSHA256();
                }
                catch (Exception)
                {
                    return false;
                }
            }
            return true;
        }

        public void PrintBlock()
        {
            Console.WriteLine(JsonConvert.SerializeObject(new
            {
                this.Difficulty,
                this.Data,
                this.Nonce,
                this.Hash,
                this.CreatedAt,
                PreviousHash = this.PreviousBlock?.Hash
            }));
        }
    }
}
