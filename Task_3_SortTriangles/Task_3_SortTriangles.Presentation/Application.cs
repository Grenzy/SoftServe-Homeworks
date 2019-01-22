using System;
using Task_3_SortTriangles.Interfaces;
using Task_3_SortTriangles.DTO;
using Task_3_SortTriangles.BL;

namespace Task_3_SortTriangles.Presentation
{
    class Application
    {

        public void Start()
        {
            ITriangleList triangleList = new TriangleService();
            IUserInterface UI = new ConsoleUI();
            bool doesInputNext = false;

            do
            {
            
                TriangleParametersDTO triangleParameters;
                try
                {
                    triangleParameters = UI.InputTriangle();
                }
                catch (Exception ex)
                {
                    UI.DisplayError(ex.Message);
                    doesInputNext = true;
                    continue;
                }
                try
                {
                    triangleList.Add(triangleParameters);
                }
                catch (Exception ex)
                {
                    UI.DisplayError(ex.Message);
                    doesInputNext = true;
                    continue;
                }

                doesInputNext = UI.DoesInputNext();
            } while (doesInputNext);

            TriangleDTO[] sortedTriangles = triangleList.GetSortedTrianglesList();
            UI.DisplayTriangles(sortedTriangles);
        }

     
    }
}
