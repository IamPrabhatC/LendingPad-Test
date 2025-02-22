using System;
using System.Collections.Generic;
using BusinessEntities;

namespace Data.Repositories
{
    public interface IRepository<T> where T : IdObject
    {
        void Save(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
        T Get(Guid id);
    }
}