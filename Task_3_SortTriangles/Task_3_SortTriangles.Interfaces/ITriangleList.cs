using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_3_SortTriangles.DTO;

namespace Task_3_SortTriangles.Interfaces
{
    public interface ITriangleList
    {
        TriangleParametersDTO Parse(string parameters);
        void Add(TriangleParametersDTO triangleParameters);
        bool DoesInputNext(string answer);
        TriangleDTO[] GetSortedTrianglesList();
    }
}
