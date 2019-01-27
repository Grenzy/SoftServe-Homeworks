using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8_LuckyTickets.BL
{
    class Ticket
    {
        public static bool IsMoskowLuckyTicket(int[] ticket)
        {
            return ticket.Take(ticket.Length / 2).Sum() == 
                ticket.Skip(ticket.Length / 2).Sum();
        }
        public static bool IsPiterLuckyTicket(int[] ticket)
        {
            return ticket.Where((n, i) => i % 2 == 0).Sum() ==
                ticket.Where((n, i) => i % 2 == 1).Sum();
        }
    }
}
