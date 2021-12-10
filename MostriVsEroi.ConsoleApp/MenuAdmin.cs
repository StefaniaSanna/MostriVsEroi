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
                        Gioca(giocatore);
                        break;
                    case '2':
                        CreaEroe(giocatore);
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
            Console.WriteLine("Crea un nuovo mostro");
            int choice;
            do
            {
                Console.WriteLine("\n[1] Cultista \n[2] Orco \n[3] Signore del male");
            }
            while (!(int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 3));

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Hai scelto di creare Cultista");
                    Mostro cultista = new Mostro();
                    cultista.Categoria = CategoriaEnum.Cultista;
                    cultista.PuntiAccumulati = 0;
                    cultista.CalcolaLivello();
                    Console.WriteLine("Seleziona un'arma");
                    List<Arma> listaArmi = (List<Arma>)mainBL.FetchArmiByCategory(cultista.Categoria);
                    Arma armaScelta =ScegliArma(listaArmi);
                    cultista.IdArma = armaScelta.Id;
                    Mostro nuovoMostroCultista = mainBL.AggiungiMostro(cultista);
                    Console.WriteLine("Cultista aggiunto correttamente");
                   
                    break;
                case 2:
                    Console.WriteLine("Hai scelto di creare Orco");
                    Mostro orco = new Mostro();
                    orco.Categoria = CategoriaEnum.Orco;
                    orco.PuntiAccumulati = 0;
                    orco.CalcolaLivello();
                    Console.WriteLine("Seleziona un'arma");
                    List<Arma> listaArmi1 = (List<Arma>)mainBL.FetchArmiByCategory(orco.Categoria);
                    Arma armaScelta1 = ScegliArma(listaArmi1);
                    orco.IdArma = armaScelta1.Id;
                    Mostro nuovoMostroOrco = mainBL.AggiungiMostro(orco);
                    Console.WriteLine("Orco aggiunto correttamente");
                    break;
                case 3:
                    Console.WriteLine("Hai scelto di creare Signore del Male");
                    Mostro signoreDelMale = new Mostro();
                    signoreDelMale.Categoria = CategoriaEnum.SignoreDelMale;
                    signoreDelMale.PuntiAccumulati = 0;
                    signoreDelMale.CalcolaLivello();
                    Console.WriteLine("Seleziona un'arma");
                    List<Arma> listaArmi2 = (List<Arma>)mainBL.FetchArmiByCategory(signoreDelMale.Categoria);
                    Arma armaScelta2 = ScegliArma(listaArmi2);
                    signoreDelMale.IdArma = armaScelta2.Id;
                    Mostro nuovoMostroSignoreDelMale = mainBL.AggiungiMostro(signoreDelMale);
                    Console.WriteLine("Signore del male aggiunto correttamente");
                    break;
            }
        }
    }
}
