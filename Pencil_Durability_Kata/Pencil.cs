﻿using System;
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

        // reduce durability methods
        public int FindCharReductionRate(char charToReduceBy)
        {
            int reduceDurabilityBy = 0;
            if (char.IsUpper(charToReduceBy))
            {
                reduceDurabilityBy += 2;
            }
            else
            {
                reduceDurabilityBy += 1;
            }
            return reduceDurabilityBy;
        }

        public void ReducePointDurability(int reduceBy)
        {
            PointDurability -= reduceBy;
        }
    }
}
