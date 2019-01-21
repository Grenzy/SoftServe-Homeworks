using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_3_SortTriangles.DTO;
using Task_3_SortTriangles.Interfaces;

namespace Task_3_SortTriangles.Presentation
{
    public class ConsoleUI : IUserInterface
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
                Console.WriteLine($"{i + 1} [Triangle {triangles[i].Name}]: {triangles[i].Area:0.00} cm");
            }
        }

        public string DoesInputNext()
        {
            Console.WriteLine("Add another triangle? y/yes");
            string answer = Console.ReadLine();
            return answer;
        }

        public string InputTriangle()
        {
            Console.WriteLine("Enter triangle: <name> <side A> <side B> <side C>");
            string triangle = Console.ReadLine();
            return triangle;
        }
    }
}
