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
            for (int i = 0; i < 10; i++)
            {
                pencilDrawer.Push(new Pencil());
            }
            var pencil = new Pencil();
            var eraseHelper = new EraseHelper(paper);
            var editHelper = new EditHelper(paper, pencil);
            var writeAndSharpenHelper = new WriteAndSharpenHelper(paper, pencil);

            var runApplication = new RunApplication(paper, pencil, pencilDrawer, eraseHelper, editHelper, writeAndSharpenHelper);

            runApplication.RunApp();
        }
    }
}
