using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Model.Repository
{
    public class EleveRepository : IEleveRepository
    {
        public Task<Eleve> CreateEntity(Eleve entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(Eleve entity)
        {
            throw new NotImplementedException();
        }

        public Task<Eleve> GetById(long id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(Eleve entity)
        {
            throw new NotImplementedException();
        }
    }
}
