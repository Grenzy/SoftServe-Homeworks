using Task_3_SortTriangles.DTO;

namespace Task_3_SortTriangles.Interfaces
{
    public interface IUserInterface
    {
        void DisplayTriangles(TriangleDTO[] triangles);
        void DisplayError(string message);
        TriangleParametersDTO InputTriangle();
        bool DoesInputNext();
    }
}
