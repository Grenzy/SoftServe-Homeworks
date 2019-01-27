using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_8_LuckyTickets.BL.Interfaces
{
    public interface ILuckyTicket
    {
        bool IsLyckyTicket(int[] ticket, TicketCountingType ticketCountingType);
    }
}
