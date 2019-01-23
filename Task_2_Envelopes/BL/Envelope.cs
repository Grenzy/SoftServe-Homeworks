using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_2_Envelopes.BL.Interfaces;

namespace Task_2_Envelopes.BL
{
    class Envelope : INestable<Envelope>
    {
        private readonly double width;
        private readonly double height;

        public double Width => width;
        public double Height => height;

        private Envelope(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
        public static Envelope CreateEnvelope(double width, double height)
        {
            if ((width <= 0) || (height <= 0))
            {
                throw new ArgumentException("The sides of the envelope must be greater than 0");
            }
            return new Envelope(width, height);
        }
        public bool IsNested(Envelope other)
        {
            return ((width > other.Width) && (height > other.height)) ||
                ((width > other.height) && height > other.Width);
        }
    }
}
