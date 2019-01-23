using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2_Envelopes.Presentation.Models
{
    internal class EnvelopeModel
    {
        public EnvelopeModel(double width, double height)
        {
            Width = width;
            Height = height;
        }
        public double Width { get; set; }
        public  double Height { get; set; }
    }
}
