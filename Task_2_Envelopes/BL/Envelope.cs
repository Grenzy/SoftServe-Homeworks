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
        private readonly double sideA;
        private readonly double sideB;

        public double SideA => sideA;
        public double SideB => sideB;

        public bool IsNested(Envelope other)
        {
            return ((sideA > other.SideA) && (sideB > other.sideB)) ||
                ((sideA > other.sideB) && sideB > other.SideA);
        }
    }
}
