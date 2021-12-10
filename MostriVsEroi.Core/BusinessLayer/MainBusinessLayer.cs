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
    }
}
