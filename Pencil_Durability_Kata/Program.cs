using System;
using System.Collections.Generic;

namespace Pencil_Durability_Kata
{
    class Program
    {
        static void Main(string[] args)
        {
            var paper = new Paper();
            paper.Text.Add("a");
            paper.Text.Add("b");
            paper.Text.Add("c");
            paper.Text.Add("d");
            var pencilDrawer = new Stack<IWritingUtensil>();
            var pencil = new Pencil();
            var runApplication = new RunApplication(paper, pencil, pencilDrawer);

            runApplication.BuildEditArea("abc", 0);

            //runApplication.RunApp();
        }
    }
}
