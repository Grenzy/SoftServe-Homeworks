using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8_LuckyTickets.BL;

namespace Task_8_LuckyTickets.Presentation
{
    class FileParser
    {
        public static void Parse(string[] file, out List<int[]> tickets, out TicketCountingType type)
        {
            if (file.Length < 2)
            {
                throw new ArgumentException("File must contains minimum 2 row");
            }

            if (file[0].Equals("MOSKOW", StringComparison.CurrentCultureIgnoreCase))
            {
                type = TicketCountingType.Moskow;
            }
            else if (file[0].Equals("PITER", StringComparison.CurrentCultureIgnoreCase))
            {
                type = TicketCountingType.Piter;
            }
            else
            {
                throw new ArgumentException("Invalid type of comparing");
            }

            tickets = new List<int[]>();
            for (int i = 1; i < file.Length; i++)
            {
                if (file[i].Length != 6)
                {
                    continue;
                }

                if (file[i].All(n => Char.IsDigit(n)))
                {
                    tickets.Add(file[i].Select(n => (int)Char.GetNumericValue(n)).ToArray());
                }
            }
        }
    }
}
