using MostriVsEroi.Core.Entities;
using MostriVsEroi.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Mock.Repositories
{
    public class MockRepoArma : IArma
    {
        public bool Add(Arma item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Arma item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Arma> FetchAllFilter(Func<Arma, bool> filter = null)
        {
            throw new NotImplementedException();
        }

        public Arma GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Arma item)
        {
            throw new NotImplementedException();
        }
    }
}
