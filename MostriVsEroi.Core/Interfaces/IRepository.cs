using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MostriVsEroi.Core.Interfaces
{
    public interface IRepository<T>
    {
        IEnumerable<T> FetchAllFilter(Func<T, bool> filter = null); 
        T GetById(int id);
        bool Add(T item);
        bool Update(T item);
        bool Delete(T item);

    }
}
