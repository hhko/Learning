using Ch03._09.__Domain__.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ch03._09.__Infrastructure__.General
{
    public class MappingRepository<TModel, TPersistence, TDbContext>
        : IRepository<TModel>
            where TPersistence : class
            where TDbContext : DbContext
    {
        public void Add(TModel obj)
        {
        }

        public void Delete(TModel obj)
        {
        }

        public void Dispose()
        {
        }

        public TModel Find(int id)
        {
            return default(TModel);
        }

        public IEnumerable<TModel> GetAll()
        {
            return null;
        }

        public void SaveChanges()
        {
        }
    }
}
