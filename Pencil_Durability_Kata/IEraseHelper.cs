using System;
using System.Collections.Generic;
using System.Text;

namespace Pencil_Durability_Kata
{
    public interface IEraseHelper
    {
        IStationary _stationary { get; set; }

        string GetUserEraseRequest();

        bool UserRequestInPaperText(string userInput);

        void AlertUserRequestNotFoundInText();

        int FindEraseRequestIndexInPaperText(string userInput);
    }
}
