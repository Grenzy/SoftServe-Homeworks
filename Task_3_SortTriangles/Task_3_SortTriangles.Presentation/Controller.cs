using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_3_SortTriangles.DTO;
using Task_3_SortTriangles.Interfaces;

namespace Task_3_SortTriangles.Presentation
{
    public class Controller : IInputTriangle, IDisplayTriangles
    {
        public void DisplayError(string message)
        {
            throw new NotImplementedException();
        }

        public void DisplayTriangles(TriangleDTO[] triangles)
        {
            throw new NotImplementedException();
        }

        public string DoesInputNext()
        {
            throw new NotImplementedException();
        }

        public string GetTriangle()
        {
            throw new NotImplementedException();
        }
    }
}
