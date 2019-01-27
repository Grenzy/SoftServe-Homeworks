using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task_8_LuckyTickets.BL;
using Task_8_LuckyTickets.Presentation.Inrerfaces;
using Task_8_LuckyTickets.BL.Interfaces;

namespace Task_8_LuckyTickets.Presentation
{
    class Application
    {
        public void Start()
        {
            IUserInterface UI = new ConsoleUI();
            ILuckyTicket ticketService = new TicketService();

            UI.ShowHelp();
            string path = UI.GetPath();

            while (!File.Exists(path))
            {
                UI.ShowError("File is not exist");
                path = UI.GetPath();
            }

            string[] file = File.ReadAllLines(path);
            List<int[]> tickets;
            TicketCountingType type;
            try
            {
                FileParser.Parse(file, out tickets, out type);
            }
            catch (Exception ex)
            {
                UI.ShowError(ex.Message);
                return;
            }
            
            var luckyTickets = tickets.Where(n => ticketService.IsLyckyTicket(n, type));
            UI.ShowTickets(luckyTickets);
            UI.ShowTotal(luckyTickets.Count());
        }
    }
}
