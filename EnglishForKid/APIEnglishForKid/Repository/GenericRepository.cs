using APIEnglishForKid.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace APIEnglishForKid.Repository
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        protected EnglishDatabase _database { get; set; }
        protected DbSet<T> _table = null;

        public GenericRepository(EnglishDatabase englishDatabse)
        {
            _database = englishDatabse;
            _table = _database.Set<T>();
        }

        public bool AddItem(T item)
        {
            try
            {
                _table.Add(item);
                _database.SaveChanges();
            }catch(Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        public bool UpdateItem(T item)
        {
            try
            {
                _database.Entry(item).State = EntityState.Modified;
                _database.SaveChanges();
            }
            catch(DbUpdateConcurrencyException e)
            { 
                Debug.WriteLine(e.Message);
                return false;
            }
            return true;
        }

        public bool DeleteItem(Guid id)
        {
            try
            {
                T existItem = _table.Find(id);
                _table.Remove(existItem);
                _database.SaveChanges();
            }catch(Exception e)
            {
                return false;
            }
            return true;
        }

        public T GetItem(Guid id)
        {
            return _table.Find(id);
        }

        public IEnumerable<T> GetItems()
        {
            return _table.ToList();
        }
    }
}