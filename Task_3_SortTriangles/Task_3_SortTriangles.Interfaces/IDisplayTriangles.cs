using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_3_SortTriangles.DTO;

namespace Task_3_SortTriangles.Interfaces
{
    public interface IDisplayTriangles
    {
        void DisplayTriangles(TriangleDTO[] triangles);
        void DisplayError(string message);
    }
}
