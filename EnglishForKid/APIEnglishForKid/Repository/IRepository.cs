using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace APIEnglishForKid.Repository
{
    interface IRepository<T>
    {
        bool AddItem(T item);
        bool UpdateItem(T item);
        bool DeleteItem(Guid id);
        T GetItem(Guid id);
        IEnumerable<T> GetItems();
    }
}
