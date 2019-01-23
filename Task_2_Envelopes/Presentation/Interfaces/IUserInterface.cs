using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2_Envelopes.Presentation.Models;

namespace Task_2_Envelopes.Presentation.Interfaces
{
    internal interface IUserInterface
    {
        void DisplayError(string message);
        EnvelopeModel GetEnvelopeParameters(string name);
        void DisplayResult(int result);
        bool DoesStartOver();

    }
}
