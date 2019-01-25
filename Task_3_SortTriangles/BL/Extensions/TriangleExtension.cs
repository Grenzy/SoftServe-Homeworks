using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_3_SortTriangles.DTO;

namespace Task_3_SortTriangles.BL.Extensions
{
   
    internal static class TriangleExtension
    {
        /// <summary>
        /// We take out in a separate extension method to reduce the level of connectivity.
        /// </summary>
        public static TriangleDTO ToTriangleDTO(this Triangle triangle)
        {
            return new TriangleDTO { Name = triangle.Name, Area = triangle.Area };
        }
    }
}
