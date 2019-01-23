using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_Envelopes.Interfaces
{
    public interface IEnvelopeChecker
    {
        void CreateFirstEnvelope(double width, double height);
        void CreateSecondEnvelope(double width, double height);
        int IsNasted();
    }
}
