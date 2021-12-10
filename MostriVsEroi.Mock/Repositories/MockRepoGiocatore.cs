using MostriVsEroi.Core.Entities;
using MostriVsEroi.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Mock.Repositories
{
    public class MockRepoGiocatore : IGiocatore
    {
        public bool Add(Giocatore item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Giocatore item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Giocatore> FetchAllFilter(Func<Giocatore, bool> filter = null)
        {
            throw new NotImplementedException();
        }

        public Giocatore GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Giocatore item)
        {
            throw new NotImplementedException();
        }
    }
}
