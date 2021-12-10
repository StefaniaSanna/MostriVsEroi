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
                if(giocatore == null)
                {
                    Console.WriteLine("NickName non trovato, inserisci il nickName corretto: ");
                }
            }
            while (String.IsNullOrEmpty(nickName) || giocatore==null);
                                 
            do
            {
                Console.WriteLine("Inserisci la password: ");
                password = Console.ReadLine();
                if (giocatore.Password != password )
                {
                    Console.WriteLine("Password non corretta, riprova: ");
                }
            }
            while (String.IsNullOrEmpty(password) || giocatore.Password != password);

            if(giocatore.IsAdmin != true)
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
            if (giocatore.eroi.Count == 0)
            {
                Console.WriteLine("\n La tua lista eroi è vuota! Inserisci eroi per procedere");
                Eroe eroe = new Eroe();
                Console.WriteLine("Crea un nuovo eroe");
                int choice;
                do
                {
                    Console.WriteLine("\n[1] Guerriero \n[2] Mago");
                }
                while (!(int.TryParse(Console.ReadLine(), out choice) && choice >=1 && choice <=2));

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
                        Arma armaSScelta = ScegliArma(listaArmi);
                        guerriero.IdArma = armaSScelta.Id;
                        Eroe nuovoEroeGuerriero = mainBL.AggiungiEroe(guerriero);
                        giocatore.eroi.Add(guerriero);
                        Console.WriteLine("Eroe aggiunto correttamente alla lista del giocatore");
                      break;
                    case 2:
                        Console.WriteLine("Hai scelto di creare Eroe Mago");
                        break;
                }
            }             
        }

        private Arma ScegliArma(List<Arma> listaArmi)
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
            while(!(int.TryParse(Console.ReadLine(), out scelta) && scelta >= min && scelta <= max));

            return listaArmi.SingleOrDefault(e => e.Id == scelta);
             
        }

        protected void CreaEroe()
        {

        }

        protected void EliminaEroe()
        {

        }
    }
}
