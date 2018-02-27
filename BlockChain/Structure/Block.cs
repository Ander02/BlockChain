using BlockChain.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlockChain.Structure
{
    public class Block<T>
    {
        public String Hash { get; set; }
        public String PreviousHash { get; set; }
        public T Data { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Difficulty { get; set; }
        public int Nonce { get; set; }

        public Block(string previousHash, T data, int difficulty = 1)
        {
            this.PreviousHash = previousHash;
            this.Data = data;
            this.CreatedAt = DateTime.Now;
            this.Difficulty = difficulty;
            this.Nonce = 0;

            this.Mine();
        }

        public String GenerateSHA256()
        {
            var stringBlock = Newtonsoft.Json.JsonConvert.SerializeObject(this.Data) + this.CreatedAt + this.Difficulty + this.Nonce;
            var bytes = new SHA256Managed().ComputeHash(Encoding.ASCII.GetBytes(stringBlock));

            return bytes.ToBase64();
        }

        private bool Mine()
        {
            this.Hash = this.GenerateSHA256();

            while (!Regex.IsMatch(this.Hash.Substring(0, this.Difficulty), "^(0){" + this.Difficulty + "}"))
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

    }
}
