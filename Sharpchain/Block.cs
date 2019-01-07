using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Sharpchain
{
    public class Block
    {
        public Block(Block prev, dynamic data = null)
        {
            Data = data;
            Index = prev.Index + 1;
            PreviousHash = prev.Hash;
            Timestamp = DateTime.UtcNow;
            Nonce = 0;
            Mine();
        }

        private void Mine()
        {
            do
            {
                Nonce++;
                Hash = GenerateHash();
            } while (!Hash.StartsWith("00"));
        }

        private Block() { }

        public string GenerateHash()
        {
            return Sha256($"{PreviousHash}-{JsonConvert.SerializeObject(Data)}-{Index}-{Timestamp}-{Nonce}");
        }

        public string Hash { get; private set; }
        public dynamic Data { get; private set; }
        public long Index { get; private set; }
        public string PreviousHash { get; private set; }
        public DateTime Timestamp { get; set; }
        public int Nonce { get; private set; }

        private static string Sha256(string input)
        {
            var crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(input));
            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }
            return hash;
        }

        public static Block GenerateFirstBlock()
        {
            var block = new Block()
            {
                Data = "Seed",
                Index = 0,
                PreviousHash = "Seed"
            };
            block.Hash = block.GenerateHash();
            return block;
        }
    }
}
