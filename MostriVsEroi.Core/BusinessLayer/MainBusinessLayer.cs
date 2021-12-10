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

        public MainBusinessLayer(IArma mockRepoArma, IEroe mockRepoEroe, IMostro _mockRepoMostro, IGiocatore _mockRepoGiocatore)
        {
            _mockRepoArma = mockRepoArma;
            _mockRepoEroe = mockRepoEroe;
            _mockRepoGiocatore = _mockRepoGiocatore;
            _mockRepoMostro = _mockRepoMostro;
        }

        public bool AddGiocatore(Giocatore giocatore)
        {
            throw new NotImplementedException();
        }

        public Giocatore GetGiocatoreByNickName(string? nickName)
        {
            throw new NotImplementedException();
        }
    }
}
