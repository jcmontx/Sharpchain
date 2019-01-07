using System;

namespace Sharpchain.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("------Initializing blockchain------");
            Blockchain bc = new Blockchain();
            do
            {
                Console.WriteLine($"Index of last block: {bc.GetLastBlock().Index}");
                Console.WriteLine($"Mining attempts: {bc.GetLastBlock().Nonce}");
                Console.WriteLine($"-----Verifying validiy------");
                Console.WriteLine($"Blockchain is valid: {bc.IsValid()}");
                Console.WriteLine("------Input next block data------");
                var input = Console.ReadLine();
                bc.AddBlock(input);

            } while (true);
        }
    }
}
