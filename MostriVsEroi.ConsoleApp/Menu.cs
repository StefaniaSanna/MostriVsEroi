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
            while (String.IsNullOrEmpty(nickName) && giocatore==null);
                                 
            do
            {
                Console.WriteLine("Inserisci la password: ");
                password = Console.ReadLine();
                if (giocatore.Password != password )
                {
                    Console.WriteLine("Password non corretta, riprova: ");
                }
            }
            while (String.IsNullOrEmpty(password) && giocatore.Password == password);

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

            do
            {
                Console.WriteLine("Inserisci nickName: ");
                nickName = Console.ReadLine();
                giocatore = mainBL.GetGiocatoreByNickName(nickName);
                if (giocatore != null)
                {
                    Console.WriteLine("NickName già esistente. Inserirne uno diverso: ");
                }
            }
            while (String.IsNullOrEmpty(nickName) && giocatore != null);

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

        protected void Gioca()
        {

        }

        protected void CreaEroe()
        {

        }

        protected void EliminaEroe()
        {

        }
    }
}
