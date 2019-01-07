using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sharpchain
{
    public class Blockchain
    {
        private List<Block> Blocks { get; set; } = new List<Block>();
        public Blockchain()
        {
            Blocks.Add(Block.GenerateFirstBlock());
        }

        public Block GetLastBlock()
        {
            return Blocks.Last();
        }

        public long AddBlock(dynamic data)
        {
            Block last = GetLastBlock();
            Blocks.Add(new Block(last, data));
            return GetLastBlock().Index;
        }

        public bool IsValid()
        {
            for (int i = 1; i < Blocks.Count; i++)
            {
                if (Blocks[i].Hash != Blocks[i].GenerateHash())
                    return false;
                if (Blocks[i].Index != Blocks[i - 1].Index + 1)
                    return false;
                if (Blocks[i].PreviousHash != Blocks[i - 1].Hash)
                    return false;
            }
            return true;
        }
    }
}
