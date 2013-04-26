using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using  Wings.Core.Model;

namespace  Wings.Core.Service
{
    public interface ICrudService<T> where T: DelEntity, new()
    {
        int Create(T item);
        void Save();
        void Delete(int id);
        T Get(int id);
        IEnumerable<T> GetAll();
        IEnumerable<T> Where(Expression<Func<T, bool>> func, bool showDeleted = false);
        void Restore(int id);
    }
}