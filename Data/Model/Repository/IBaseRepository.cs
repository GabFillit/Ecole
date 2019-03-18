using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model.Repository
{
    public interface IBaseRepository
    {
        Task<bool> SaveAsync();
    }
}
