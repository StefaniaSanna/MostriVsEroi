using MostriVsEroi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.ConsoleApp
{
    public class MenuNonAdmin : Menu
    {
        public Giocatore giocatore;

        public MenuNonAdmin(Giocatore giocatore)
        {
            this.giocatore = giocatore;
        }

        internal void Naviga()
        {
            Console.WriteLine($"Benvenuto {giocatore.NickName}");
            char choice;
            do
            {
                Console.WriteLine("Scegli [1] per giocare" +
                    "\n[2] per creare un nuovo eroe" +
                    "\n[3] per eliminare un eroe" +
                    "\n[Q] per uscire");
                choice = Console.ReadKey().KeyChar;

                
                switch (choice)
                {
                    case '1':
                        Gioca(giocatore);
                        break;
                    case '2':
                        CreaEroe(giocatore);
                        break;
                    case '3':
                        EliminaEroe(giocatore);
                        break;
                    case 'Q':
                        Console.WriteLine("Arrivederci");
                        break;
                    default:
                        Console.WriteLine("Scelta non valida");
                        break;

                }
            }
            while (choice != 'Q');
        }
    }
}
