using System;

namespace Pencil_Durability_Kata
{
    class Program
    {
        static void Main(string[] args)
        {
            var pencil = new Pencil();
            while (true)
            {
                pencil.Write();
                Console.WriteLine(pencil.PointDurability);
            }
        }
    }
}
