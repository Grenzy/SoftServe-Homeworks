using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_7_NumberSequence.Interfaces
{
    public interface ISequence<T>
    {
        T[] GetSequence(T upperBound);
    }
}
