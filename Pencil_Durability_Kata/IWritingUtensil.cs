using System;
using System.Collections.Generic;
using System.Text;

namespace Pencil_Durability_Kata
{
    public interface IWritingUtensil
    {
        int PointDurability { get; set; }
        int EraserDurability { get; set; }
        int PencilSize { get; set; }

        int GeneratePencilLength();

        string GetUserInput();

        string[] BuildWordArray(string userInput);

        int FindCharReductionRate(char charToReduceBy);

        bool ReducePointDurability(int reduceBy);

        string BuildWordForWritingToPaper(string word);

        void ReducePencilLength();

        void ResetPencilDurability();
    }
}
