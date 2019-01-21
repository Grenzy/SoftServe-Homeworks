using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_SortTriangles.BL
{
    class Triangle : IComparable<Triangle>
    {
        private readonly string name;
        private readonly double sideA;
        private readonly double sideB;
        private readonly double sideC;
        private readonly double area;
        private readonly double perimeter;

        public string Name => name;
        public double Perimeter => perimeter;
        public double Area => area;


        private Triangle(string name, double sideA, double sideB, double sideC)
        {
            this.name = name;
            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;

            perimeter = sideA + sideB + sideC;

            double halfOfPerimeter = perimeter / 2;

            area = Math.Sqrt(halfOfPerimeter * (halfOfPerimeter - sideA)
                * (halfOfPerimeter - sideB) * (halfOfPerimeter - sideC));

        }

        public static Triangle CreateTriangle(string name, double sideA, double sideB, double sideC)
        {
            if (name == null)
            {
                throw new ArgumentNullException("Triangle name not specified");
            }
            if (name == string.Empty)
            {
                throw new FormatException("Triangle name not specified");
            }
            if ((sideA <= 0) || (sideB <= 0) || (sideC <= 0))
            {
                throw new ArgumentException("The sides of the triangle must " +
                    "be greater than zero.");
            }

            if (!((sideA < sideB + sideC) && (sideB < sideA + sideC) && (sideC < sideA + sideB)))
            {
                throw new ArgumentException("The longest side of the triangle should be " +
                    "shorter than the sum of the other sides.");
            }

            return new Triangle(name, sideA, sideB, sideC);
        }


        public int CompareTo(Triangle other)
        {
            if (other == null)
            {
                return 1;
            }

            return area.CompareTo(other.Area);
        }

        public override string ToString()
        {
            return $"Name: {name}, side A: {sideA}, side B: {sideB}, side C: {sideC}";
        }
    }
}
