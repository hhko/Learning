using System;
using System.Collections.Generic;
using System.Text;

namespace Ch03._09.__Domain__.Data
{
    public interface IRepository<T> : IDisposable
    {
        IEnumerable<T> GetAll();
        T Find(int id);
        void Add(T obj);
        void Delete(T obj);
        void SaveChanges();
    }
}
