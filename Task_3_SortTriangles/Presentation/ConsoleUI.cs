using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_3_SortTriangles.DTO;
using Task_3_SortTriangles.Interfaces;

namespace Task_3_SortTriangles.Presentation
{
    internal class ConsoleUI : IUserInterface
    {
        public void DisplayError(string message)
        {
            Console.WriteLine("Error: " + message);
        }

        public void DisplayTriangles(TriangleDTO[] triangles)
        {
            Console.WriteLine("============= Triangles list: ===============");
            for (int i = 0; i < triangles.Length; i++)
            {
                Console.WriteLine($"{i + 1}. [Triangle {triangles[i].Name}]: {triangles[i].Area:0.00} cm");
            }
        }

        public bool DoesInputNext()
        {
            Console.WriteLine("Add another triangle? y/yes");
            string answer = Console.ReadLine();

            return InputStringAnalyzer.AnalyzeAnswer(answer);
        }

        public TriangleParametersDTO InputTriangle()
        {
            Console.WriteLine("Enter triangle: <name> <side A> <side B> <side C>");
            string inputString = Console.ReadLine();

            string name;
            double sideA;
            double sideB;
            double sideC;
            InputStringAnalyzer.ParseTriangleParameters(inputString, out name, out sideA, out sideB, out sideC);

            return new TriangleParametersDTO(name, sideA, sideB, sideC);

        }
    }
}
