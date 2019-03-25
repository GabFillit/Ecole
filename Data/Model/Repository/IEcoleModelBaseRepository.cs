using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model.Repository
{
    public interface IEcoleModelBaseRepository<T> : IBaseRepository
    {
        Task<T> GetById(long id);
        Task<T> CreateEntity(T entity);
        void DeleteEntity(T entity);
    }
}
