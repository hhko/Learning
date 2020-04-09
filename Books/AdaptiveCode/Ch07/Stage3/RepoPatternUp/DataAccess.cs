using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

//
// 교육 목표
// - in, out은 인터페이스에만 적용가능한다.
// - in, out은 함께 사용할 수 없다(함수 입력/출력으로 인터페이스가 분리되어야 한다.)
// - out: 함수 출력, 덜 구체적
// - in: 함수 입력, 더 구체적
//

namespace Lab_03_RepoPattern_Improved
{
    public class EmployeeDb : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }

    public interface IReadOnlyRepository<out T> : IDisposable
    {
        T FindById(int id);
        IQueryable<T> FindAll();
    }

    public interface IWriteOnlyRepository<in T> : IDisposable
    {
        void Add(T newEntity);
        void Delete(T entity);
        int Commit();
    }

    //public interface IRepository<in T> : IReadOnlyRepository<T>
    //{
    //    void Add(T newEntity);
    //    void Delete(T entity);
    //    int Commit();
    //}

    public interface IRepository<T> : IReadOnlyRepository<T>, IWriteOnlyRepository<T>
    {

    }

    public class SqlRepository<T> : IRepository<T> where T : class, IEntity
    {
        private DbContext _ctx;
        private DbSet<T> _set;

        public SqlRepository(DbContext ctx)
        {
            _ctx = ctx;
            _set = _ctx.Set<T>();
        }

        public void Add(T newEntity)
        {
            if (newEntity.IsValid())
            {
                _set.Add(newEntity);
            }
        }

        public void Delete(T entity)
        {
            _set.Remove(entity);
        }

        public T FindById(int id)
        {
            return _set.Find(id);
        }

        public IQueryable<T> FindAll()
        {
            return _set;
        }

        public int Commit()
        {
            return _ctx.SaveChanges();
        }

        public void Dispose()
        {
            _ctx.Dispose();
        }
    }
}
