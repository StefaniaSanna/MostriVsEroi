using MostriVsEroi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.ConsoleApp
{
    public class MenuAdmin:Menu
    {
        public Giocatore giocatore;

        public MenuAdmin(Giocatore giocatore)
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
                    "\n[4] per creare un nuovo mostro" +
                    "\n[5] per visualizzare la classifica globale" +
                    "\n[Q] per uscire");
                choice = Console.ReadKey().KeyChar;

                switch (choice)
                {
                    case '1':
                        Gioca();
                        break;
                    case '2':
                        CreaEroe();
                        break;
                    case '3':
                        EliminaEroe();
                        break;
                    case '4':
                        CreaMostro();
                        break;
                    case '5':
                        CreaClassifica();
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

        private void CreaClassifica()
        {
            throw new NotImplementedException();
        }

        private void CreaMostro()
        {
            throw new NotImplementedException();
        }
    }
}
