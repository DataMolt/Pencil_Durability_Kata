using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pencil_Durability_Kata
{
    public class Pencil
    {
        public int PointDurability { get; set; }
        public int EraserDurability { get; set; }

        public Pencil()
        {
            PointDurability = 40000;
            EraserDurability = 20000;
        }
    }
}
