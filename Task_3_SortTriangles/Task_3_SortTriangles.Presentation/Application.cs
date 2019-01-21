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
                string inputString = UI.InputTriangle();
                TriangleParametersDTO triangleParameters;
                try
                {
                    triangleParameters = triangleList.Parse(inputString);
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

                doesInputNext = triangleList.DoesInputNext(UI.DoesInputNext());
            } while (doesInputNext);

            TriangleDTO[] sortedTriangles = triangleList.GetSortedTrianglesList();
            UI.DisplayTriangles(sortedTriangles);
        }
    }
}
