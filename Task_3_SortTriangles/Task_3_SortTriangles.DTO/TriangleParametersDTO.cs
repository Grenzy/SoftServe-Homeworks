namespace Task_3_SortTriangles.DTO
{
    public class TriangleParametersDTO
    {
        public TriangleParametersDTO(string name, double sideA, double sideB, double sideC)
        {
            Name = name;
            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }
        public string Name { get; set; }
        public double SideA { get; set; }
        public double SideB { get; set; }
        public double SideC { get; set; }
    }
}
