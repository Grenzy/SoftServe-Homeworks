using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2_Envelopes.BL;
using Task_2_Envelopes.Interfaces;
using Task_2_Envelopes.Presentation.Interfaces;
using Task_2_Envelopes.Presentation.Models;

namespace Task_2_Envelopes.Presentation
{
    class Application
    {
        public void Start()
        {
            IEnvelopeChecker checker = null;
            IUserInterface UI = new ConsoleUI();
            bool doesStartover = true;
            EnvelopeModel envelope;
            do
            {
                checker = new EnvelopeComparerService();

                envelope = UI.GetEnvelopeParameters("first");
                checker.CreateFirstEnvelope(envelope.Width, envelope.Height);

                envelope = UI.GetEnvelopeParameters("second");
                checker.CreateSecondEnvelope(envelope.Width, envelope.Height);

                UI.DisplayResult(checker.IsNasted());
                doesStartover = UI.DoesStartOver();
            } while (doesStartover);
        }
    }
}
