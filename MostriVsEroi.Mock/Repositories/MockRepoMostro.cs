using MostriVsEroi.Core.Entities;
using MostriVsEroi.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Mock.Repositories
{
    public class MockRepoMostro : IMostro
    {
        public bool Add(Mostro item)
        {
            throw new NotImplementedException();
        }

        public Mostro AddMostro(Mostro mostro)
        {
            mostro.Id = InMemoryStorage.mostri.Max(x => x.Id) + 1;
            InMemoryStorage.mostri.Add(mostro);
            return mostro;
        }

        public bool Delete(Mostro item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Mostro> FetchAllFilter(Func<Mostro, bool> filter = null)
        {
            if (filter != null)
                return InMemoryStorage.mostri.Where(filter).ToList();
            else
                return InMemoryStorage.mostri.ToList();
        }

        public Mostro GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Mostro item)
        {
            throw new NotImplementedException();
        }
    }
}
