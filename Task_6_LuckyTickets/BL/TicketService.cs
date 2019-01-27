using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8_LuckyTickets.BL.Interfaces;

namespace Task_8_LuckyTickets.BL
{
    public class TicketService : ILuckyTicket
    {
        public bool IsLyckyTicket(int[] ticket, TicketCountingType ticketCountingType)
        {
            if (ticketCountingType == TicketCountingType.Moskow)
            {
                return Ticket.IsMoskowLuckyTicket(ticket);
            }

            return Ticket.IsPiterLuckyTicket(ticket);
        }
    }
}
