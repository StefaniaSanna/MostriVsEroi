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
            item.Id = InMemoryStorage.giocatori.Max(x => x.Id) + 1;
            InMemoryStorage.giocatori.Add(item);
            return true;
        }

        public bool Delete(Giocatore item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Giocatore> FetchAllFilter(Func<Giocatore, bool> filter = null)
        {
            if (filter != null)
                return InMemoryStorage.giocatori.Where(filter).ToList();
            else
                return InMemoryStorage.giocatori.ToList();
        }

        public Giocatore GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Giocatore? GetByNickName(string? nickName)
        {
            return InMemoryStorage.giocatori.SingleOrDefault(e => e.NickName == nickName);
        }

        public bool Update(Giocatore item)
        {
            throw new NotImplementedException();
        }
    }
}
