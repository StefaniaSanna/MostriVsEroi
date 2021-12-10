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

        public bool Delete(Mostro item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Mostro> FetchAllFilter(Func<Mostro, bool> filter = null)
        {
            throw new NotImplementedException();
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
