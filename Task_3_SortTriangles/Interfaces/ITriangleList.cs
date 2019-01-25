using Task_3_SortTriangles.DTO;

namespace Task_3_SortTriangles.Interfaces
{
    public interface ITriangleList
    {
        void Add(TriangleParametersDTO triangleParameters);
        TriangleDTO[] GetSortedTrianglesList();
    }
}
