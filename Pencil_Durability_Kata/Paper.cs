using System;
using System.Collections.Generic;
using System.Text;

namespace Pencil_Durability_Kata
{
    public class Paper : IStationary
    {
        public List<string> Text { get; set; }

        public Paper()
        {
            Text = new List<string>();
        }
    }
}
