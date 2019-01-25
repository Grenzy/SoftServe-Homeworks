using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_SortTriangles.BL
{
    internal class TriangleList
    {
        private List<Triangle> trianglesList = new List<Triangle>();
        public Triangle[] GetSortedTriangles()
        {
            return trianglesList.OrderByDescending(n => n).ToArray();
        }
        public void Add(Triangle triangle)
        {
            if (triangle != null)
            {
                trianglesList.Add(triangle);
            }
        }
    }
}
