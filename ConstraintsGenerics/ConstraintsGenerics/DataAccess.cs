﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstraintsGenerics
{
    public class EmployeeDb : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }

    public interface IReadOnlyRepository<out T> : IDisposable // Covariant - i.e. T is a return type. Needed because Employee inherits Person, and we want to convert Employee to Person object, i.e. go to a parent level
    {
        T FindById(int id);
        IQueryable<T> FindAll();
    }

    public interface IWriteOnlyRepository<in T> : IDisposable  // Contravariant
    {
        void Add(T newEntity);
        void Delete(T entity);
        int Commit();
    }

    public interface IRepository<T> : IReadOnlyRepository<T>, IWriteOnlyRepository<T>, IDisposable
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

        public void Dispose()
        {
            _ctx.Dispose();
           
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
    }
}
