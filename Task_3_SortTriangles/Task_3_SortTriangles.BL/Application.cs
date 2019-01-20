using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_3_SortTriangles.Interfaces;
using Task_3_SortTriangles.DTO;
using Task_3_SortTriangles.Presentation;
using Task_3_SortTriangles.BL.Extensions;

namespace Task_3_SortTriangles.BL
{
    public class Application
    {
        public void Start()
        {
            IInputTriangle controller = new ConsoleUI();
            IDisplayTriangles display = (IDisplayTriangles)controller;

            string name;
            double sideA;
            double sideB;
            double sideC;
            string doesInputNextStr;
            bool doesInputNext = false;
            Triangle triangle;
            string inputString;
            TrianglesList trianglesList = new TrianglesList();
            do
            {
                inputString = controller.GetTriangle();
                try
                {
                    InputStringAnalyzer.Parse(inputString, out name, out sideA, out sideB, out sideC);
                }
                catch (Exception ex)
                {
                    display.DisplayError(ex.Message);
                    doesInputNext = true;
                    continue;
                }
                try
                {
                    triangle = Triangle.CreateTriangle(name, sideA, sideB, sideC);
                }
                catch (Exception ex)
                {
                    display.DisplayError(ex.Message);
                    doesInputNext = true;
                    continue;
                }
                trianglesList.Add(triangle);
                doesInputNextStr = controller.DoesInputNext().Trim();
                doesInputNext = doesInputNextStr.Equals("Y", StringComparison.CurrentCultureIgnoreCase)
                    || (doesInputNextStr.Equals("YES", StringComparison.CurrentCultureIgnoreCase));

            } while (doesInputNext);

            TriangleDTO[] triangleDTOs = trianglesList
                .GetSortedTriangles()
                .Select(n => n.ToTriangleDTO())
                .ToArray();
            display.DisplayTriangles(triangleDTOs);
        }
    }
}
