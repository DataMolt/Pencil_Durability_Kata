using System;
using System.Collections.Generic;
using System.Text;

namespace Pencil_Durability_Kata
{
    public class RunApplication
    {
        public Pencil Pencil { get; set; }
        public Paper Paper { get; set; }
        public RunApplication()
        {
            Pencil = new Pencil();
            Paper = new Paper();
        }

        public void RunApp()
        {

        }

        public void WriteTextToPaper(List<string> wordList)
        {
            throw new NotImplementedException();
        }
    }
}
