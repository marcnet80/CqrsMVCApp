using System;
using System.Linq;

namespace CqrsApp.ReadModel.Interfaces
{
    public interface IRepository<T> : IDisposable
    {
        IQueryable<T> Entities { get; }
        void Save(T entity);
        void Delete(Guid id);
    }
}
