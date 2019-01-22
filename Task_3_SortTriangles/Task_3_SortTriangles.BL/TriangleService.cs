using System;
using System.Linq;
using Task_3_SortTriangles.DTO;
using Task_3_SortTriangles.BL.Extensions;
using Task_3_SortTriangles.Interfaces;

namespace Task_3_SortTriangles.BL
{
    public class TriangleService : ITriangleList
    {
        TriangleList trianglesList = new TriangleList();
     
        public void Add(TriangleParametersDTO triangleParameters)
        {
            Triangle triangle = null;

            triangle = Triangle.CreateTriangle(triangleParameters.Name, triangleParameters.SideA,
                triangleParameters.SideB, triangleParameters.SideC);

            trianglesList.Add(triangle);
        }


        public TriangleDTO[] GetSortedTrianglesList()
        {
            TriangleDTO[] triangleDTOs = trianglesList
                .GetSortedTriangles()
                .Select(n => n.ToTriangleDTO())
                .ToArray();

            return triangleDTOs;
        }
    }
}
