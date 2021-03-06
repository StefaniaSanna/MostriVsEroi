using MostriVsEroi.Core.BusinessLayer;
using MostriVsEroi.Core.Entities;
using MostriVsEroi.Mock.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.ConsoleApp
{
    public class Menu
    {
        protected static readonly MainBusinessLayer mainBL = new MainBusinessLayer(new MockRepoArma(), new MockRepoEroe(), new MockRepoMostro(), new MockRepoGiocatore());


        public static void Start()
        {
            Console.WriteLine("Benvenuto!");
            char choice;

            do
            {
                Console.WriteLine("Scegli 1 per effettuare il login." +
                    "\nScegli 2 per registrarti al sistema." +
                    "\nScegli Q per uscire.");

                choice = Console.ReadKey().KeyChar;

                Console.WriteLine();

                switch (choice)
                {
                    case '1':
                        Login();
                        break;
                    case '2':
                        Registration();
                        break;
                    case 'Q':
                        Console.WriteLine("Arrivederci");
                        break;
                    default:
                        Console.WriteLine("Scelta non valida");
                        break;
                }

            } while (choice != 'Q');

        }

        private static void Login()
        {
            string nickName;
            string password;
            Giocatore giocatore = new Giocatore();

            Console.WriteLine("Effettuare il login.");
            do
            {
                Console.WriteLine("Inserisci nickName: ");
                nickName = Console.ReadLine();
                giocatore = mainBL.GetGiocatoreByNickName(nickName);
                if (giocatore == null)
                {
                    Console.WriteLine("NickName non trovato, inserisci il nickName corretto: ");
                }
            }
            while (String.IsNullOrEmpty(nickName) || giocatore == null);

            do
            {
                Console.WriteLine("Inserisci la password: ");
                password = Console.ReadLine();
                if (giocatore.Password != password)
                {
                    Console.WriteLine("Password non corretta, riprova: ");
                }
            }
            while (String.IsNullOrEmpty(password) || giocatore.Password != password);

            if (giocatore.IsAdmin != true)
            {
                MenuNonAdmin menuNonAdmin = new MenuNonAdmin(giocatore); //qui ci va private static readonly
                menuNonAdmin.Naviga();
            }
            else
            {
                MenuAdmin menuAdmin = new MenuAdmin(giocatore);
                menuAdmin.Naviga();
            }
        }
        private static void Registration()
        {
            string nickName;
            string password;
            Giocatore giocatore = new Giocatore();
            Giocatore giocatoreTest = new Giocatore();

            do
            {
                Console.WriteLine("Inserisci nickName: ");
                nickName = Console.ReadLine();
                giocatoreTest = mainBL.GetGiocatoreByNickName(nickName);
                if (giocatoreTest != null)
                {
                    Console.WriteLine("NickName già esistente. Inserirne uno diverso: ");
                }
            }
            while (String.IsNullOrEmpty(nickName) || giocatoreTest != null);

            do
            {
                Console.WriteLine("Inserisci la password: ");
                password = Console.ReadLine();
            }
            while (String.IsNullOrEmpty(password));
            giocatore.Password = password;
            giocatore.NickName = nickName;
            giocatore.IsAdmin = false;

            Console.WriteLine("Registrazione avvenuta con successo");
            bool isAdded = mainBL.AddGiocatore(giocatore);

            MenuNonAdmin menuNonAdmin = new MenuNonAdmin(giocatore);
            menuNonAdmin.Naviga();


        }
        protected void Gioca(Giocatore giocatore)
        {
            bool continuaGioco = false;
            if (giocatore.eroi.Count == 0)
            {
                Console.WriteLine("\n La tua lista eroi è vuota! Inserisci eroi per procedere");
                CreaEroe(giocatore);
            }

            do
            {
                Console.WriteLine("Scegli tra i tuoi eroi");
                Eroe eroeScelto = ScegliEroe(giocatore.eroi);
                Mostro mostroScelto = mainBL.ScegliMostroRandom(eroeScelto);

                bool escape = false;

                do
                {
                    int scelta;
                    do
                    {
                        Console.WriteLine("\n[1] per attaccare \n[2] per fuggire");
                    }
                    while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= 1 && scelta <= 2));
                    switch (scelta)
                    {
                        case 1:
                            Console.WriteLine("E' il tuo turno, attacca!");
                            int puntiDannoGiocatore = AttaccoGiocatore(eroeScelto);
                            mostroScelto.PuntiVita -= puntiDannoGiocatore;
                            int PuntiDannoMostro = AttaccoMostro(mostroScelto);
                            eroeScelto.PuntiVita -= PuntiDannoMostro;
                            Console.WriteLine("Il mostro ha attaccato!");
                            break;
                        case 2:
                            escape = Fuggi();
                            if (escape == false)
                            {
                                Console.WriteLine("Non puoi fuggire!");
                                int PuntiDannoMostro1 = AttaccoMostro(mostroScelto);
                                eroeScelto.PuntiVita -= PuntiDannoMostro1;
                                Console.WriteLine("Il mostro ha attaccato!");
                            }
                            break;
                    }
                }
                while (!(escape == true || mostroScelto.PuntiVita <= 0 || eroeScelto.PuntiVita <= 0));
                if (escape == true)
                {
                    Console.WriteLine("Hai deciso di fuggire");
                }
                else if (mostroScelto.PuntiVita <= 0)
                {
                    Console.WriteLine("Hai sconfitto il mostro");
                }
                else if (eroeScelto.PuntiVita <= 0)
                {
                    Console.WriteLine("Hai perso contro il mostro");
                }
                int scelta1;
                do
                {
                    Console.WriteLine("Vuoi continuare a giocare? \n[1] Si \n[2] No");
                }
                while (!(int.TryParse(Console.ReadLine(), out scelta1) && scelta1 >= 1 && scelta1 <= 2));
                if (scelta1 == 1)
                {
                    continuaGioco = true;
                }
                else
                {
                    continuaGioco = false;
                }
            }
            while (continuaGioco==true);                               
        }
        private bool Fuggi()
        {
            bool escape;
            Random random = new Random();
            int r = random.Next(1, 3);
            if (r == 1)
                escape = true;
            else
                escape = false;
            return escape;

        }
        private int AttaccoMostro(Mostro mostroScelto)
        {
            Arma arma = mainBL.GetArma(mostroScelto.IdArma);
            return arma.PuntiDanno;
        }
        public int AttaccoGiocatore(Eroe eroe)
        {
            Arma arma = mainBL.GetArma(eroe.IdArma);
            return arma.PuntiDanno;           
        }
        public Arma ScegliArma(List<Arma> listaArmi) 
        {
            int scelta;
            int max = listaArmi.Max(b => b.Id);
            int min = listaArmi.Min(b => b.Id);

            foreach (var item in listaArmi)
            {
                Console.WriteLine($"{item.Id} - {item.Nome} - Punti danni: {item.PuntiDanno}");
            }
            do
            {
                Console.WriteLine("Seleziona l'Id dell'arma che vuoi");
            }
            while (!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= min && scelta <= max));
            return listaArmi.SingleOrDefault(e => e.Id == scelta);
        }
        protected void CreaEroe(Giocatore giocatore)
        {
            Console.WriteLine("Crea un nuovo eroe");
            int choice;
            do
            {
                Console.WriteLine("\n[1] Guerriero \n[2] Mago");
            }
            while (!(int.TryParse(Console.ReadLine(), out choice) && choice >= 1 && choice <= 2));

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Hai scelto di creare Eroe Guerriero");
                    Eroe guerriero = new Eroe();
                    guerriero.Categoria = CategoriaEnum.Guerriero;
                    guerriero.PuntiAccumulati = 0;
                    guerriero.IdGiocatore = giocatore.Id;
                    guerriero.CalcolaLivello();
                    Console.WriteLine("Seleziona un'arma");
                    List<Arma> listaArmi = (List<Arma>)mainBL.FetchArmiByCategory(guerriero.Categoria);
                    Arma armaScelta = ScegliArma(listaArmi);
                    guerriero.IdArma = armaScelta.Id;
                    Eroe nuovoEroeGuerriero = mainBL.AggiungiEroe(guerriero);
                    giocatore.eroi.Add(guerriero);
                    Console.WriteLine("Eroe aggiunto correttamente alla lista del giocatore");
                    break;
                case 2:
                    Console.WriteLine("\nHai scelto di creare un Eroe Mago");
                    Eroe eroeMago = new Eroe();
                    eroeMago.PuntiAccumulati = 0;
                    eroeMago.Categoria = CategoriaEnum.Mago;
                    eroeMago.CalcolaLivello();
                    List<Arma> listaArmiMago = (List<Arma>)mainBL.FetchArmiByCategory(eroeMago.Categoria);
                    if (listaArmiMago.Count == 0)
                    {
                        Console.WriteLine("\nLista Armi vuota...");
                    }
                    Arma armaScelta1 = ScegliArma(listaArmiMago);
                    eroeMago.IdArma = armaScelta1.Id;
                    Eroe eroeMagoNew = mainBL.AggiungiEroe(eroeMago);
                    giocatore.eroi.Add(eroeMagoNew);
                    break;
            }
        }
        protected void EliminaEroe(Giocatore giocatore)
        {
            Console.WriteLine("\nEcco la lista dei tuoi eroi:");
            foreach (var item in giocatore.eroi)
            {
                Console.WriteLine($"\nId:{item.Id}, Categoria:{item.Categoria}, Punti Vita:{item.PuntiVita}, Punti Accumulati: {item.PuntiAccumulati}, Livello:{item.Livello}");
            }
            int idEroe;
            do
            {
                Console.WriteLine("\nInserire l'id dell'eroe da eliminare");
            } while (!(int.TryParse(Console.ReadLine(), out idEroe)));

            Eroe eroe = mainBL.GetEroeById(idEroe);
            if (eroe == null)
            {
                Console.WriteLine("\nNon è stato trovato un eroe corrispondente all'ID inserito");
            }
            else
            {
                giocatore.eroi.Remove(eroe);
                bool removeEroe = mainBL.Delete(eroe);
                if (removeEroe == true)
                {
                    Console.WriteLine("\nEroe eliminato correttamente");
                }
            }
        }
        private Eroe ScegliEroe(List<Eroe> eroi)
        {
            int max = eroi.Max(b => b.Id);
            int min = eroi.Min(b => b.Id);
            int choice;
            foreach (var eroe in eroi)
            {
                Console.WriteLine($"\nId: {eroe.Id}, Livello:{eroe.Livello}, Punti Accumulati:{eroe.PuntiAccumulati}," +
                $"Punti Vita:{eroe.PuntiVita}");
            }
            do
            {
                Console.WriteLine("\nScegli il tuo eroe, inserisci l'Id: ");
            } while (!(int.TryParse(Console.ReadLine(), out choice) && choice >= min && choice <= max)); return eroi.SingleOrDefault(a => a.Id == choice);
        }
    }
}
