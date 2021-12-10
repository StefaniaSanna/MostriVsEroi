using MostriVsEroi.Core.Entities;
using MostriVsEroi.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Mock.Repositories
{
    public class MockRepoEroe : IEroe
    {
        public bool Add(Eroe item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Eroe item)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Eroe> FetchAllFilter(Func<Eroe, bool> filter = null)
        {
            throw new NotImplementedException();
        }

        public Eroe GetById(int id)
        {
            throw new NotImplementedException();
        }

        public bool Update(Eroe item)
        {
            throw new NotImplementedException();
        }
    }
}
