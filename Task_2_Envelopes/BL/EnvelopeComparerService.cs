using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2_Envelopes.BL.Exceptions;
using Task_2_Envelopes.Interfaces;

namespace Task_2_Envelopes.BL
{
    public class EnvelopeComparerService: IEnvelopeChecker
    {
        private Envelope envelopeA;
        private Envelope envelopeB;
        
        public void CreateFirstEnvelope(double width, double height)
        {
            envelopeA = Envelope.CreateEnvelope(width, height);
        }
        public void CreateSecondEnvelope(double width, double height)
        {
            envelopeB = Envelope.CreateEnvelope(width, height);
        }
        public int IsNasted()
        {
            if ((envelopeA == null) || envelopeB == null)
            {
                throw new EnvelopeIsNullException("Envelope is null");
            }

            return envelopeA.IsNested(envelopeB);
        }
    }
}
