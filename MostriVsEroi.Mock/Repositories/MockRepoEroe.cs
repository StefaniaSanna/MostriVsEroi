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

        public Eroe AddEroe(Eroe guerriero)
        {
            guerriero.Id = InMemoryStorage.eroi.Max(x => x.Id) + 1;
            InMemoryStorage.eroi.Add(guerriero);
            return guerriero;
        }

        public bool Delete(Eroe item)
        {
            InMemoryStorage.eroi.Remove(item);
            return true;
        }

        public IEnumerable<Eroe> FetchAllFilter(Func<Eroe, bool> filter = null)
        {
            if (filter != null)
                return InMemoryStorage.eroi.Where(filter).ToList();
            else
                return InMemoryStorage.eroi.ToList();
        }

        public Eroe GetById(int id)
        {
            return InMemoryStorage.eroi.SingleOrDefault(x => x.Id == id);
        }

        public bool Update(Eroe item)
        {
            throw new NotImplementedException();
        }
    }
}
