using MostriVsEroi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Mock.Repositories
{
    public class InMemoryStorage
    {
        public static List<Eroe> eroi = new List<Eroe>();
        public static List<Mostro> mostri = new List<Mostro>();
        public static List<Giocatore> giocatori = new List<Giocatore>();
        public static List<Arma> armi = new List<Arma>();


        public static void AggiungiDati()
        {
            Eroe eroe1 = new Eroe()
            {
                Id = 1,
                Categoria = CategoriaEnum.Guerriero,
                IdArma = 1,
                IdGiocatore = 1,
                Livello = 1,
                PuntiAccumulati = 0,
                PuntiVita = 10
            };
            Eroe eroe2 = new Eroe()
            {
                Id = 2,
                Categoria = CategoriaEnum.Mago,
                IdArma = 2,
                IdGiocatore = 2,
                Livello = 1,
                PuntiAccumulati = 0,
                PuntiVita = 10
            };
            Eroe eroe3 = new Eroe()
            {
                Id = 3,
                Categoria = CategoriaEnum.Mago,
                IdArma = 3,
                IdGiocatore = 3,
                Livello = 3,
                PuntiAccumulati = 60,
                PuntiVita = 60
            };
            eroi.Add(eroe1);
            eroi.Add(eroe2);
            eroi.Add(eroe3);

            Mostro mostro1 = new Mostro()
            {
                Id = 1,
                Categoria = CategoriaEnum.Orco,
                IdArma = 15,
                Livello = 1,
                PuntiAccumulati = 0,
                PuntiVita = 10
            };
            Mostro mostro2 = new Mostro()
            {
                Id = 2,
                Categoria = CategoriaEnum.SignoreDelMale,
                IdArma = 16,
                Livello = 1,
                PuntiAccumulati = 0,
                PuntiVita = 10
            };
            mostri.Add(mostro1);
            mostri.Add(mostro2);

            Giocatore giocatore1 = new Giocatore()
            {
                Id = 1,
                NickName = "Batfania",
                Password = "1234",
                IsAdmin = false
            };
            giocatore1.eroi.Add(eroe1);

            Giocatore giocatore2 = new Giocatore()
            {
                Id = 2,
                NickName = "Ale",
                Password = "4321",
                IsAdmin = false
            };
            giocatore2.eroi.Add(eroe2);

            Giocatore giocatore3 = new Giocatore()
            {
                Id = 3,
                NickName = "Giumbi",
                Password = "0000",
                IsAdmin = true
            };
            giocatore3.eroi.Add(eroe3);

            giocatori.Add(giocatore1);
            giocatori.Add(giocatore2);
            giocatori.Add(giocatore3);

            Arma arma1 = new Arma()
            {
                Id = 1,
                Nome = "Alabarda",
                PuntiDanno = 15,
                Categoria = CategoriaEnum.Guerriero
            };
            Arma arma2 = new Arma()
            {
                Id = 2,
                Nome = "Ascia",
                PuntiDanno = 8,
                Categoria = CategoriaEnum.Guerriero
            };
            Arma arma3 = new Arma()
            {
                Id = 3,
                Nome = "Mazza",
                PuntiDanno = 5,
                Categoria = CategoriaEnum.Guerriero
            };
            Arma arma4 = new Arma()
            {
                Id = 4,
                Nome = "Spada",
                PuntiDanno = 10,
                Categoria = CategoriaEnum.Guerriero
            };
            Arma arma5 = new Arma()
            {
                Id = 5,
                Nome = "Spadone",
                PuntiDanno = 15,
                Categoria = CategoriaEnum.Guerriero
            };
            Arma arma6 = new Arma()
            {
                Id = 6,
                Nome = "Arco e frecce",
                PuntiDanno = 8,
                Categoria = CategoriaEnum.Mago
            };
            Arma arma7 = new Arma()
            {
                Id = 7,
                Nome = "Bacchetta",
                PuntiDanno = 5,
                Categoria = CategoriaEnum.Mago
            };
            Arma arma8 = new Arma()
            {
                Id = 8,
                Nome = "Bastone magico",
                PuntiDanno = 10,
                Categoria = CategoriaEnum.Mago
            };
            Arma arma9 = new Arma()
            {
                Id = 9,
                Nome = "Onda d'urto",
                PuntiDanno = 15,
                Categoria = CategoriaEnum.Mago
            };
            Arma arma10 = new Arma()
            {
                Id = 10,
                Nome = "Pugnale",
                PuntiDanno = 5,
                Categoria = CategoriaEnum.Mago
            };
            Arma arma11 = new Arma()
            {
                Id = 11,
                Nome = "Discorso noioso",
                PuntiDanno = 4,
                Categoria = CategoriaEnum.Cultista
            };
            Arma arma12 = new Arma()
            {
                Id = 12,
                Nome = "Farneticazione",
                PuntiDanno = 7,
                Categoria = CategoriaEnum.Cultista
            };
            Arma arma13 = new Arma()
            {
                Id = 13,
                Nome = "Imprecazione",
                PuntiDanno = 5,
                Categoria = CategoriaEnum.Cultista
            };
            Arma arma14 = new Arma()
            {
                Id = 14,
                Nome = "Magia nera",
                PuntiDanno = 3,
                Categoria = CategoriaEnum.Cultista
            };
            Arma arma15 = new Arma()
            {
                Id = 15,
                Nome = "Arco",
                PuntiDanno = 7,
                Categoria = CategoriaEnum.Orco
            };
            Arma arma16 = new Arma() 
            {
                Id = 16,
                Nome = "Clava",
                PuntiDanno = 5,
                Categoria = CategoriaEnum.Orco
            };
            Arma arma17 = new Arma()
            {
                Id = 17,
                Nome = "Spada rotta",
                PuntiDanno = 3,
                Categoria = CategoriaEnum.Orco
            };
            Arma arma18 = new Arma()
            {
                Id = 18,
                Nome = "Mazza chiodata",
                PuntiDanno = 10,
                Categoria = CategoriaEnum.Orco
            };
            Arma arma19 = new Arma()
            {
                Id = 19,
                Nome = "Alabarda del drago",
                PuntiDanno = 30,
                Categoria = CategoriaEnum.SignoreDelMale
            };
            Arma arma20 = new Arma()
            {
                Id = 20,
                Nome = "Divinazione",
                PuntiDanno = 15,
                Categoria = CategoriaEnum.SignoreDelMale
            };
            Arma arma21 = new Arma()
            {
                Id = 21,
                Nome = "Fulmine",
                PuntiDanno = 10,
                Categoria = CategoriaEnum.SignoreDelMale
            };
            Arma arma22 = new Arma()
            {
                Id = 22,
                Nome = "Fulmine celeste",
                PuntiDanno = 15,
                Categoria = CategoriaEnum.SignoreDelMale
            };
            Arma arma23 = new Arma()
            {
                Id = 23,
                Nome = "Tempesta",
                PuntiDanno = 8,
                Categoria = CategoriaEnum.SignoreDelMale
            };
            Arma arma24 = new Arma()
            {
                Id = 24,
                Nome = "Tempesta oscura",
                PuntiDanno = 15,
                Categoria = CategoriaEnum.SignoreDelMale
            };
            armi.Add(arma1);
            armi.Add(arma2);
            armi.Add(arma3);
            armi.Add(arma4);
            armi.Add(arma5);
            armi.Add(arma6);
            armi.Add(arma7);
            armi.Add(arma8);
            armi.Add(arma9);
            armi.Add(arma10);
            armi.Add(arma11);
            armi.Add(arma12);
            armi.Add(arma13);
            armi.Add(arma14);
            armi.Add(arma15);
            armi.Add(arma16);
            armi.Add(arma17);
            armi.Add(arma18);
            armi.Add(arma19);
            armi.Add(arma20);
            armi.Add(arma21);
            armi.Add(arma22);
            armi.Add(arma23);
            armi.Add(arma24);


        }
    }
}
