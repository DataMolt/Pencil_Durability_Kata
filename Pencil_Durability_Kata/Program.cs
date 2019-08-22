using System;
using System.Collections.Generic;

namespace Pencil_Durability_Kata
{
    class Program
    {
        static void Main(string[] args)
        {
            var paper = new Paper();
            var pencilDrawer = new Stack<IWritingUtensil>();
            var pencil = new Pencil();
            var runApplication = new RunApplication(paper, pencil, pencilDrawer);
            runApplication.RunApp();
        }
    }
}
