using System;

namespace Pencil_Durability_Kata
{
    class Program
    {
        static void Main(string[] args)
        {
            var pencil = new Pencil();
            var paper = new Paper();

            while (true)
            {
                Console.Clear();
                Console.WriteLine(string.Join(" ", paper.Text));
                var writeThis = pencil.Write();
                paper.Text.AddRange(writeThis);
            }
        }
    }
}
