using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2_Envelopes.BL.Exceptions;

namespace Task_2_Envelopes.BL
{
    public class EnvelopeComparerService
    {
        private Envelope envelopeA;
        private Envelope envelopeB;
        
        public void CreateOuterEnvelope(double width, double height)
        {
            envelopeA = Envelope.CreateEnvelope(width, height);
        }
        public void CreateInnerEnvelope(double width, double height)
        {
            envelopeB = Envelope.CreateEnvelope(width, height);
        }
        public bool IsNasted()
        {
            if ((envelopeA == null) || envelopeB == null)
            {
                throw new EnvelopeIsNullException("Triangle is null");
            }

            return envelopeA.IsNested(envelopeB);
        }
    }
}
