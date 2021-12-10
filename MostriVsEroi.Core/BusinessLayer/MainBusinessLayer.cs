using MostriVsEroi.Core.Entities;
using MostriVsEroi.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Core.BusinessLayer
{
    public class MainBusinessLayer : IBusinessLayer
    {
        private readonly IArma _mockRepoArma;
        private readonly IEroe _mockRepoEroe;
        private readonly IGiocatore _mockRepoGiocatore;
        private readonly IMostro _mockRepoMostro;

        public MainBusinessLayer(IArma mockRepoArma, IEroe mockRepoEroe, IMostro mockRepoMostro, IGiocatore mockRepoGiocatore)
        {
            _mockRepoArma = mockRepoArma;
            _mockRepoEroe = mockRepoEroe;
            _mockRepoGiocatore = mockRepoGiocatore;
            _mockRepoMostro = mockRepoMostro;
        }

        public bool AddGiocatore(Giocatore giocatore)
        {
            bool isAdded = _mockRepoGiocatore.Add(giocatore);
            return isAdded;
        }

        public Giocatore GetGiocatoreByNickName(string? nickName)
        {
            return _mockRepoGiocatore.GetByNickName(nickName);
                        
        }

        public IEnumerable<Arma> FetchArmiByCategory(CategoriaEnum categoria)
        {
            return _mockRepoArma.FetchAllFilter(a => a.Categoria == categoria).ToList();
        }



        public Eroe AggiungiEroe(Eroe guerriero)
        {
            return _mockRepoEroe.AddEroe(guerriero);
        }

        public Mostro ScegliMostroRandom(Eroe eroe)
        {
            var mostriFiltered = _mockRepoMostro.FetchAllFilter(x => x.Livello <= eroe.Livello);
            int max = mostriFiltered.Max(b => b.Id);
            int min = mostriFiltered.Min(b => b.Id);
            Random random = new Random();
            int mostroId = random.Next(min, max + 1);
            return mostriFiltered.SingleOrDefault(a => a.Id == mostroId);
        }

        public void GetClassifica()
        {
            var giocatori = _mockRepoGiocatore.FetchAllFilter(null);
            var eroi = _mockRepoEroe.FetchAllFilter(null);

            var classifica = eroi.Join(
            giocatori,
            e => e.IdGiocatore,
            g => g.Id,
            (e, g) => new
            {
                PuntiAccumulati = e.PuntiAccumulati,
                Name = g.NickName
            });
            var classificaOrdinata = classifica.OrderByDescending(x => x.PuntiAccumulati);
            Console.WriteLine("Ecco la classifica globale!");
            foreach (var item in classificaOrdinata)
            {
                Console.WriteLine($"\nPunti accumulati: {item.PuntiAccumulati}, Nickname del giocatore: {item.Name}");
            }
        }

        public Arma GetArma(int idArma)
        {
            return _mockRepoArma.GetById(idArma);
        }

        public Mostro AggiungiMostro(Mostro mostro)
        {
            return _mockRepoMostro.AddMostro(mostro);
        }

        public Eroe GetEroeById(int idEroe)
        {
            return _mockRepoEroe.GetById(idEroe);
        }

        public bool Delete(Eroe eroe)
        {
            bool isDelete = _mockRepoEroe.Delete(eroe);
            return isDelete;
        }
    }
}
