using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DAL
{
    public interface IRepository<T> : IDisposable
    {
        IEnumerable<T> GetAllItems();
        T GetItemById(int id);

        void InsertItem(T item);
        void UpdateItem(T item);
        void DeleteItem(int id);

        void Save();
    }
}
