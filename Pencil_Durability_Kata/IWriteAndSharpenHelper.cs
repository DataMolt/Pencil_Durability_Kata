using System;
using System.Collections.Generic;
using System.Text;

namespace Pencil_Durability_Kata
{
    public interface IWriteAndSharpenHelper
    {
        void WriteTextToPaper(List<string> wordList);

        void WritePaperContentsToConsole();

        void AlertUserPencilNeedsSharpening();

        void AlertUserPencilLengthReduced();

        void AlertUserPencilCannotBeSharpened();
    }
}
